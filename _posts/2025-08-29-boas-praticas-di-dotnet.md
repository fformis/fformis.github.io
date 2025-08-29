---
layout: post
title:  "Boas práticas de Injeção de Dependência no .NET"
date:   2025-08-29
categories: [Dependency Injection, Desenvolvimento]
excerpt: "A Injeção de Dependência é um dos princípios fundamentais da programação orientada a objetos, ela nos ajuda a criar sistemas mais flexíveis e testáveis. Neste post, vamos explorar algumas boas práticas para utilizar a Injeção de Dependência no .NET."
tags: [Dependency Injection, Desenvolvimento]
tagFile: [dependency-injection, desenvolvimento]
parts: 
month: "Agosto"
year: "2025"
---
O **.NET** oferece suporte nativo para Injeção de Dependência através do seu contêiner de serviços.

Um dos tópicos mais importantes é o ciclo de vida dos serviços, no .NET temos três principais: Transient, Scoped e Singleton.

- **Transient**: A cada solicitação, uma nova instância do serviço é criada. É ideal para serviços leves e sem estado.
- **Scoped**: Uma instância do serviço é criada por solicitação e compartilhada dentro do escopo da solicitação. É útil para serviços que precisam manter estado durante uma solicitação.
- **Singleton**: Uma única instância do serviço é criada e compartilhada durante toda a aplicação. É apropriado para serviços que não mantêm estado ou que precisam ser compartilhados.

Escolher o ciclo de vida correto para cada serviço é importante para garantir o desempenho e a escalabilidade da aplicação. 

Por exemplo: se um serviço pesado for criado como Transient, e muito solicitado, a cada solicitação desse serviço será criado uma nova instância, o que aumenta o consumo de recursos.

Portanto, é fundamental analisar o comportamento e as necessidades de cada serviço para escolher o ciclo de vida mais adequado.

Agora vamos entender como registrar serviços no contêiner de Injeção de Dependência do .NET.
Uma boa prática é definir a interface do serviço e a implementação em classes separadas. Isso facilita a manutenção e os testes, isso permite que possamos trocar a implementação do serviço sem afetar o código que depende dele.

{% include code-header.html %}
```csharp
public interface IMeuServico
{
    void Executar();
}

public class MeuServico : IMeuServico
{
    public void Executar()
    {
        // Lógica do serviço
    }
}
```
**Transient** 
{% include code-header.html %}
```csharp
services.AddTransient<IMeuServico, MeuServico>();
```
**Scoped** 
{% include code-header.html %}
```csharp
services.AddScoped<IMeuServico, MeuServico>();
```
**Singleton** 
{% include code-header.html %}
```csharp
services.AddSingleton<IMeuServico, MeuServico>();
```

**Preferir a Injeção de Dependência em vez de Instanciação Direta**

Sempre que possível, utilize a Injeção de Dependência para obter instâncias de serviços em vez de criá-las diretamente com o operador `new`. Sempre que utilizamos o `new`, já ficamos acoplados a uma implementação específica, o que dificulta a manutenção e os testes. Utilizando a Injeção de Dependência, podemos facilmente trocar a implementação do serviço sem afetar o código que depende dele.

Abaixo um exemplo de como utilizar a Injeção de Dependência por meio do construtor:

{% include code-header.html %}
```csharp
public class MeuController : ControllerBase
{
    private readonly IMeuServico _meuServico;

    public MeuController(IMeuServico meuServico)
    {
        _meuServico = meuServico;
    }

    public IActionResult Executar()
    {
        _meuServico.Executar();
        return Ok();
    }
}
```

Abaixo um exemplo de como utilizar a Injeção de Dependência por meio de uma propriedade:

{% include code-header.html %}
```csharp
public class MeuController : ControllerBase
{
    [FromServices]
    public IMeuServico MeuServico { get; set; }

    public IActionResult Executar()
    {
        MeuServico.Executar();
        return Ok();
    }
}
```

Abaixo um exemplo de como utilizar a Injeção de Dependência por parte do método:

{% include code-header.html %}
```csharp
public class MeuController : ControllerBase
{
    public IActionResult Executar([FromServices] IMeuServico meuServico)
    {
        meuServico.Executar();
        return Ok();
    }
}
```
Quando utilizar cada uma dessas abordagens:

|  Injeção por | Quando utilizar | Vantagens | Desvantagens |
|-----------|-----------------|-----------|--------------|
|Construtor | Quando a classe tem várias dependências obrigatórias. | Garante que a dependência estará disponível e não será nula; facilita testes; incentiva imutabilidade. | Pode deixar o construtor com muitos parâmetros se houver muitas dependências. |
| Propriedade | Quando a classe tem dependências opcionais ou quando a injeção por construtor torna-se muito complexa (muitos parâmetros). | Permite dependências opcionais; pode ser alterada em tempo de execução. | Não garante que a dependência estará disponível ao usar o objeto; pode gerar erros em tempo de execução se esquecer de setar. |
| Método | Quando a dependência é necessária apenas em um método específico. | Útil para dependências usadas apenas em métodos específicos; reduz o acoplamento da classe como um todo. | Pode poluir a assinatura dos métodos; não é útil para dependências compartilhadas por vários métodos. |