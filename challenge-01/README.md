# Teste Prático

## Proposta de solução
Desenvolver um sistema com um catálogo de aulas dividido por módulos.

## Tecnologias usadas
* Arquitetura
    * Clean Architecture
* API Rest
* .NET 5
* SQL Server
* Swagger
* Autenticação e Autorização com JWT

## Descrição
O projeto consiste no desenvolvimento de uma API que disponibiliza as rotas para acesso aos módulos e aulas. Cada módulo consiste em uma lista de aulas.\
O gerenciamento dos cursos e aulas é feito apenas por um usuário autenticado e autorizado com a "Role: staff".\
Qualquer usuário pode visualizar as aulas.

## Build
Todas as dependências do projeto são instaladas automaticamente pelo NuGet. Assim sendo necessário apenas realizar um `restore`.\
O banco de dados utilizado é o LocalDB do SQLServer.\
As migrations já foram geradas no projeto.\
Para criar o banco de dados, abra o `Package Manager Console`, do Visual Studio, e selecione como `Default project` o `Backend.Infra.Data` e execute o comando `Update-Database`.
