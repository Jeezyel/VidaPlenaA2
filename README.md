# 📘 HOSPISIN

API desenvolvida em ASP.NET Core para gerenciamento de .

## 🚀 Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server (ou outro banco)
- Swagger (OpenAPI)

## 📦 Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/Jeezyel/VidaPlenaA2.git
2.Ajustes
  "ConnectionStrings": {
  "DefaultConnection": "coloque o seu banco de dados"
  }

3.criaçao
  va no seu ssms e crie um banco (VidaPlenaDB) para conectar com a api

4. rode os comando de de migração
   dotnet ef migrations add [nome que deseja]
   dotnet ef database update

# IMAGEN DA UML DO PROJETO

![ImagenUML](https://github.com/user-attachments/assets/66113754-1d2e-493c-b249-471cd275fd7a)
