# EcommerceX
Este projeto foi desenvolvido utilizando arquitetura DDD e t�cnicas TDD e uma camada de microservices

##Getting Started

Para executar a solu��o ser� necessario executar alguns passos.

### Prerequisites

Visual Studio 2015 
Acesso a internet para poder restaurar o pacote nuget
SQL EXPRESS ou LocalDB (Na instala��o do VSTO2015 vem o localDB)

### Installing

1 - Restaurar os pacotes NUGET

2- Verificar a String de conex�o

A string de conex�o est� no app.config do projeto Ecx.Server.WebApi. Verifica se o SQL esta configurado para Integrated Security, caso n�o esteja, informe o usu�rio que tenha permiss�o para o Entity Framework realizar o setup.
```
<connectionStrings>
    <add name="ECXDB" providerName="System.Data.SqlClient" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=ECXDB;Integrated Security=True;MultipleActiveResultSets=True" />
</connectionStrings>
```


### Run 

Para rodar � preciso que seja iniciado dois projetos. Para isso voc� deve clicar com o bot�o direito do mouse sobre a solu��o e ir no item menu Set StartUp Project

```
EcX.Server.WebApi  - API
WEb - MVC
```

## Authors

* **Rodrigo Oliveira** - *Initial work* - [Digonill](https://github.com/Digonill)
```