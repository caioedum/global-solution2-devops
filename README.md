# iHelperDrone Web API

Web API RESTful desenvolvida em .NET para gerenciamento de drones, áreas de risco, alertas e usuários em operações de monitoramento inteligente. O backend utiliza Azure SQL Database e está pronto para deploy no Azure App Service.

---

## Integrantes do Grupo

- **Caio Eduardo Nascimento Martins - RM554025**
- **Julia Mariano Barsotti Ferreira - RM552713**
- **Leonardo Gaspar Saheb - RM553383**

## Funcionalidades

- Cadastro, atualização, remoção e consulta de **Usuários**
- Cadastro, atualização, remoção e consulta de **Drones**
- Cadastro, atualização, remoção e consulta de **Áreas de Risco**
- Cadastro, atualização, remoção e consulta de **Alertas**
- Integração com Azure SQL Database
- Pronto para deploy no Azure App Service

---

## Tecnologias

- [.NET 8](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [Azure SQL Database](https://azure.microsoft.com/services/sql-database/)
- [Azure App Service](https://azure.microsoft.com/services/app-service/)
- [Swagger/OpenAPI](https://swagger.io/) (documentação automática)

---

## Como Executar Localmente

1. **Clone o repositório:**

```bash
git clone https://github.com/caioedum/global-solution2-devops.git
cd global-solution2-devops
```

2. **Execute o projeto:**

```bash
dotnet run
```

---

## Estrutura das Tabelas

- **Usuario**: id_usuario, nome, email, senha_hash, nivel_acesso, status, data_criacao, data_atualizacao
- **Drone**: id_drone, nome, modelo, status, latitude, longitude, bateria, capacidade_carga, data_ultima_manutencao, horario_operacao, data_cadastro
- **AreaRisco**: id_area, nome_area, descricao, latitude, longitude, status, raio_cobertura, data_cadastro
- **Alerta**: id_alerta, tipo_alerta, data_hora, status, id_area, id_drone, id_usuario, gravidade, descricao

---

## Exemplos de Payloads

### POST /api/usuarios

```json
{
  "nome": "Maria Souza",
  "email": "maria.souza@email.com",
  "senhaHash": "hashseguro123",
  "nivelAcesso": "operador",
  "status": "ativo"
}
```


### POST /api/drones

```json
{
  "nome": "Drone Beta",
  "modelo": "DJI Phantom 4",
  "status": "ativo",
  "latitude": -23.5610,
  "longitude": -46.6550,
  "bateria": 80,
  "capacidadeCarga": 2.0,
  "dataUltimaManutencao": "2025-06-01T09:00:00",
  "horarioOperacao": "08:00-18:00"
}
```


---

## Endpoints Principais

| Método | Rota | Descrição |
| :-- | :-- | :-- |
| GET | /api/usuarios | Lista todos os usuários |
| GET | /api/usuarios/{id} | Detalhe de um usuário |
| POST | /api/usuarios | Cria um novo usuário |
| PUT | /api/usuarios/{id} | Atualiza um usuário |
| DELETE | /api/usuarios/{id} | Remove um usuário |
| ... | ... | ... |

Consulte o Swagger para todos os endpoints e exemplos.


## Licença

- Este projeto é de uso acadêmico - FIAP.
