namespace RuculaUp.Dapper.Integrante;

public sealed class IntegrantesPorFaixaEtariaQuery
{    
    public const string Query = @"
    SELECT 
        CASE
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) < 10 THEN '1-10'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 11 AND 20 THEN '11-20'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 21 AND 30 THEN '21-30'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 31 AND 40 THEN '31-40'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 41 AND 50 THEN '41-50'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 51 AND 60 THEN '51-60'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 61 AND 70 THEN '61-70'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 71 AND 80 THEN '71-80'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 81 AND 90 THEN '81-90'
            WHEN EXTRACT(YEAR FROM AGE(CURRENT_DATE, ""DataDeNascimento"")) BETWEEN 91 AND 99 THEN '91-99'
            ELSE '99+'
        END AS FaixaEtaria,
        COUNT(*) AS Total
    FROM public.""Integrante""
    GROUP BY FaixaEtaria
    ORDER BY FaixaEtaria;";
}
