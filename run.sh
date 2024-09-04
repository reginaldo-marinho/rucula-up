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

case "$1" in
    "docker")
        exec_docker $2
    ;;
    "dotnet")
        dotnet run --project src/RuculaUp.WebApi/
    ;;
    *)
    return 1
    ;;
esac
