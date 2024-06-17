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

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Visual Studio
Iniciar o Projeto e utalizar os end points
<img width="959" alt="image" src="https://github.com/Flaviossilva/WebApiVylex/assets/32334149/9338b14f-e648-48ee-befd-f751069ba83a">





