﻿using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RuculaX.Database.Common;
using RuculaX.Database.Query;

namespace RuculaUp.EntityFramework.Query;

public class IntegranteQueryPaged : PaginationAsync, IQuery
{
    private ApplicationContext _context;
    public IntegranteQueryPaged(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
       var output = await QueryAsync(config.Page, config);
       return output;
    }
    
    protected async override Task<IQueryConfigurationOutput> ContainAsync(IQueryConfigurationInput config)
    {
        var options = JsonSerializer.Deserialize<IntegranteOption>(config.Options);
                
        var integrantes =  await (from user in _context.Integrante
                .Where(c => c.Id.Contains(config.Text)  || c.Nome.Contains(config.Text) )
                .OrderBy(c => c.Id)
                .Take(config.RowNumber)

            select new IntegrantePagedDto {Id = user.Id, Nome = user.Nome, Ministerio = user.Ministerio })
            .ToListAsync();
        
        var last = integrantes.LastOrDefault();

        var optionsOutput =  new IntegranteOption(last?.Id, last?.Nome);
        
        return new QueryConfigurationOutput 
        {
            Name = config.Name,
            RowNumber = config.RowNumber,
            Options = last is null ? config.Options: JsonSerializer.Serialize(optionsOutput),
            Description = $"Consulta paginada {nameof(IntegrantePagedDto)}",
            Data = JsonSerializer.Serialize(integrantes)
        };    
        }

    protected async override Task<IQueryConfigurationOutput> FirstAsync(IQueryConfigurationInput config)
    {
        var options = JsonSerializer.Deserialize<IntegranteOption>(config.Options);
                
        var integrantes =  await (from user in _context.Integrante
                .OrderBy(c => c.Id)
                .ThenBy(c => c.Nome)
                .Take(config.RowNumber)

            select new IntegrantePagedDto {Id = user.Id, Nome = user.Nome, Ministerio = user.Ministerio })
            .ToListAsync();
        
        var last = integrantes.LastOrDefault();

        var optionsOutput = new IntegranteOption(last?.Id, last?.Nome);
        
        return new QueryConfigurationOutput 
        {
            Name = config.Name,
            RowNumber = config.RowNumber,
            Options = last is null ? config.Options: JsonSerializer.Serialize(optionsOutput),
            Description = $"Consulta paginada {nameof(IntegrantePagedDto)}",
            Data = JsonSerializer.Serialize(integrantes)
        };    
    }

    protected async override Task<IQueryConfigurationOutput> LastAsync(IQueryConfigurationInput config)
    {
        var options = JsonSerializer.Deserialize<IntegranteOption>(config.Options);
                
         var integrantes =  await (from user in _context.Integrante
                .OrderByDescending(c => c.Id)
                .ThenByDescending(c => c.Nome)
                .Take(config.RowNumber)

            select new IntegrantePagedDto {Id = user.Id, Nome = user.Nome, Ministerio = user.Ministerio })
                .OrderBy(c => c.Id)
                .ThenBy(c => c.Nome)
                .ToListAsync();

        var last = integrantes.LastOrDefault();

        var optionsOutput = new IntegranteOption(last?.Id, last?.Nome);
        
        return new QueryConfigurationOutput 
        {
            Name = config.Name,
            RowNumber = config.RowNumber,
            Options = last is null ? config.Options: JsonSerializer.Serialize(optionsOutput),
            Description = $"Consulta paginada {nameof(IntegrantePagedDto)}",
            Data = JsonSerializer.Serialize(integrantes)
        };       }

    protected async override Task<IQueryConfigurationOutput> NextAsync(IQueryConfigurationInput config)
    {
        var options = JsonSerializer.Deserialize<IntegranteOption>(config.Options);
                
        var integrantes =  await (from user in _context.Integrante
                .Where(c => String.Compare(c.Id,options.LastId) > 0)
                .WhereIf(config.Text.Length > 0, c => c.Nome.Contains(config.Text) || c.Id.Contains(config.Text))
                .OrderBy(c => c.Id)
                .ThenBy(c => c.Nome)
                .Take(config.RowNumber)

            select new IntegrantePagedDto {Id = user.Id, Nome = user.Nome, Ministerio = user.Ministerio })
            .ToListAsync();
        
        var last = integrantes.LastOrDefault();

        var optionsOutput =  integrantes.Count < config.RowNumber ? 
        new IntegranteOption(options?.LastId, options?.LastNome) : 
        new IntegranteOption(last?.Id, last?.Nome);
        
        return new QueryConfigurationOutput 
        {
            Name = config.Name,
            RowNumber = config.RowNumber,
            Options = last is null ? config.Options: JsonSerializer.Serialize(optionsOutput),
            Description = $"Consulta paginada {nameof(IntegrantePagedDto)}",
            Data = JsonSerializer.Serialize(integrantes)
        };
    }

    protected async override Task<IQueryConfigurationOutput> PreviousAsync(IQueryConfigurationInput config)
    {
        var options = JsonSerializer.Deserialize<IntegranteOption>(config.Options);
                
        var integrantes =  await (from user in _context.Integrante
                .Where(c => String.Compare(c.Id,options.LastId) < 0)
                .WhereIf(config.Text.Length > 0, c => c.Nome.Contains(config.Text) || c.Id.Contains(config.Text))
                .OrderByDescending(c => c.Id)
                .ThenByDescending(c => c.Nome)
                .Take(config.RowNumber)

            select new IntegrantePagedDto {Id = user.Id, Nome = user.Nome, Ministerio = user.Ministerio })
                .OrderBy(c => c.Id)
                .ThenBy(c => c.Nome)
                .ToListAsync();

        var last = integrantes.FirstOrDefault();

        var optionsOutput =  integrantes.Count < config.RowNumber ? 
        new IntegranteOption(options?.LastId, options?.LastNome) : 
        new IntegranteOption(last?.Id, last?.Nome);
                
        return new QueryConfigurationOutput 
        {
            Name = config.Name,
            RowNumber = config.RowNumber,
            Options = last is null ? config.Options: JsonSerializer.Serialize(optionsOutput),
            Description = $"Consulta paginada {nameof(IntegrantePagedDto)}",
            Data = JsonSerializer.Serialize(integrantes)
        };
    }
}
