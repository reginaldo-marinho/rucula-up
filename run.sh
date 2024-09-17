#!/bin/bash

RED='\e[31m'
RESET='\e[0m'

function create_ui (){

    REPOSITORY_NAME=$(docker images --format {{.Repository}} --filter reference=rucula-ui)
    
    if ! [ "$REPOSITORY_NAME" = "rucula-ui" ]; then
        docker build -t rucula-ui ./src/RuculaUp.WebUi
        docker run -d --name rucula-ui -p 9000:9000 --restart always --network application rucula-ui
    fi
}

function exec_docker(){

    echo
    echo "Entrar em.."
    echo "(1) 🧠🧠 Desenvolvimento - Crie, Altere ou exclua funcionalidades."
    echo "(2) ⭐⭐ Homologação - Teste o que criou com dados mais precisos, mas que não tenha valor comercial para o contexto."
    echo "(3) 🔥🔥 Produção - Dados reais do negócio."
    echo "(0) Sair "
    
    OPT=""
    
    while ! [[ $OPT = "1" || $OPT = "2" || $OPT = "3" ]]; do
        read OPT
        if [ $OPT = "0" ]; then
            echo "Saindo..."
            exit 0
        fi
    done
    
    create_ui

    if [ $OPT = "1" ]; then
        docker compose -f compose.development.yml -p rucula_development up -d
    fi
    
    if [ $OPT = "2" ]; then
        docker compose -f compose.staging.yml -p rucula_staging up -d
    fi
    
    if [ $OPT = "3" ]; then
        docker compose -f compose.production.yml -p rucula_production up -d
    fi
    
    return 
}


function exec_entity(){
    echo ""
    echo "(1) Adicionar Migração"
    echo "(2) Adicionar Migração(Script) | Ideal para Produção 🔥🔥"
    echo "(3) Remover Migração"
    echo "(4) Update Database"
    echo "(0) Sair"

     OPT=""
    
    while ! [[ $OPT = "1" || $OPT = "2" || $OPT = "3" || $OPT = "4" ]]; do
        read OPT
        if [ $OPT = "0" ]; then
            echo "Saindo..."
            exit 0
        fi
    done 

    if [ $OPT = "1" ]; then
        echo "Nome da Migração"
        read NAME_MIGRATION
        dotnet ef migrations add  --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/ $NAME_MIGRATION
    fi
    if [ $OPT = "2" ]; then
        dotnet ef migrations script  --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/
    fi

    if [ $OPT = "3" ]; then
        dotnet ef migrations remove  --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/
    fi
    if [ $OPT = "4" ]; then
        dotnet ef database update  --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/
    fi
}

case "$1" in
    "docker")
        exec_docker $2
    ;;
    "dotnet")
        dotnet run --project src/RuculaUp.WebApi/
    ;;
    "ef")
        exec_entity
    ;;
    *)
    return 1
    ;;
esac
