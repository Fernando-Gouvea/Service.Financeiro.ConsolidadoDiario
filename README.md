
# Controle de Lançamentos de Caixa

## Descrição
Essa aplicação é responsável por **gerar lançamentos de caixa**, permitindo registrar **débitos** e **créditos** no banco de dados.  
O endpoint documentado abaixo permite adicionar novos lançamentos, especificando a data, valor e o tipo de operação (débito ou crédito).

---

## Endpoint: Adicionar Lançamento

### URL:  
```
POST https://localhost:7060/api/ControleLancamento/AdicionarLancamento
```

### Descrição:  
Esse endpoint **adiciona um novo lançamento de caixa** ao banco de dados.  
O lançamento pode ser:
- **Débito**: Saída de valor do caixa.
- **Crédito**: Entrada de valor no caixa.

---

## Parâmetros de Requisição:  
A requisição deve conter o **corpo no formato JSON** com os seguintes campos:  
```json
{
  "data": "string (formato ISO 8601, ex: '2025-02-23T13:30:45.691Z')",
  "valor": "decimal (ex: 100.50)",
  "tipo": "inteiro (1 para Crédito, 2 para Débito)"
}
```

### Detalhes dos Campos:
- **`data`**: Data e hora do lançamento (obrigatório).  
- **`valor`**: Valor do lançamento. Use números positivos (ex.: `100.50`).  
- **`tipo`**: Tipo do lançamento:  
  - `1`: **Crédito** (entrada de valor no caixa)  
  - `2`: **Débito** (saída de valor do caixa)  

---

## Exemplo de Requisição:
```bash
curl -X 'POST'   'https://localhost:7060/api/ControleLancamento/AdicionarLancamento'   -H 'accept: */*'   -H 'Content-Type: application/json'   -d '{
  "data": "2025-02-23T13:30:45.691Z",
  "valor": 150.75,
  "tipo": 1
}'
```

Neste exemplo:  
- O lançamento ocorrerá em **23 de fevereiro de 2025, às 13:30:45 (UTC)**.  
- O valor será **150.75**.  
- O tipo é **1 (Crédito)**, indicando uma **entrada de valor no caixa**.  

---

## Respostas:
- **201 Created**: Lançamento criado com sucesso.  
- **400 Bad Request**: Dados inválidos ou ausentes na requisição.  
- **500 Internal Server Error**: Erro inesperado no servidor.  

---

## Regras de Negócio:  
- Apenas valores **positivos** são aceitos no campo `valor`.  
- Se `tipo` for `1`, o valor será **adicionado** ao saldo do caixa.  
- Se `tipo` for `2`, o valor será **subtraído** do saldo do caixa.  
- Lançamentos com data **futura** não são permitidos.  

---

## Observações:
- A aplicação está configurada para rodar localmente em **https://localhost:7060**.   
- Para testar o endpoint, você pode utilizar ferramentas como **Postman** ou **Insomnia**, além do comando `curl` fornecido.  

---

## Tecnologias Utilizadas:
- **.NET 9**
- **Entity Framework Core**
- **SQL Server** (ou outro banco de dados configurado)
- **Swagger** (para documentação da API)
- **RMQ** (Publicar lançamento gerado para serviço Consolidado Diario)

---

## Como Executar o Projeto:
1. Clone o repositório:  
   ```bash
   git clone https://github.com/Fernando-Gouvea/Service.Financeiro.Lancamento.git
   ```
2. Restaure as dependências:  
   ```bash
   dotnet restore
   ```
3. Inicie o servidor:  
   ```bash
   dotnet run
   ```
4. Acesse o **Swagger** para testar o endpoint:  
   ```
   https://localhost:7060/swagger
   ```

---
