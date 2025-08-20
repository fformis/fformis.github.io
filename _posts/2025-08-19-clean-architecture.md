---
layout: post
title:  "Clean Architecture"
date:   2025-08-19
categories: [Clean Architecture, Programação, Desenvolvimento, dotnet, C#, CSharp]
excerpt: "A Clean Architecture é uma das arquiteturas mais faladas em desenvolvimento de software. Vamos entender o que é e como aplicá-la."
tags: [Clean Architecture]
parts: 
month: "Agosto"
year: "2025"
---
## Origem

A [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) foi proposta por Robert C. Martin, também conhecido como Uncle Bob. Ele é um dos principais defensores da programação orientada a objetos e autor de vários livros um deles aborda essa arquitetura de forma bastante aprofundada.

Uncle Bob, propôs a ideia da Clean Architecture como uma forma de organizar o código de forma que ele se torne mais fácil de entender e manter. A ideia central é separar as preocupações do sistema em camadas, onde cada camada tem uma responsabilidade específica.

## As camadas da Clean Architecture

O Modelo é composto por quatro camadas principais:

![Clean Architecture](../../assets/posts/clean-architecture.svg)

1. **Entities**: A camada mais interna, que contém as entidades de negócio e as regras fundamentais e que gerenciam o comportamento do sistema.

2. **Use Cases**: Nessa camada ficam as regras de negócio que representam as operações que o sistema deve realizar.

3. **Interface Adapters**: A camada que implementa os detalhes técnicos do sistema, como acesso a banco de dados, chamadas para serviços externos e exposição de APIs.

4. **Frameworks and Drivers**: A camada que contém as bibliotecas e ferramentas utilizadas pelo sistema, como frameworks web e bancos de dados.

Com as direção das dependências apontando de fora para dentro, temos o seguinte: Frameworks e Drivers dependem de Interface Adapters, que por sua vez dependem de Use Cases e Entities.

Como um exemplo de implementação da Clean Architecture, podemos considerar uma aplicação web que utiliza ASP.NET Core. A estrutura de pastas poderia ser organizada da seguinte forma:

![Clean Architecture Solution](../../assets/posts/clean-architecture-solution.svg)

A camada **CleanArchitecture.Domain** contém as entidades, regras de negócio mais fortes e abstrações que serão os contratos entre as camadas mais externas, enquanto a camada **CleanArchitecture.Application** contém os casos de uso. A camada **CleanArchitecture.Infrastructure** implementa os detalhes técnicos, como acesso a banco de dados e serviços externos, e a camada **CleanArchitecture.Api** expõe a API para o mundo exterior. 

Notem os bullets estão marcados com a cor de cada camada, porém a camada de Frameworks and Drivers não está identificada, isso porque muitas vezes ela acaba se misturando com a camada de Interface Adapters, como mostrado na documentação da [Microsoft](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures).

## Referências
- [Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
- [The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)