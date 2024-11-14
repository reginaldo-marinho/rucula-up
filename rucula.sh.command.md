# Comandos 

Para a maioria dos comandos, o RuculaUp perguntará em qual ambiente você deseja trabalhar.

- (1) 🧠🧠 DESENVOLVIMENTO 
- (2) ⭐⭐ HOMOLOGAÇÃO  
- (3) 🔥🔥 PRODUÇÃO 
- (0) Sair 

## Docker
### Iniciar Interface
```sh
    ./rucula.sh docker
    # Informe o ambiente
    (100) 📊 UI # Opção no display
    digite 100
```
**Nota**: Se a interface já estiver em execução, você terá a opção de recria-la.

### Iniciar Projeto .ASPNET CORE

```sh
    ./rucula.sh docker
    # Informe o ambiente
    (2) INICIAR CONTAINER 
    digite 2
```

Esse comando irá executar os container que fazem parte do projeto ASPNET.
**Nota**: Entenda que para ambiente de desenvolvimento o banco de dados será local, já os demais, `Staging` e `Production`, o banco de dados estará em container e para todas as novas migrações, você deverá fazer via `migrations script`.

