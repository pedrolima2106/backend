# 🚀 Blog API - Backend

API REST desenvolvida com **ASP.NET Core Web API**, **Entity Framework Core** e **SQL Server** para gerenciamento de usuários, autenticação e posts de um sistema de blog mobile.

Este projeto faz parte de uma aplicação Full Stack com frontend em React Native.

---

# 🛠 Tecnologias

- C#
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- REST API

---

# 📌 Funcionalidades

## Autenticação
✅ Login com JWT  
✅ Registro de usuários  
✅ Controle de sessão  

---

## Usuários
✅ Criar usuário  
✅ Listar usuários  
✅ Editar usuário  
✅ Excluir usuário  

Perfis suportados:

- Admin
- Professor
- Aluno

---

## Posts
✅ Criar post  
✅ Listar posts  
✅ Editar post  
✅ Excluir post  
✅ Autor do post  

---

## Controle de Permissões

### Admin
- Gerencia usuários
- Cria posts
- Edita posts
- Exclui posts

### Professor
- Cria posts
- Edita posts
- Exclui posts

### Aluno
- Apenas visualização

---

# 📂 Estrutura do Projeto

```bash
BlogApi/
 ┣ Controllers/
 ┃ ┣ AuthController.cs
 ┃ ┣ UsersController.cs
 ┃ ┗ PostsController.cs
 ┣ Data/
 ┃ ┗ BlogContext.cs
 ┣ Models/
 ┃ ┣ User.cs
 ┃ ┗ Post.cs
 ┣ Migrations/
 ┣ appsettings.json
 ┣ Program.cs
 ┗ BlogApi.csproj
```

---

# ⚙️ Configuração

## 1. Clonar projeto

```bash
git clone https://github.com/SEU-USUARIO/blog-api.git
```

---

## 2. Entrar na pasta

```bash
cd BlogApi
```

---

## 3. Configurar banco SQL Server

Edite o arquivo:

```bash
appsettings.json
```

Exemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=BlogDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 4. Restaurar pacotes

```bash
dotnet restore
```

---

## 5. Rodar migrations

```bash
dotnet ef database update
```

---

## 6. Executar API

```bash
dotnet run
```

---

# Swagger

Após iniciar:

```bash
https://localhost:5001/swagger
```

ou

```bash
http://localhost:5000/swagger
```

---

# Endpoints

## Auth

### Login
```http
POST /api/Auth/login
```

Body:

```json
{
  "email": "admin@teste.com",
  "password": "123456"
}
```

---

### Register
```http
POST /api/Auth/register
```

Body:

```json
{
  "name": "Pedro",
  "email": "pedro@email.com",
  "password": "123456",
  "role": "Professor"
}
```

---

## Users

### Listar usuários
```http
GET /api/Users
```

### Buscar usuário
```http
GET /api/Users/{id}
```

### Atualizar usuário
```http
PUT /api/Users/{id}
```

### Excluir usuário
```http
DELETE /api/Users/{id}
```

---

## Posts

### Listar posts
```http
GET /api/Posts
```

### Criar post
```http
POST /api/Posts
```

Headers:

```http
role: Admin
```

Body:

```json
{
  "title": "Novo Post",
  "content": "Conteúdo do post",
  "author": "Pedro Santana"
}
```

---

### Atualizar post
```http
PUT /api/Posts/{id}
```

---

### Excluir post
```http
DELETE /api/Posts/{id}
```

---

# Usuários de Teste

## Admin
```bash
admin@teste.com
123456
```

## Professor
```bash
professor@teste.com
123456
```

## Aluno
```bash
aluno@teste.com
123456
```

---

# Melhorias Futuras

- JWT Authorization real com middleware
- Refresh Token
- Hash de senha com BCrypt
- Validação com FluentValidation
- DTOs
- AutoMapper
- Logs
- Paginação via API
- Upload de imagem para posts
- Comentários em posts
- Likes

---

# Autor

Pedro Santana

# Aplicação Front-end:
https://github.com/pedrolima2106/blog-mobile/tree/master
