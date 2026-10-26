# API Automation Framework — C# + RestSharp + NUnit

Framework de automação de testes de API REST desenvolvido em C#, utilizando RestSharp para requisições HTTP e NUnit para execução e validação dos testes automatizados.

O projeto foi criado com foco em boas práticas de automação, reutilização de código, organização dos testes e evolução para um portfólio de QA/SDET.

## Tecnologias utilizadas

- **C#** — linguagem de programação.
- **.NET 8** — plataforma de desenvolvimento.
- **RestSharp** — cliente HTTP para consumo de APIs REST.
- **NUnit** — framework de testes automatizados.
- **NUnit3TestAdapter** — integração dos testes com o Visual Studio Test Explorer.
- **Microsoft.NET.Test.Sdk** — execução dos testes pelo .NET.
- **Visual Studio Community** — ambiente de desenvolvimento.
- **JSONPlaceholder** — API pública utilizada nos testes de demonstração.

## Estrutura do projeto

```text
ApiAutomationFramework/
├── Config/
│   └── ApiSettings.cs
├── Clients/
│   └── ApiClient.cs
├── Models/
│   └── Post.cs
├── Tests/
│   └── PostsApiTests.cs
├── ApiAutomationFramework.csproj
└── README.md
```

### Responsabilidades das pastas

| Pasta/arquivo | Responsabilidade |
|---|---|
| `Config/` | Centralização das configurações da API. |
| `Clients/` | Métodos reutilizáveis para chamadas HTTP. |
| `Models/` | Classes que representam os dados JSON. |
| `Tests/` | Cenários automatizados e asserções. |
| `ApiSettings.cs` | Configuração da URL base. |
| `ApiClient.cs` | Implementação das operações HTTP. |
| `Post.cs` | Modelo de dados de publicação. |
| `PostsApiTests.cs` | Testes automatizados dos endpoints de publicações. |

## Pré-requisitos

Antes de executar o projeto, instale:

1. [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/).
2. [SDK do .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0).
3. Acesso à internet para consumir a API de demonstração.

No Visual Studio Installer, selecione a carga de trabalho **Desenvolvimento para desktop com .NET**, se necessária.

## Instalação e configuração

### 1. Clonar o repositório

Caso o projeto esteja publicado no GitHub ou GitLab:

```bash
git clone URL_DO_REPOSITORIO
cd ApiAutomationFramework
```

Substitua `URL_DO_REPOSITORIO` pelo endereço real do seu repositório.

### 2. Abrir no Visual Studio

Abra o arquivo `ApiAutomationFramework.csproj` no Visual Studio Community.

### 3. Restaurar dependências

No terminal, execute:

```bash
dotnet restore
```

### 4. Compilar o projeto

```bash
dotnet build
```

A compilação deve terminar sem erros antes da execução dos testes.

## Executando os testes automatizados

### Pelo terminal

Execute todos os testes:

```bash
dotnet test
```

Para obter mais detalhes da execução:

```bash
dotnet test --logger "console;verbosity=normal"
```

### Pelo Visual Studio Community

1. Abra a solução.
2. Acesse **Test → Test Explorer**.
3. Aguarde a descoberta dos testes.
4. Clique em **Run All Tests**.
5. Confira os resultados e os detalhes de eventuais falhas.

## Cenários de testes implementados

| Método HTTP | Endpoint | Validações |
|---|---|---|
| GET | `/posts/1` | Status HTTP 200, identificador e título. |
| GET | `/posts` | Status HTTP 200 e coleção não vazia. |
| POST | `/posts` | Status HTTP 201 e dados retornados. |
| PUT | `/posts/1` | Status HTTP 200 e título atualizado na resposta. |
| DELETE | `/posts/1` | Status HTTP 200. |

### Exemplo de validação

```csharp
var response = await _api.GetAsync<Post>("/posts/1");

Assert.That(response.StatusCode,
    Is.EqualTo(HttpStatusCode.OK));

Assert.That(response.Data, Is.Not.Null);
Assert.That(response.Data!.Id, Is.EqualTo(1));
Assert.That(response.Data.Title, Is.Not.Empty);
```

O exemplo verifica se a API respondeu com sucesso e se os dados retornados atendem às condições esperadas.

## API utilizada

O projeto utiliza a API pública [JSONPlaceholder](https://jsonplaceholder.typicode.com/).

Documentação e endpoints de exemplo:

- Consultar uma publicação: https://jsonplaceholder.typicode.com/posts/1
- Listar publicações: https://jsonplaceholder.typicode.com/posts
- Criar publicação: `POST /posts`
- Atualizar publicação: `PUT /posts/1`
- Excluir publicação: `DELETE /posts/1`

**Observação:** a JSONPlaceholder é uma API de demonstração. As operações de criação, atualização e exclusão simulam respostas, sem persistir as alterações no servidor.

## Arquitetura do framework

O projeto separa as responsabilidades em camadas:

- **Configuração:** centraliza o endereço base da API.
- **Cliente HTTP:** encapsula as chamadas RestSharp.
- **Modelos:** representam os objetos da API.
- **Testes:** executam as requisições e verificam os resultados com NUnit.

Essa organização reduz a duplicação de código e facilita a manutenção e a expansão da cobertura de testes.

## Melhorias planejadas

- [ ] Implementar autenticação com Bearer Token.
- [ ] Criar testes negativos para códigos HTTP 400, 401, 403, 404 e 500.
- [ ] Adicionar testes parametrizados e massa de dados.
- [ ] Implementar validação de contratos com JSON Schema.
- [ ] Integrar relatórios Allure.
- [ ] Separar configurações por ambiente.
- [ ] Implementar execução automatizada em pipeline CI/CD.
- [ ] Adicionar análise de cobertura e documentação técnica.
- [ ] Integrar o projeto ao GitHub Actions ou GitLab CI.

## Boas práticas

- Centralizar as chamadas HTTP no cliente de API.
- Evitar duplicação de código nos testes.
- Utilizar nomes de testes que expressem cenário, condição e resultado esperado.
- Validar status HTTP e conteúdo das respostas.
- Não armazenar tokens, senhas ou outros segredos no repositório.
- Manter as dependências atualizadas e compatíveis com o projeto.
- Separar os dados de teste das configurações dos ambientes.

## Objetivo do projeto

Este projeto demonstra conhecimentos de automação de testes de APIs REST com C#, RestSharp e NUnit, incluindo organização de código, consumo de endpoints, desserialização JSON, validações automatizadas e execução de testes.

**Autor:** Jerson Cunha  
**Área:** Quality Assurance | API Test Automation | QA/SDET  
**Linguagem:** C#  
**Plataforma:** .NET 8
