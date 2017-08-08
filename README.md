# EcommerceX
Este projeto foi desenvolvido utilizando arquitetura DDD e técnicas TDD e uma camada de microservices

## Getting Started

<<<<<<< HEAD
Para executar a solu��o ser� necessario executar alguns passos.
=======
Para executar a solução será necessario executar alguns abaixo que irei descrever logo abaixo
>>>>>>> fc4aee7f802c9a6e8a881b4f80dc943041df7acd

### Prerequisites

Visual Studio 2015 
Acesso a internet para poder restaurar o pacote nuget
SQL EXPRESS ou LocalDB (Na instalação do VSTO2015 vem o localDB)

### Installing

1 - Restaurar os pacotes NUGET

2- Verificar a String de conexão

<<<<<<< HEAD
A string de conex�o est� no app.config do projeto Ecx.Server.WebApi. Verifica se o SQL esta configurado para Integrated Security, caso n�o esteja, informe o usu�rio que tenha permiss�o para o Entity Framework realizar o setup.
```
=======
A string de conexão está no app.config do projeto Ecx.Server.WebApi. Verifica se o SQL esta configurado para Integrated Security, caso não esteja informe o usuário que tenha permissão para o Entity Framework realizar o setup inicial.
...
>>>>>>> fc4aee7f802c9a6e8a881b4f80dc943041df7acd
<connectionStrings>
    <add name="ECXDB" providerName="System.Data.SqlClient" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=ECXDB;Integrated Security=True;MultipleActiveResultSets=True" />
</connectionStrings>
```


### Run 

Para rodar é preciso que seja iniciado dois projetos. Para isso você deve clicar com o botão direito do mouse sobre a solução e ir no item menu Set StartUp Project

```
EcX.Server.WebApi  - API
WEb - MVC
```

## Authors

* **Rodrigo Oliveira** - *Initial work* - [Digonill](https://github.com/Digonill)
<<<<<<< HEAD
```
=======
...
>>>>>>> fc4aee7f802c9a6e8a881b4f80dc943041df7acd
