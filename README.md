# PayFlow

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![License](https://img.shields.io/badge/license-MIT-green)
![Tests](https://img.shields.io/badge/tests-unit%20%7C%20integration%20%7C%20e2e-success)

## Visão Geral

**PayFlow** é uma API para organização e gestão de transações financeiras, com foco em controle de categorias, entradas, saídas e fluxo de caixa.

O projeto foi construído com forte ênfase em **Clean Architecture**, **separação de responsabilidades**, **testabilidade** e **boas práticas do ecossistema .NET**, servindo tanto como base real de produto quanto como referência arquitetural.

---

## Principais Conceitos

* Arquitetura em camadas bem definidas
* Domínio rico com validações explícitas
* Casos de uso isolados na camada Application
* Persistência desacoplada via portas (Ports & Adapters)
* Estratégia clara de testes (Unit, Integration e E2E)
* Infraestrutura facilmente substituível (SQL Server, SQLite, etc.)

---

## Tecnologias

* .NET 8
* ASP.NET Core
* Entity Framework Core
* SQL Server (produção / desenvolvimento)
* SQLite (testes)
* FluentValidation
* xUnit
* FluentAssertions
* WebApplicationFactory (E2E)
* Injeção de Dependência nativa

---

## Estrutura do Projeto

### Código-fonte

```text
src/
 ├─ payFlow.Api          # Camada de apresentação (HTTP / Controllers / Middlewares)
 ├─ payFlow.Application  # Casos de uso, DTOs, serviços e contratos
 ├─ payFlow.Core         # Domínio, entidades, regras e validações
 ├─ payFlow.Infra        # Persistência, EF Core, Migrations e Repositórios
```

### Testes

```text
tests/
 ├─ payFlow.Tests            # Testes unitários (domínio, validações, entidades)
 ├─ payFlow.IntegrationTests # Testes de integração (Service → Repository → DB)
 ├─ payFlow.E2ETests         # Testes ponta-a-ponta (HTTP → API → DB)
```

---

## Estratégia de Testes

O projeto adota **três níveis claros de testes**, cada um com responsabilidade bem definida:

### Testes Unitários

* Foco em regras de negócio puras
* Sem acesso a banco ou infraestrutura
* Testam entidades, validações e comportamentos isolados

Projeto:

```
payFlow.Tests
```

---

### Testes de Integração

* Testam fluxo real entre **Application → Infra**
* Usam EF Core real com **SQLite em memória**
* Validam persistência e comportamento de serviços

Projeto:

```
payFlow.IntegrationTests
```

Exemplo de fluxo testado:

```
Service → Repository → DbContext → Banco
```

---

### Testes End-to-End (E2E)

* Exercitam a aplicação como um todo
* Sobem a API real via `WebApplicationFactory`
* Executam chamadas HTTP reais
* Validam contrato da API

Projeto:

```
payFlow.E2ETests
```

Fluxo completo:

```
HTTP → Controller → Application → Infra → Database
```

---

## Arquitetura (Visão Simplificada)

```text
API
 └─ Application
     └─ Core
     └─ Ports
         └─ Infra
```

* **API** depende apenas de Application
* **Application** não conhece Infra
* **Infra** implementa contratos definidos na Application
* **Core** não depende de nada

---

## 🔐 Configuração segura com dotnet user-secrets

Durante o desenvolvimento, informações sensíveis (como **ConnectionString**) não ficam versionadas no repositório.

O projeto utiliza **dotnet user-secrets** para isso.

### Inicializando

No projeto `payFlow.Api`:

```bash
dotnet user-secrets init
```

### Configurando a ConnectionString

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=PayFlowDb;User Id=sa;Password=SuaSenha;"
```

### Uso na aplicação

```csharp
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PayFlowContext>(options =>
    options.UseSqlServer(connectionString));
```

### Importante

* User-secrets **somente para desenvolvimento**
* Em produção, utilize:

  * Variáveis de ambiente
  * Docker Secrets
  * Azure Key Vault
  * Kubernetes Secrets

---

## Status

🚧 Projeto em desenvolvimento contínuo, com foco em qualidade de código, arquitetura e cobertura de testes.

---

## Licença

Este projeto está licenciado sob a licença **MIT**.
