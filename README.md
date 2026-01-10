# API Gerenciadora de Livros

- Uma API REST em .NET para gerenciar livros em uma livraria, com operações CRUD completas. 
- Desafio prático da formação em C# da Rocketseat.

## Funcionalidades

- Criar, listar, buscar, atualizar e excluir livros
- Validações de entrada (campos obrigatórios, tamanhos, duplicidade)
- Documentação interativa com Swagger
- Status HTTP apropriados para cada situação

## Tecnologias Utilizadas

- .NET 8.0
- ASP.NET Core Web API
- Swagger/OpenAPI

## Como Executar

```bash
# Clone o repositório
git clone https://github.com/LuandersonH/csharp_02_Gerenciador_de_Livraria.git

# Acesse a pasta do projeto
cd csharp_02_Gerenciador_de_Livraria

# Restaure as dependências
dotnet restore

# Execute a aplicação
dotnet run
```

Acesse a documentação interativa em: `https://localhost:<porta>/swagger`

## Endpoints Principais

- `POST /api/books` - Criar livro
- `GET /api/books` - Listar todos os livros
- `GET /api/books/{id}` - Buscar livro por ID
- `PUT /api/books/{id}` - Atualizar livro
- `DELETE /api/books/{id}` - Excluir livro
