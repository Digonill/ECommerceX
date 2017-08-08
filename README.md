# EcommerceX
Este projeto foi desenvolvido utilizando arquitetura DDD e t�cnicas TDD e uma camada de microservices

## Getting Started


Para executar a solu��o ser� necessario executar alguns passos.


### Prerequisites

Visual Studio 2015 
Acesso a internet para poder restaurar o pacote nuget
SQL EXPRESS ou LocalDB

### Installing

1 - Restaurar os pacotes NUGET

2- Verificar a String de conexao

A string de conexão est�o no app.config do projeto Ecx.Server.WebApi. Verifica se o SQL esta configurado para Integrated Security, caso n�o esteja, informe o usu�rio que tenha permiss�o para o Entity Framework realizar o setup.
```
<connectionStrings>
    <add name="ECXDB" providerName="System.Data.SqlClient" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=ECXDB;Integrated Security=True;MultipleActiveResultSets=True" />
</connectionStrings>
```



### Run 

Para rodar � preciso que seja iniciado dois projetos ao mesmo tempo. Para isso voc� deve clicar com o bot�o direito do mouse sobre a solu��o e ir no item menu Set StartUp Project

```
EcX.Server.WebApi  - API
WEb - MVC
```

### How to begin

J� existe um login de acesso com permiss�o de Administrador. 
Para utilizar as outras fun��es do sistema ser� necessario criar outros usu�rios.

```
Login : Admin@Admin.com.br
Senha : Admin
```

### Security 

Existe dois perfis com permiss�es distintas. Abaixo a lista de cada funcionalidade para os perfis.

```
Administrar 
	1 - CRUD produtos
	2 - Login / Logout
```
```
Cliente
	1 - Buscar produtos (por Nome / Descri��o)
	2 - Criar Pedido 
	3 - Adicionar produto carrinho
	4 - Historico de pedidos	
	5 - Finalizar compra
	6 - Remover Produto do carrinho
	7 - Login / Logout
```

## Authors

* **Rodrigo Oliveira** - *Initial work* - [Digonill](https://github.com/Digonill)
```

