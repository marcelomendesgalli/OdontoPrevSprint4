# Challenge OdontoPrev Sprint 4 
## Projeto
Este projeto utiliza uma API RESTful em C#. A aplicação gerencia operações de Pacientes, Dentistas, Clínicas, Agendamentos, além de  com o auxílio de Machine Learning (ML.NET).

## Funcionalidades Principais:
Gerenciamento de Pacientes, Dentistas, Clínicas, Agendamentos.
Cadastro, leitura, atualização e exclusão (CRUD).
Testes unitários, de integração e de sistema com xUnit.
Documentação completa com Swagger.

## Integração com ML.NET
A API utiliza ML.NET para 


## Testes com xUnit
Foram desenvolvidos testes de:

Unidade, para validar comportamentos isolados dos serviços, integração validando conexão com o banco Oracle e endpoints REST e de sistema.
Todos os testes foram escritos com xUnit

## Endpoints CRUD
A API realiza operações CRUD com banco Oracle para os seguintes recursos:

GET /api/pacientes
POST /api/pacientes
PUT /api/pacientes/{id}
DELETE /api/pacientes/{id}

## Rodar a API
Clone o repositório:

git clone https://github.com/marcelomendesgalli/OdontoPrevSprint4.git

cd OdontoPrevSprint4

## Restaure as dependências:

dotnet restore

Execute o projeto:

dotnet run

Acesse o Swagger em https://localhost:{porta}/swagger

 
# Integrantes do Grupo

Erick Lopes Silva RM553927
Marcelo Mendes Galli RM553654
Lucas Emanuel da Silva Basto RM553771

