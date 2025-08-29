---
layout: post
title:  "File-Based Apps"
date:   2025-08-07
categories: [Programação, Desenvolvimento, dotnet, C#, CSharp]
excerpt: "Uma das novidades mais legais do .Net 10 é o suporte a aplicativos baseados em arquivos."
tags: [C#, dotnet, .net 10]
tagFile: [csharp, dotnet, net10]
parts: 
month: "Agosto"
year: "2025"
---
O **.Net 10**, tem várias novidades e melhorias, mas uma delas eu simplesmente adorei, que é o suporte a aplicativos baseados em arquivos ou **file-based apps**.

Os **file-based apps**, funcionam como da seguinte maneira, a partir de um arquivo .cs você pode criar um aplicativo, **sem a necessidade da estrutura de solução ou projetos**. 

Lógico que não é ideal para aplicações grandes ou complexas, para pequenos aplicativos e scripts, é sem dúvida uma mão na roda.

Vamos a um exemplo prático, imagine um arquivo chamado `app.cs` com o seguinte conteúdo:

{% include code-header.html %}
```csharp

File.ReadLines("input.txt")
	.ToList()
	.ForEach(line => Console.WriteLine(line));

```
Nesse exemplo, estamos apenas lendo o arquivo `input.txt` e exibindo seu conteúdo no console.
Para executar esse arquivo é basta:

{% include code-header.html %}
```powershell
dotnet run app.cs
```

Para executar em ambientes Unix, como o **Linux**, além do comando acima, você pode usar a diretiva **shebang** para indicar o dotnet na execução do script:

{% include code-header.html %}
```csharp
#!/usr/bin/env dotnet

File.ReadLines("input.txt")
	.ToList()
	.ForEach(line => Console.WriteLine(line));

```
No bash, você pode tornar o script executável com o comando:

{% include code-header.html %}
```bash
chmod +x app.cs
```

E então você pode executá-lo diretamente:

{% include code-header.html %}
```bash
./app.cs
```	

Para provas de conceito de código, scripts, automação de tarefas, vai facilitar muito mais a vida dos desenvolvedores C#.
