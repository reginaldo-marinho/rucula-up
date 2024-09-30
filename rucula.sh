#!/bin/bash

RED='\e[31m'
RESET='\e[0m'

RUCULA_ENV=""

function create_ui (){

    CONTAINER_NAME=$(docker ps --format {{.Names}}  --filter name=rucula-ui)
    
    if  [ "$CONTAINER_NAME" = "rucula-ui" ]; then

        echo "Container rucula-iu em execução, deseja recria-lo? (1)Sim | Demais (Não)"        
        read RECRIAR_UI

        if [ $RECRIAR_UI = "1" ]; then
    
            IMAGEM_ID=$(docker images --format {{.ID}} --filter reference=rucula-ui)
            CONTAINER_ID=$(docker ps --format {{.ID}}  --filter name=rucula-ui)
            
            if ! [ "$CONTAINER_ID" = "" ]; then
                echo parando container...
                docker container stop $CONTAINER_ID

                echo removendo container...

                docker container remove $CONTAINER_ID            
            fi

            if ! [ "$IMAGEM_ID" = "" ]; then
                echo removendo imagem...
                docker image rm $IMAGEM_ID
            fi            
        else
            echo "Saindo..."
            return 0
        fi
    fi

    echo "Construindo novo Container..."
    echo

    docker build -t rucula-ui ./src/RuculaUp.WebUi
    docker run -d --name rucula-ui -p 9000:9000 --restart always --network application rucula-ui


}

function exec_docker(){

    RUCULA_PROC=""

    echo "Informe o procedimento desejado: "
    echo "(1) BACKUP DOS VOLUMES "
    echo "(2) INICIAR CONTAINER "
    echo "(3) REMOVER CONTAINER "
    echo "(100) 📊 UI"
    
    while ! [[ $RUCULA_PROC = "1" || $RUCULA_PROC = "2" || $RUCULA_PROC = "3" || $RUCULA_PROC = "100" ]]; do
        read RUCULA_PROC
        if [ $RUCULA_PROC = "0" ]; then
            echo "Saindo..."
            exit 0
        fi
    done

   case "$RUCULA_PROC" in
            "1")
            ;;
            "2")
                FILE=""
                PROJECT_NAME=""

                if [ $RUCULA_ENV = "1" ]; then
                    FILE="compose.development.yml"
                    PROJECT_NAME="rucula_development"
                fi
                if [ $RUCULA_ENV = "2" ]; then
                    FILE="compose.staging.yml"
                    PROJECT_NAME="rucula_staging"
                fi
                if [ $RUCULA_ENV = "3" ]; then
                    FILE="compose.production.yml"
                    PROJECT_NAME="rucula_production"
                fi

                docker compose -f $FILE -p $PROJECT_NAME up -d
            ;;
            "3")
            ;;
            "100")
                create_ui
                return 0
            ;;
            *)
            
            return 1
            ;;
        esac
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

    if [ $OPT = "3" ]; then
        dotnet ef migrations remove  --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/
    fi
    if [ $OPT = "4" ]; then
        dotnet ef database update  --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/
    fi

    if [ $OPT = "1" ]; then
        echo "Nome da Migração"
        read NAME_MIGRATION
        dotnet ef migrations add  --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/ $NAME_MIGRATION
    fi
    if [ $OPT = "2" ]; then

        BASE_PATH=$(pwd)
        PATH_SCRIPT=$HOME/rucula-up/script
        FILE_SCRIPT=script.$RUCULA_ENV
        
        cd $PATH_SCRIPT
        
        MODIFICACOES=$(git status $FILE_SCRIPT --short | wc -l)
        
        cd $BASE_PATH
        
        if [ "$MODIFICACOES" = "0"  ]; then
            PATH_SCRIPT=$PATH_SCRIPT/$FILE_SCRIPT
            dotnet ef migrations script -o $PATH_SCRIPT --project ./src/RuculaUp.EntityFramework  --startup-project ./src/RuculaUp.WebApi/        
        else
            echo
            echo "Não foi possível criar script de migração"
            echo  -e "${RED}Modificações Pendentes.${RESET}"
            echo

            cd $PATH_SCRIPT
            git diff $FILE_SCRIPT
        fi
    fi
}

function set_environment(){
    
    echo "Informe o ambiente desejado: "
    echo "(1) 🧠🧠 DESENVOLVIMENTO "
    echo "(2) ⭐⭐ HOMOLOGAÇÃO  "
    echo "(3) 🔥🔥 PRODUÇÃO "
    echo "(0) Sair "

    while ! [[ $RUCULA_ENV = "1" || $RUCULA_ENV = "2" || $RUCULA_ENV = "3" ]]; do
        read RUCULA_ENV
        if [ $RUCULA_ENV = "0" ]; then
            echo "Saindo..."
            exit 0
        fi
    done
    clear
    echo
    case "$RUCULA_ENV" in
        "1")
            echo "🧠🧠 DESENVOLVIMENTO"
        ;;
        "2")
            echo "⭐⭐ HOMOLOGAÇÃO"
        ;;
        "3")
            echo "🔥🔥 PRODUÇÃO"
        ;;
    esac
    echo
}

clear # Limpa o Console inicialmente 

case "$1" in
    "docker")
        set_environment
        exec_docker
    ;;
    "run")
        dotnet watch --project src/RuculaUp.WebApi/ --no-build
        ng serve --base-href src/RuculaUp.WebUi/
    ;;
    "ef")
        set_environment
        exec_entity
    ;;
    *)
    return 1
    ;;
esac
