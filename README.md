Web Api Vylex

Baixar o projeto

Visual Studio
no visual studio é necessario alterar a string de conexão para o seu banco de dados "MySql" no arquivo appsettings.json para a sua conexão local
<img width="958" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/70290778-04c1-4a35-b7a2-e3040cf4c31f">


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PowerShel


depois abrir o powerShell e navegaver ate a pasta do projeto
no exemplo meu projeto esta no seguinte endereço C:\Users\FlávioSilvaVanquishC\Downloads\WebApiVylex\WebApiVylex, substituir pelo seu caminho.


PS C:\Users\FlávioSilvaVanquishC> cd C:\Users\FlávioSilvaVanquishC\Downloads\WebApiVylex\WebApiVylex


depois executar o comando para baixar o EntityFrameworkCore na maquina.


PS C:\Users\FlávioSilvaVanquishC\Downloads\WebApiVylex\WebApiVylex> dotnet add package Microsoft.EntityFrameworkCore
<img width="608" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/578dd270-de2b-433b-9bd6-eb3db80f3989">


apos a instalação inicar as migrações "comando responsavel por criar as tabelas no banco"

-Executar o comando dotnet ef migrations add Inicial "Inicial é o nome do arquivo de migrations e é apenas um exemplo"
<img width="493" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/5849f85b-d979-4688-88df-dff70aa2e892">

por ultimo é necessario rodar o comando  ef database updat O comando aplica todas as migrações que ainda não foram aplicadas ao banco de dados. 
dotnet ef database update

<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/d03eed95-51e2-458c-91f7-ccd7ffd19dc4">


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Visual Studio

Iniciar o Projeto 

<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/783c1207-f1aa-4271-8ec2-36ea8e690d3f">

é necessario estar autenticado para utilizar os end points, preencher usuario "WebApiVylex" e senha "WebApiVylex" no /Auth/login

<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/ac3da069-94c6-40c5-a495-03246c60ff1c">

copiar o token retornado e utilizar no icone de cadeado

<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/fe7de5b7-096b-40db-bfe1-e53ce62ae7fd">





<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/2f3be067-74e3-4c76-be9a-f575cc41b191">





<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/880d62dc-7714-4790-9bc5-b9f2f56cfa84">

Utilizar os end points

<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/98634a4e-a5d5-478b-9d01-0c6d26a39dd9">









