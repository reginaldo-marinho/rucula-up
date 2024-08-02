#!/bin/bash

RED='\e[31m'
RESET='\e[0m'


function create_containers (){
    
    export ENVIRONMENT=$1
    export PORT_APP=$2
    export PORT_DB=$3

    CONVENTION_NAME="${NAME}_app_${ENVIRONMENT}"
    
    REPOSITORY_NAME=$(docker images --format {{.Repository}} --filter reference=rucula-ui)
    
    if ! [ "$REPOSITORY_NAME" = "rucula-ui" ]; then
        docker build -t rucula-ui ./src/RuculaUp.WebUi
        docker run -d --name rucula-ui -p 9000:9000 --restart always --network application rucula-ui
    fi

    PROJECT_NAME=$(echo "$ENVIRONMENT" | tr '[:upper:]' '[:lower:]')

    docker compose -p $PROJECT_NAME up -d 
}

function exec_docker(){

    echo
    echo "Entrar em.."
    echo "(1) Desenvolvimento"
    echo "(2) Homologação"
    echo "(3) Produção"
    echo "(0) Sair "
    
    OPT=""
    
    while ! [[ $OPT = "1" || $OPT = "2" || $OPT = "3" ]]; do
        read OPT
        if [ $OPT = "0" ]; then
            echo "Saindo..."
            exit 0
        fi
    done
    
    ENVIRONMENT=
    PORT_APP=
    PORT_DB=

    if [ $OPT = "1" ]; then
        ENVIRONMENT="Development"
        PORT_APP=3900
        PORT_DB=1113
    fi
    
    if [ $OPT = "2" ]; then
        ENVIRONMENT="Staging"
        PORT_APP=4900
        PORT_DB=1112
    fi
    
    if [ $OPT = "3" ]; then
        ENVIRONMENT="Production"
        PORT_APP=5900
        PORT_DB=1111
    fi

    create_containers $ENVIRONMENT $PORT_APP $PORT_DB
    
    return 
}

echo $PROJECT_NAME_LOWER
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
