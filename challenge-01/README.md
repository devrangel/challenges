# Teste Prático

## Proposta de solução
Desenvolver um sistema com um catálogo de aulas dividido por módulos

## Tecnologias usadas
* Backend
    * Arquitetura
        * Clean Architecture
    * API Rest
    * .NET 5
    * SQL Server
    * Swagger

* Frontend
    * React
    * React Material UI
    * Axios

## Descrição
O projeto consiste no desenvolvimento de uma aplicação que exibe uma lista de módulos. Cada módulo é composto por componentes, em que neste caso os componentes seriam as aulas.\
Para ter acesso aos conteúdos o usuário precisa fazer um login.\
O login é separado em duas *Role*:
* student -> Apenas visualização das aulas
* staff -> Visualização e edição dos conteúdos dos módulos

## Requisitos
* Módulos
    * Listar em ordem alfabética
    * Mostrar o total de aulas referente
    * Cadastro deve conter
        * Listagem
        * Criação
        * Edição
        * Deleção de registros
    * Atributos obrigatórios
        * Id, Nome
* Aulas
    * Listado em ordem alfabética
    * Cadastro deve conter
        * Listagem
        * Criação
        * Edição
        * Deleção de registros
    * Atributos obrigatórios
        * Id, Nome, Modulo e Data que acontecerá a aula
* Geral
    * Cadastro de usuários -> *student*
    * Cadastro das aulas e módulos somente pelo *staff*