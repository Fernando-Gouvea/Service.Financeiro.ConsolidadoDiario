
# Consolidado diario 

## Descrição
Essa aplicação é responsável por **consolidar os lançamentos**, calculando o saldo diario entre os **débitos** e **créditos** no banco de dados. Isso é feito de forma assincrona por meio de fila publicado pelo serviço de Lançamento.  
O endpoint documentado abaixo permite buscar o consolidados especificando a data.

---

## Endpoint: Buscar Consolidado

### URL:  
```
POST https://localhost:7061//api/Consolidado/BuscarConsolidado/{data}
```

### Descrição:  
Esse endpoint **busca no cache ou no banco o consolidado do dia especificado na data**.  

---


## Exemplo de Requisição:
```bash
curl -X 'GET' \
  'https://localhost:7061/api/Consolidado/BuscarConsolidado/2025-02-23' \
  -H 'accept: */*'
```

Neste exemplo:  
- O consolidado da busca será de **23 de fevereiro de 2025**.  

---

## Respostas:
```
{
  "id": "83b4a21f-9713-47f5-94b6-bde01b5493af",
  "data": "2025-02-23T00:00:00-03:00",
  "totalCredito": 6366,
  "totalDebito": 125,
  "saldo": 6241
}
```

### Detalhes dos Campos:
- **`id`**: identificador do consolidado. 
- **`data`**: Data e hora consolidado.  
- **`totalCredito`**: Valor de credito do dia.
- **`totalDebito`**: Valor de debito do dia.  
- **`saldo`**: Valor de saldo do dia, sendo resultado do calculo (totalCredito - totalDebito = saldo).

---

- **200 Created**: Consolidado encontrado.  
- **400 Bad Request**: Dados inválidos ou ausentes na requisição.  
- **500 Internal Server Error**: Erro inesperado no servidor.  

---


## Observações:
- A aplicação está configurada para rodar localmente em **https://localhost:7061**.   
- Para testar o endpoint, você pode utilizar ferramentas como **Postman** ou **Insomnia**, além do comando `curl` fornecido.  

---

## Tecnologias Utilizadas:
- **.NET 9**
- **Entity Framework Core**
- **SQL Server** (ou outro banco de dados configurado)
- **Swagger** (para documentação da API)
- **Redis** (para performance nas buscas)
- **RMQ** (Consumir o lancamento gerado pelo serviço de Lancamento)

---

## Como Executar o Projeto:

1. Os projetos Service.Financeiro.Lancamento e Service.Financeiro.ConsolidadoDiario deve ser executados simultaneamente.

2. Clone os repositórios do projeto:  
   ```bash
   git clone https://github.com/Fernando-Gouvea/Service.Financeiro.ConsolidadoDiario.git
  
   ```
3. Entre na pasta do Projeto:  
   ```bash
    cd Service.Financeiro.ConsolidadoDiario/src/Service.Financeiro.ConsolidadoDiario.Presentation
   ```
   
4. Inicie o servidor:  
   ```bash
   dotnet run
   ```
   
5. Acesse o **Swagger** no navegador:  
   ```bash
   https://localhost:7061/swagger/index.html
   ```

---

## Melhorias:
- Implementação de um SDK para que itens em comuns usados nos MSs sejam centralizados, podendo ser instalados via pacote Nuget.   

