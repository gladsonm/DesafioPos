# 🚀 API de Produtos - Desafio Final

API REST desenvolvida em **ASP.NET Core (.NET)** utilizando arquitetura **MVC**, com aplicação de boas práticas como separação de camadas, uso de DTOs, injeção de dependência e documentação com Swagger.

---

## 📌 Introdução

Este projeto tem como objetivo a construção de uma API RESTful para gerenciamento de produtos, aplicando conceitos fundamentais de arquitetura de software.

---

## 🎯 Objetivo

A API permite:

- Criar produtos
- Listar produtos
- Buscar por ID
- Buscar por nome
- Atualizar produtos
- Remover produtos
- Contar registros

---

## 🧱 Arquitetura

A aplicação segue o padrão:

Controller → Service → Repository → Entity Framework → InMemory Database


### 🔹 Camadas

- **Controller** → Recebe requisições HTTP
- **Service** → Regras de negócio
- **Repository** → Acesso a dados
- **Model** → Entidade de domínio
- **DTO** → Comunicação com cliente

---

## 📁 Estrutura do Projeto

Desafio
│
├── AppContext
|
│ └── AppDbContext.cs
│
├── Controllers
│ └── ProdutoController.cs
│
├── DTO
│ └── Produto
│ ├── ProdutoCreateDto.cs
│ ├── ProdutoUpdateDto.cs
│ └── ProdutoResponseDto.cs
│
├── Model
│ └── Produto.cs
│
├── Repository
│ ├── Interface
│ │ └── IProdutoRepository.cs
│ └── ProdutoRepository.cs
│
├── Service
│ ├── Interface
│ │ └── IProdutoService.cs
│ └── ProdutoService.cs
│
├── Program.cs
├── appsettings.json



---

## ⚙️ Tecnologias Utilizadas

- .NET / ASP.NET Core
- Entity Framework Core
- InMemory Database
- Swagger (Swashbuckle)

---

## 🚀 Como executar o projeto

### 🔧 Pré-requisitos

- .NET SDK instalado

---

### ▶️ Rodando a aplicação

```bash
dotnet run

🌐 Acesse a API
http://localhost:5000/swagger

🔗 Endpoints

Base URL:
http://localhost:5000/api/Produto

📌 Rotas
| Método | Endpoint            | Descrição         |
| ------ | ------------------- | ----------------- |
| POST   | /Criar              | Criar produto     |
| GET    | /Listar             | Listar produtos   |
| GET    | /ObterPorId/{id}    | Buscar por ID     |
| GET    | /ObterPorNome?nome= | Buscar por nome   |
| GET    | /Contar             | Contar registros  |
| PUT    | /Update/{id}        | Atualizar produto |
| DELETE | /Delete/{id}        | Remover produto   |

