# EcommerceX
Este projeto foi desenvolvido utilizando arquitetura DDD e técnicas TDD e uma camada de microservices

## Getting Started


Para executar a solução será necessario executar alguns passos.


### Prerequisites

Visual Studio 2015 
Acesso a internet para poder restaurar o pacote nuget
SQL EXPRESS ou LocalDB

### Installing

1 - Restaurar os pacotes NUGET

2- Verificar a String de conexao

A string de conexÃ£o estão no app.config do projeto Ecx.Server.WebApi. Verifica se o SQL esta configurado para Integrated Security, caso não esteja, informe o usuário que tenha permissão para o Entity Framework realizar o setup.
```
<connectionStrings>
    <add name="ECXDB" providerName="System.Data.SqlClient" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=ECXDB;Integrated Security=True;MultipleActiveResultSets=True" />
</connectionStrings>
```



### Run 

Para rodar é preciso que seja iniciado dois projetos ao mesmo tempo. Para isso você deve clicar com o botão direito do mouse sobre a solução e ir no item menu Set StartUp Project

```
EcX.Server.WebApi  - API
WEb - MVC
```

### How to begin

Já existe um login de acesso com permissão de Administrador. 
Para utilizar as outras funções do sistema será necessario criar outros usuários.

```
Login : Admin@Admin.com.br
Senha : Admin
```

### Security 

Existe dois perfis com permissões distintas. Abaixo a lista de cada funcionalidade para os perfis.

```
Administrar 
	1 - CRUD produtos
	2 - Login / Logout
```
```
Cliente
	1 - Buscar produtos (por Nome / Descrição)
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

