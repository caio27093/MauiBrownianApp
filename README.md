Desafio de Programação em .NET MAUI

Este projeto consiste na implementação de uma aplicação .NET MAUI que utiliza um código em C# para gerar e exibir um gráfico de movimento browniano. O movimento browniano é um conceito amplamente utilizado em finanças para modelar o comportamento estocástico dos preços.

Sobre:

Aplicação .Net MAUI olhando para o desktop mas funcional para dispositivos ios e android (testado em celulares)
Padrão utilizado: MVVM (Model-View-ViewModel) onde as Views tem a responsabilidade de exibir conteudo as Models tem a responsabilidade de armazenar os dados e as ViewModels a responsabilidade com a lógica como implementar o método GenerateBrownianMotion()
Utilização do skiaSharp para desenhar gráficos lineares
  *Futura implementação do LiveCharts2 que contem ferramentas de gráficos mais complexas e robustas de maneira gratuita e de código aberto podendo fazer melhorias e sugestões para o autor
  Multiplas linhas no gráfico e a opção de selecionar a cor para que fique melhor separada cada informação
  Uso de converters para transformar uma string de cor hex em uma cor de fato e fazer um color picker
  Binding entre elementos como stepper e entrys onde o valor do stepper afeta diretamente o valor do outro

  ![Imagem do aplicativo no windows](https://github.com/caio27093/MauiBrownianApp/assets/46321094/99af3554-4dc1-4294-82f1-956051c35590)
