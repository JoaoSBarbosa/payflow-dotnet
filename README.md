# PayFlow

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![License](https://img.shields.io/badge/license-MIT-green)

## Visão Geral

**PayFlow** é um sistema de organização e gestão de transações financeiras, voltado para controle de pagamentos, fluxo de caixa e consolidação de dados financeiros.

O projeto está sendo desenvolvido com foco em **arquitetura limpa**, separação de responsabilidades e boas práticas do ecossistema **.NET**.

---

## Tecnologias

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Injeção de Dependência
- Cache em memória

---

## Estrutura do Projeto

```text
src/
 ├─ PayFlow.Api          # Camada de apresentação (API)
 ├─ PayFlow.Core         # Domínio, entidades e regras de negócio
 ├─ PayFlow.Application  # Casos de uso e contratos
 ├─ PayFlow.Infra        # Persistência, EF Core e integrações externas
```

---

## Objetivo

Fornecer uma base sólida para gerenciamento financeiro, permitindo:

- Cadastro e consulta de transações
- Controle de fluxo financeiro
- Evolução futura para relatórios e integrações

---

## 🔐 Configuração segura com dotnet user-secrets

Este projeto utiliza **dotnet user-secrets** para gerenciar informações sensíveis **durante o desenvolvimento**, como a **ConnectionString**, evitando que dados sensíveis sejam versionados no repositório.

### O que é o dotnet user-secrets?

O **user-secrets** é um recurso do .NET que permite armazenar configurações sensíveis fora do projeto, associadas apenas ao ambiente de desenvolvimento do usuário.

Esses dados:

- ❌ não ficam no `appsettings.json`
- ❌ não são versionados no Git
- ❌ não devem ser usados em produção
- ✅ ficam armazenados localmente na máquina do desenvolvedor

No Linux, os secrets são armazenados em:

```text
~/.microsoft/usersecrets/<UserSecretsId>/secrets.json
```

---

### Inicializando o user-secrets

Execute o comando **no projeto que consome a configuração** (geralmente `PayFlow.Api`):

```bash
dotnet user-secrets init
```

Isso adiciona automaticamente ao `.csproj`:

```xml
<UserSecretsId>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</UserSecretsId>
```

---

### Configurando a ConnectionString

Após inicializar, defina a ConnectionString:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=PayFlowDb;User Id=sa;Password=SuaSenha;"
```

Para listar os secrets configurados:

```bash
dotnet user-secrets list
```

---

### Utilizando a ConnectionString na aplicação

No `Program.cs` da API:

```csharp
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PayFlowContext>(options =>
    options.UseSqlServer(connectionString));
```

O .NET carrega automaticamente os **user-secrets** quando o ambiente está definido como `Development`.

---

### appsettings.json (sem informações sensíveis)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": ""
  }
}
```

---

### Importante

- **Não utilize user-secrets em produção**
- Para produção, utilize:

  - Variáveis de ambiente
  - Azure Key Vault
  - Docker Secrets
  - Kubernetes Secrets

---

## Status

🚧 Projeto em desenvolvimento.

---

## Licença

Este projeto está licenciado sob a licença **MIT**.

```

```
