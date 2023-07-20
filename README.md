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
