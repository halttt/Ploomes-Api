A aplicação permite realizar operações sobre advogados e processos, e também oferece a funcionalidade de cadastro e autenticação de usuários. A segurança da API é garantida com a utilização de **JWT** (JSON Web Tokens).

## Funcionalidades

Aqui estão as principais funcionalidades que o sistema oferece:

- **Cadastro de Advogados**: Permite o cadastro de advogados, com informações como nome, especialidade e outras.
- **Cadastro de Processos**: Registre processos jurídicos associados a advogados.
- **Cadastro e Login de Usuários**: Os usuários podem se cadastrar e fazer login para gerar um token JWT, garantindo a segurança das operações.
- **Autenticação via JWT**: Todas as operações sensíveis da API são protegidas, exigindo um token válido para autenticação.
- **Operações CRUD**: Realize operações de criação, leitura, atualização e exclusão de advogados, processos e usuários.
- **Documentação Interativa**: A API possui uma documentação interativa gerada pelo **Swagger**, facilitando a exploração dos endpoints.

## Tecnologias Utilizadas

Este projeto foi construído com as seguintes tecnologias:

- **.NET 8**: O backbone da aplicação, o framework que facilita o desenvolvimento e a manutenção da API.
- **Entity Framework Core**: Para trabalhar com o banco de dados de forma simples e eficiente, utilizando o padrão ORM.
- **MySQL**: O banco de dados que armazena as informações de advogados, processos e usuários.
- **JWT (JSON Web Token)**: Usado para autenticação segura nas rotas da API.
- **Swagger**: Para gerar a documentação interativa da API, que pode ser acessada diretamente no navegador.
- **AutoMapper**: Para facilitar o mapeamento entre as entidades e os DTOs.



