<p align="center">
    <img src="https://mutantbr.com/blog/wp-content/uploads/2019/08/post_interaxa_ok.jpg" width="300">
</p>

# Mutant - Interaxa | Desafio Prático | Rodrigo Elias da Silva

## Descrição

Esse desafio faz parte do processo seletivo da Mutant - Interaxa para a vaga _[v2064385 - Desenvolvedor .NET SENIOR - Lider Técnico](https://www.linkedin.com/jobs/view/1833901743/ e o teste ajudará a avaliar melhor o raciocínio lógico e a qualidade do seu código.

## Instruções

- A seguir, apresentamos a lista de informações disponíveis:

###### Banco de Dados
*As informações solicitadas foram criadas em um Banco de Dados SQL Server e para tal foram adicionados os scripts de execução de criação e população de dados [aqui](./bdscript.sql).

- SQL Server Management Studio	15.0.18330.0
- SQL Server Management Objects (SMO)	16.100.37971.0
- Operating System	10.0.17763

> Tables
- Ingredientes
- Lanches
- LanchesIngredientes
- Promocoes

> Store Procedures
- sp_Ingredientes_ById
- sp_Ingredientes_ListAll
- sp_Lanches_ById
- sp_Lanches_ListAll
- sp_Promocoes_ById
- sp_Promocoes_ListAll

###### Aplicação
*As informações solicitadas foram criadas utilizando o ambiente de desenvolvimento Microsoft Visual Studio v2019.

Seguind o contexto solicitado, fora desenvolvida uim aplaicação MVC .Net Core 2.0, com conceitos de camadas ( DDD ) e com implementações de bibliotecas jQuery e Bootstrap.
A adoção dos modelos seguiram afim de implementar organização e funcionalidades de desacoplamento ao projeto.

- Microsoft Visual Studio Community 2019
Version 16.6.0
- VisualStudio.16.Release/16.6.0+30114.105
- Microsoft .NET Framework
Version 4.8.03761

> Solution RS.Interaxa.Desafio.Lanche
1. Presentation
   - Lanche.UI.Web ( netcoreapp2.1 , jQuery JavaScript Library v3.3.1 e Bootstrap v3.4.1)
2. Application
   - Lanche.Application ( netcoreapp2.0 )
3. Domain
   - Lanche.Domain ( netcoreapp2.0 )
   - Lanche.Domain.Core ( netcoreapp2.0 )
4. Infra
   - Lanche.Infra.Data ( netcoreapp2.0 )
5. UnitTest
   - Lanche.UnitTest ( netcoreapp2.0 ) 


