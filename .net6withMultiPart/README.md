## Uploadfile
  Upload e download de arquivos utilizando container blobs azure e/ou armazenamento via banco de dados SQL. Para deploy, utilizou-se como ferramenta, o jenkins para hospedar na azure.

- [Pré-requisitos](#pré-requisitos)
- [Execução Aplicação](#execução) 
- [Plugins](#plugins)
- [Ferramentas](#ferramentas)
- [Configuração Credencial](#configuração-credencial)
- [Criação Pipeline](#criação-pipeline)
- [Configuração Azure](#configuração-azure)
- [Pós Construção](#pós-construção)
- [Links](#links)

## Pré-requisitos
  - Docker
  - SDK 6.0

## Execução

1- Para executar o jenkins utilize o docker-compose_jenkins 
  Basta remover _jenkins e executar o comando:
  
    - docker-compose up

2- Para executar a aplicação containeziada utilize o docker-compose
    
    1- Execute o comando :
      - docker build .   

    2- Verifique a imagem gerada listando:
      -docker image ls

    3- Substitua o valor de image pelo ID da sua imagem e execute:
      - docker-compose up

## Plugins
  - .NET SDK instalações
  - .NET SDK Configuration (Telemetry Opt-Out)
  - Git installations
    
Para instalar:

    1- Vá até painel de controle > gerenciar jenkins
    2- Clique em plugins
    3- Escolha Extensões disponíveis
    4- Busque pelos plugins e instale

## Ferramentas

    1- Vá até painel de controle > gerenciar jenkins
    2- Clique em tools
      2.1- Git installations
      2.2- Escolha o .Net SDK que mais se enquadre. No caso deste repositório .net 6

# Configuração Credencial
  - GitHub
  - AzureKey (Azure Service)

Para configurar :
  
    1- vá até painel de controle > gerenciar jenkins > credentials
    2- Em stores scoped to Jenkins, clique em system > global credentials
    3- Add domain 

# Criação Pipeline

Para criar:

    1- Painel de controle > Nova Tarefa
    2- Entre com um nome > pipeline > tudo certo
    3- Selecione:
      - GitHub project > {urlProjetoGitHub}
      - GitHub hook trigger for GITScm polling
      - Pipeline > Pipeline Script > copie e cole o jenkinsfile
    4- Clique em Salvar
    5- Clique em Construir

# Configuração Azure

Vá até seu App Services:

    1- Clique em configuration
    2- Adicione:
      - Adicione as variáveis de ambiente do container azure
      - Adicione a conection string do banco de dados
    
   ![image](https://github.com/elayneargollo/uploadfile/assets/48841005/fe36eef0-8ce4-44c2-9bd4-733b0cab6bd5)

    3- Na aba Path mappings:
      Altere 'Virtual applications and directories' > Physical Path > site\wwwroot\bin\Release\net6.0\publish

  ![image](https://github.com/elayneargollo/uploadfile/assets/48841005/f6594641-4a25-4799-a5b8-767489710497)
    
# Pós Construção

![image](https://github.com/elayneargollo/uploadfile/assets/48841005/987d55d4-1b32-4b22-9cf0-54385e629d13)


# Links

    - https://plugins.jenkins.io/azure-credentials/
    - https://plugins.jenkins.io/dotnet-sdk/
    - https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-linux?pivots=apt
