# BookManager

API REST para gerenciamento de livros, desenvolvida com ASP.NET Core e .NET 10.

## Requisitos

- .NET 10 SDK
- Visual Studio 2026 ou outro editor compatível com .NET
- Git, caso o projeto seja obtido de um repositório

Para verificar a versão instalada do SDK:

```powershell
dotnet --version
```

## Restaurar dependências

Na pasta raiz do projeto, onde está localizado o arquivo `BookManager.csproj`, execute:

```powershell
dotnet restore
```

## Build

Para compilar o projeto:

```powershell
dotnet build
```

Uma compilação bem-sucedida gera os arquivos na pasta `bin`.

## Executar a aplicação

Execute o projeto usando o perfil HTTPS:

```powershell
dotnet run --launch-profile https
```

A aplicação ficará disponível, normalmente, nos seguintes endereços:

- HTTPS: `https://localhost:7045`
- HTTP: `http://localhost:5022`

Também é possível executar usando o perfil HTTP:

```powershell
dotnet run --launch-profile http
```

Para executar pelo Visual Studio, abra `BookManager.slnx`, selecione o perfil `https` ou `http` e pressione `F5` ou `Ctrl+F5`.

## Swagger / OpenAPI

Com a aplicação em execução no ambiente de desenvolvimento, a interface Swagger está disponível em:

```text
https://localhost:7045/swagger
```

O documento OpenAPI pode ser acessado em:

```text
https://localhost:7045/openapi/v1.json
```

Se estiver usando HTTP, substitua a porta e o protocolo:

```text
http://localhost:5022/swagger
http://localhost:5022/openapi/v1.json
```

Caso o certificado HTTPS local não seja confiável, execute:

```powershell
dotnet dev-certs https --trust
```

## Endpoints disponíveis

A rota base da API é `/api/book`.

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/api/book` | Cria um livro |
| `GET` | `/api/book` | Lista os livros |
| `GET` | `/api/book/{id}` | Consulta um livro pelo ID |
| `PUT` | `/api/book/{id}` | Atualiza um livro pelo ID |
| `DELETE` | `/api/book/{id}` | Exclui um livro pelo ID |

Os endpoints que usam `{id}` exigem que o valor seja informado na rota, por exemplo:

```text
GET https://localhost:7045/api/book/1
```

## Exemplo de criação

Requisição:

```http
POST https://localhost:7045/api/book
Content-Type: application/json
```

Corpo:

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
	"genre": 1,
  "price": 59.90,
  "stock": 10
}
```

Os valores disponíveis para `genre` são os seguintes valores numéricos:

- `0` - `Fiction`
- `1` - `NonFiction`
- `2` - `Science`
- `3` - `History`
- `4` - `Biography`

Exemplo usando PowerShell:

```powershell
$body = @{
	title = "Clean Code"
	author = "Robert C. Martin"
	genre = 1
	price = 59.90
	stock = 10
} | ConvertTo-Json

Invoke-RestMethod `
	-Uri "https://localhost:7045/api/book" `
	-Method Post `
	-ContentType "application/json" `
	-Body $body
```

## Estrutura principal

```text
BookManager/
├── Communication/
│   ├── Requests/
│   └── Responses/
├── Controllers/
│   └── BookController.cs
├── Book.cs
├── BookGenres.cs
├── Program.cs
├── BookManager.csproj
└── BookManager.slnx
```

## Observação

Os dados usados atualmente pelos endpoints estão em memória e são exemplos para desenvolvimento. Eles não são persistidos em um banco de dados após o encerramento da aplicação.
