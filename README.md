# ImportadorCnab
## Descrição do Projeto
<p align="center">🚀 O projeto tem como objetivo importar um arquivo cnab.txt normalizar e salvar os dados e depois recuperar as informacoes salvas</p>

<h4 align="center"> 
	🚧  Status do projeto 🚀 Em construção...  🚧
</h4>

### 🛠 Objetivo

Demostrar o uso de cqrs,  o projeto é um crud de pessoa básico onde ao salvar uma pessoa lançará um evento para salvar em um banco nosql
ele esta separado em [QueryStack](https://github.com/Lucas-Sampaio/ExemploCQRS/tree/master/src/API/Application/Queries) onde tem uma classe que vai ser responsavel por trazer as
consultas do banco mongodb
e uma [CommandStack](https://github.com/Lucas-Sampaio/ExemploCQRS/tree/master/src/API/Application/Commands) que vai ser responsavel por fazer a escrita no banco sql server
#### Fluxo do projeto
![Alt text](/Assets/FluxoCqrs2.png?raw=true "Fluxo")

### 🛠 Como usar
 1. Baixe o projeto
 2.Abra o seu cmd acesse a pasta [docker](https://github.com/Lucas-Sampaio/ImportadorCnab/tree/master/Docker) e rode o comando-> ```docker-compose up -d```
 isso irá subir os serviços necessario pro projeto.
 3. Para acessar a api pelo seu navegador acesse o link http://localhost:8001/swagger/index.html
 4. Para acessar o projeto web acesse http://localhost:8002/

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.Net 7](https://github.com/dotnet)
- [Ef Core Sql Server](https://github.com/dotnet/efcore)
- [Xabaril/HealthCheck](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks)
 #### HealthCheck Uri - localhost:'porta'/api/hc-ui
  ![Alt text](/Assets/healthcheck.png?raw=true "Fluxo")

# Documentação do CNAB

Exemplo de uma linha valida -> 3201903010000014200096206760174753****3153153453JOÃO MACEDO   BAR DO JOÃO       

| Descrição do campo  | Inicio | Fim | Tamanho | Comentário
| ------------- | ------------- | -----| ---- | ------
| Tipo  | 1  | 1 | 1 | Tipo da transação
| Data  | 2  | 9 | 8 | Data da ocorrência
| Valor | 10 | 19 | 10 | Valor da movimentação. *Obs.* O valor encontrado no arquivo precisa ser divido por cem(valor / 100.00) para normalizá-lo.
| CPF | 20 | 30 | 11 | CPF do beneficiário
| Cartão | 31 | 42 | 12 | Cartão utilizado na transação 
| Hora  | 43 | 48 | 6 | Hora da ocorrência atendendo ao fuso de UTC-3
| Dono da loja | 49 | 62 | 14 | Nome do representante da loja
| Nome loja | 63 | 81 | 19 | Nome da loja

# Documentação sobre os tipos das transações

| Tipo | Descrição | Natureza | Sinal |
| ---- | -------- | --------- | ----- |
| 1 | Débito | Entrada | + |
| 2 | Boleto | Saída | - |
| 3 | Financiamento | Saída | - |
| 4 | Crédito | Entrada | + |
| 5 | Recebimento Empréstimo | Entrada | + |
| 6 | Vendas | Entrada | + |
| 7 | Recebimento TED | Entrada | + |
| 8 | Recebimento DOC | Entrada | + |
| 9 | Aluguel | Saída | - |
