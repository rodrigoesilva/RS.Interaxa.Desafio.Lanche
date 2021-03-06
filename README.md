<p align="center">
    <img src="https://mutantbr.com/blog/wp-content/uploads/2019/08/post_interaxa_ok.jpg" width="300">
</p>

# Mutant - Interaxa | Desafio Prático | Rodrigo Elias da Silva

## Descrição

Esse desafio faz parte do processo seletivo da Mutant - Interaxa para a vaga _[v2064385 - Desenvolvedor .NET SENIOR - Lider Técnico](https://www.linkedin.com/jobs/view/1833901743/) e o teste ajudará a avaliar melhor o raciocínio lógico e a qualidade do seu código.

O desafio consiste em duas partes: uma aplicação Front-end e uma solução Back-end. A descrição com os requisitos estão descritas no Cénario abaixo e tambem [aqui](./INFO.md).

## Cenário

*Somos uma startup do ramo de alimentos e precisamos de uma aplicação web para gerir nosso negócio. Nossa especialidade é a venda de lanches, de modo que alguns lanches são opções de cardápio e outros podem conter ingredientes personalizados.

- A seguir, apresentamos a lista de ingredientes disponíveis:

|  	  INGREDIENTES  	|  VALOR  |
| ---------------------	|---------|
| Alface  				| R$ 0,40 |
| Bacon  				| R$ 2,00 |
| Hambúrguer de carne  	| R$ 3,00 |
| Ovo 					| R$ 0,80 |
| Queijo 				| R$ 1,50 |

- Segue as opções de cardápio e seus respectivos ingredientes:

|  	  LANCHE  	|  INGREDIENTES  							|
| ------------- |-------------------------------------------|
| X-Bacon  		| Bacon, hambúrguer de carne e queijo 		|
| X-Burger  	| Hambúrguer de carne e queijo 				|
| X-Egg  		| Ovo, hambúrguer de carne e queijo			|
| X-Egg Bacon 	| Ovo, bacon, hambúrguer de carne e queijo 	|


O valor de cada opção do cardápio é dado pela soma dos ingredientes que compõe o lanche. Além destas opções, o cliente pode personalizar seu lanche e escolher os ingredientes que desejar. Nesse caso, o preço do lanche também será calculado pela soma dos ingredientes.

- Existe uma exceção à regra para o cálculo de preço, quando o lanche pertencer à uma promoção. A seguir, apresentamos a lista de promoções e suas respectivas regras de negócio:

|  	  PROMOÇÃO  |  REGRA DE NEGÓCIO  																											|
| ------------- |-------------------------------------------------------------------------------------------------------------------------------|
| Light  		| Se o lanche tem alface e não tem bacon, ganha 10% de desconto.																|
| Muita carne  	| A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante... 			|
| Muito queijo 	| A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...			|
| Inflação		| Os valores dos ingredientes são alterados com frequência e não gastaríamos que isso influenciasse nos testes automatizados. 	|

## CRITÉRIOS DE COMPLETUDE / ENTREGÁVEIS

O projeto deve ser entregue atendendo aos seguintes critérios


- Você deve entregar um conjunto de artefatos, de acordo com o nível de complexidade que achar melhor. A seguir, os níveis de complexidade e seus respectivos entregáveis:

- O server-side deve ser desenvolvido em .NET C# MVC.

- O client-side deve ser desenvolvido em  jQuery, CSS, Bootstrap.

- O banco de dados deve ser SQL Server, de preferência para utilizar procedures em todas as comunicações.

- Deve possuir cobertura de testes automatizados para os seguintes pontos:

- Valor dos lanches de cardápio, regra para cálculo de preço e promoções.

- Não é necessário se preocupar com a autenticação dos usuários.

 
**Fácil:**
- Implementação dos requisitos;
- Instruções para executar.
 
**Médio:**
- Implementação dos requisitos;
- Instruções para executar;
- Relatório de justificativas para escolha do design de código;
 
**Difícil:**
- Implementação dos requisitos;
- Instruções para executar;
- Relatório de justificativas para escolha do design de código;
- Os testes automatizados devem ser executados por algum modelo de integração contínua;
- Ambiente virtualizado em Docker com scripts para execução do projeto.



