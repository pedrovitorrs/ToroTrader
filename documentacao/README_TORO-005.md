# Desafio Toro Desenvolvedor Full-Stack e Backend

Bem-vindo ao desafio de programação da Toro Investimentos.

## História de Usuário
   

`TORO-005` - Eu, como investidor, gostaria de ter acesso a uma lista de 6 ou mais produtos de Renda Fixa, com seus respectivos nomes, preços unitários, taxas e lastro(estoque), para que eu possa comprar. A cada produto escolhido durante a compra desejo informar as quantidades. Além disso, gostaria de ver meu saldo da minha conta Toro. Minhas compras devem respeitar o limite de saldo e lastro do produto, para que assim eu possa adquirir produtos de Renda Fixa com sucesso.
  - Restrições:
    * Para efeito de simplificação do desafio, os 6 produtos e a conta Toro com o Saldo podem ser definidos utilizando algum recurso predefinido no backend (uma coleção no banco de dados ou arquivo JSON).
  - Critérios de Aceite:
    * A lista de produtos deve vir com a ordenação decrescente do campo taxa (Melhores taxas primeiro)
    * Cada produto de Renda Fixa, deve apresentar, nome do ativo, indexador, preço unitário, taxa e botão comprar.
    * A cada compra, o estoque do produto deve ser debitado.
    * O saldo da conta Toro deve ser validado.
    * O estoque do Produto deve ser validado.
    * Após a compra, o saldo da conta Toro deve ser debitado
      
  - Desejável:
    * Utilizar controle e estruturas de concorrência
    * Utilizar messageria(Filas) na implementação
    * Diagrama de sequência do Fluxo


#### Frontend:
* Garantir que o usuário possa visualizar o seu Saldo da conta Toro atualizado
* Garantir que o usuário visualize a lista de produtos
* Garantir que o usuário faça uma compra selecionando um produto específico informando a quantidade desejada.

#### Backend:
  * API para buscar os dados de Produtos
    * GET <apiBaseUrl>/products
  * API para efetuar a operação de compra
    * POST <apiBaseUrl>/order

Sugestão da Lista de Produtos:
```jsonc
[{ "BondAsset": "CDB", // Tipo do Produto de Renda Fixa
    "Index": "IPCA", // Indexador, ex: IPCA, Selic, etc
    "Tax": 5.0, // Taxa atrelada ao Indexador
    "IssuerName": "Banco Teste", // Emissor do Produto
    "UnitPrice": 1000, // Preço unitário do Produto
    "Stock": 100, // Estoque do produto	},

  { "BondAsset": "LCI", // Tipo do Produto de Renda Fixa
    "Index": "Pre", // Indexador, ex: IPCA, Selic, etc
    "Tax": 12.0, // Taxa atrelada ao Indexador
    "IssuerName": "Banco Teste 2", // Emissor do Produto
    "UnitPrice": 2000, // Preço unitário do Produto
    "Stock": 20, // Estoque do produto }]
```

Sugestão da Conta Toro com Saldo do Cliente:
```jsonc
{        
  “Account": 00001, // Conta Toro do Cliente
  “ClientId": "12454", // Id do Cliente
  “Balance": 1000.00, // Saldo do Cliente
}
```

## Etapa:

O Desafio Técnico da Toro Investimentos deve ser feito no tempo que você precisar.

Você está vivendo um dia a dia real nosso, as histórias acima são inspiradas em histórias reais elaboradas por nossos Product Managers (PM ou PO). Você, no papel de Time de Desenvolvimento, tem a liberdade para propor, discutir e implementar da melhor forma possível, buscando entregar o maior valor ao usuário no menor tempo, sem comprometer os requisitos, inclusive de qualidade.

O desafio consiste em você escolher uma das histórias acima e implementá-la. Prepare seu ambiente, crie um novo projeto, e implemente uma das USs. Este é o momento para considerar:

- Qual padrão arquitetural será adotado MVC? Clean Architecture? APIs Restful? 
- Como irei automatizar os testes? Em quais níveis irei implementar testes? Unitário? Integração? E2E?
- Adotarei algum framework? Quais?

Então é isso. Escolha uma as 4 Histórias de usuário acima e Mãos à obra! Te esperamos na segunda etapa!

Iremos também fazer algumas perguntas sobre algumas das decisões tomadas por você em cima do seu projeto. Enfim, iremos conhecer melhor seu skill técnico. 

## É isso! O desafio está dado o que foi colocado até aqui já é suficiente para realizá-lo.

## Daqui pra baixo é apenas material complementar de suporte ao seu desafio.
Abaixo, para efeito de direcionar o desafio, vamos te ajudar e propor um caminho para sua implementação. Mais uma vez, aqui é apenas um guia/sugestão, você tem total autonomia para fazer diferente, desde que atenda aos requisitos impostos pelas USs.

Se analisarmos o conjunto das USs tragas pelo nosso PM/PO acima, podemos já antecipar algumas Entidades necessárias na solução final:

- Uma coleção de Usuários, onde cada usuário tem:
  - um código da conta do usuário no Banco Toro (Para efeito de simplificaçao vc pode optar por usar o codigo da conta como codigo do usuário - chave primária, ou ter códigos separados);
  - um saldo de conta corrente (como não existe o requisito de extrato de conta, etc, vamos simplificar o saldo como num único atributo numérico do usuário que pode ser 0 ou maior 0);
  - Nome e CPF (nao está diretamente descrito no requisito, mas usaremos para identificar usuário na hora da transferencia bancária)
  
- Uma coleção de Ativos de Usuários
  - Ativos adquiridos por um único usuário. Você precisa ter saber quais ativos e quantidade do mesmo ativo que o usuário possui. Não está no requisito saber o "valor de compra" do ativo, apenas o "valor atual", então pode ser ignorado esta informação;

- Uma coleção contendo os "5 ativos mais negociados", e o seu valor atual (estes valores serao fiquitícios, mas deve ser possível alterá-los para efeito de demostração da solução final);


Considerando as Entidades e Coleções de Entidades acima, você precisa implementar o backend e o frontend da solução. Vale lembrar que este desafio é o mesmo para vagas "Backend" ou "FullStack", então você pode optar por trazer pronto para a segunda etapa uma das partes ou as duas a depender da vaga em questão:

## Requisitos

- O projeto deve ser publicado em um repositório público no github.com, bitbucket.org ou gitlab.com
- README com instruções de como instalar as dependências do projeto, de como rodar a aplicação e os testes automatizados e de como fazer o deploy
- Back-End deve ser desenvolvido em  C# Net 6 ou maior
- Front-End deve ser em Angular (v14+)
- Necessidades diferentes dos requisitos podem (devem) ser negociados previamente.

### Bônus

- Sistema executável rodando hospedado numa conta AWS.
- Backend deployado com Framework Serverless ou AWS SAM, ou rodando em docker-compose;
- Usar o CI/CD da plataforma onde hospedar o código (bitbucket pipelines, gitlab-ci, github actions)
- FrontEnd utilizando State Management e gráficos com bibliteca ngx-charts no Angular
  
## Critérios de Avaliação

Os seguintes critérios serão usados para avaliar o seu código:
- Legibilidade;
- Escopo;
- Organização do código;
- Padrões de projeto;
- Existência e quantidade de bugs e gambiarras;
- Qualidade e cobertura dos testes;
- Documentação;
- Contexto e cadência dos commits.
- Princípios SOLID e Clean Code
- Aderência aos 12 fatores: https://12factor.net/

## Dúvidas

Caso surjam dúvidas, entre em contato conosco pelo nosso email: desafiotoro@toroinvestimentos.com.br