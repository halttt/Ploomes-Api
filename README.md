## API de Gestão de Advogados e Processos
Esta aplicação permite realizar operações sobre advogados e processos, e oferece funcionalidades de cadastro e autenticação de usuários. A segurança da API é garantida com a utilização de JWT (JSON Web Tokens).

## IMPORTANTE
Todas as chamadas devem ser validadas com o Token JWT, com exceção das rotas de Cadastro e Login.
A senha deve ter um caractere especial, letra maiúscula e número (Exemplo: Senha123!)

### Como usar a aplicação:

#### Criação de usuário:
Envie uma requisição POST para o endpoint de cadastro com o seguinte corpo:

    { 
    "Username": "Teste",
    "Password": "Senha123!",
    "RePassword": "Senha123!"
    }
  
Username deve ser único.
Password e RePassword devem ser iguais e atender aos critérios de segurança.
Se o Username já estiver em uso ou as senhas forem inválidas, a API retornará um erro.

#### Login
Após criar o usuário, faça login com o seguinte corpo de requisição:

    {
    "Username": "Teste",
    "Password": "Senha123!"
    }

  
Após um login bem-sucedido, você receberá um Token JWT. Copie esse token e cole-o no campo de Authorization do Swagger, utilizando o formato:
Bearer <seu_token_jwt>

## Funcionalidades

Aqui estão as principais funcionalidades que o sistema oferece:

- **Cadastro de Advogados**: Permite o cadastro de advogados, com informações como nome, especialidade e outras.
- **Cadastro de Processos**: Registre processos jurídicos associados a advogados.
- **Cadastro e Login de Usuários**: Os usuários podem se cadastrar e fazer login para gerar um token JWT, garantindo a segurança das operações.
- **Autenticação via JWT**: Todas as operações sensíveis da API são protegidas, exigindo um token válido para autenticação.
- **Operações CRUD**: Realize operações de criação, leitura, atualização e exclusão de advogados, processos e usuários.
- **Documentação Interativa**: A API possui uma documentação interativa gerada pelo **Swagger**, facilitando a exploração dos endpoints.

- ## EndPoints

### Advogados

- **GET** /Advogados: Recupera a lista de advogados cadastrados.
- **POST** /Advogados: Cadastra um novo advogado.
- **GET** /Advogados/{id}: Recupera um advogado específico pelo ID.
- **PUT** /Advogados/{id}: Atualiza as informações de um advogado existente.
- **DELETE** /Advogados/{id}: Remove um advogado do sistema.

### Processos

- **GET** /Processos: Recupera a lista de processos cadastrados.
- **POST** /Processos: Cadastra um novo processo.
- **GET** /Processos/{id}: Recupera um processo específico pelo ID.
- **PUT** /Processos/{id}: Atualiza as informações de um processo existente.
- **DELETE** /Processos/{id}: Remove um processo do sistema.
 
### Usuários

- **POST** /Usuarios/Cadastro: Cadastra um novo usuário.
- **POST** /Usuarios/Login: Realiza o login de um usuário e retorna um token JWT.
- Para detalhes sobre os parâmetros de cada endpoint, exemplos de requisições e respostas, consulte a documentação interativa gerada pelo Swagger na sua aplicação.

- Lembre-se de que todas as operações, exceto as de cadastro e login de usuários, requerem um token JWT válido para autenticação.

## Tecnologias Utilizadas

Este projeto foi construído com as seguintes tecnologias:

- **.NET 8**: O backbone da aplicação, o framework que facilita o desenvolvimento e a manutenção da API.
- **Entity Framework Core**: Para trabalhar com o banco de dados de forma simples e eficiente, utilizando o padrão ORM.
- **MySQL**: O banco de dados que armazena as informações de advogados, processos e usuários.
- **JWT (JSON Web Token)**: Usado para autenticação segura nas rotas da API.
- **Swagger**: Para gerar a documentação interativa da API, que pode ser acessada diretamente no navegador.
- **AutoMapper**: Para facilitar o mapeamento entre as entidades e os DTOs.



