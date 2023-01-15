# Resolução Testes 3 e Exames (21/22)

## Teste 3 V1 - `AAF268`

- [ ] `2`

> Descreve por palavras tuas:  
>
> - O que são e para que servem Scriptable Objects no Unity
> - Explica sucintamente como o mesmo é usado no Unity.

```md
Scriptable objects são uma classe do Unity que armazena código e cujas instâncias
podem ser guardadas como assets e variáveis de MonoBehaviours (ao contrário de
scripts normais). São particularmente úteis para armazenar informação que pode
ser partilhada entre game objects e scenes, permitindo por isso, por exemplo,
armazenar estados do programa que varias classes podem ler e modificar sem criar
co-dependências umas com as outras.
```

- [ ] `3`

> Considera a classe:
>
> ```c#
>   class ParallelAdd
>   {
>       private double result;
>       public void AddToResult(double toAdd) => result += toAdd;
>   }

- [ ] `3.1`

> Modifica a classe de modo a que as operações realizadas pelo método AddToResult()
> sejam thread-safe.

```c#
public class ParallelAdd
{
    private static readonly object threadLock = new object();
    private double result;

    public void AddToResult(double toAdd)
    {
        lock (threadLock)
        {
            result += toAdd;
        }
    }
}
```

- [ ] `3.2`

> Cria um programa que cria uma instância de ParallelAdd, lança 100 threads em
> paralelo, sendo que o método executado por cada uma das threads adiciona um
> valor aleatório entre 0 e 10 ao valor result da instância de ParallelAdd.

```c#
public class Program
{
    private static Random rnd;
    private static ParallelAdd parallelAdd;

    private static void Main()
    {
        rnd = new Random();
        parallelAdd = new ParallelAdd();

        for (int i = 0; i < 100; i++)
        {
            Thread t = new Thread(GetRandomUpTo10);
            t.Start();
        }
    }

    private static void GetRandomUpTo10()
    {
        parallelAdd.AddToResult(rnd.Next(11));
    }
}
```

- [ ] `4`

> Considera a struct:
>
> ```c#
>   public struct CharWithAScore
>   {
>       public char CharValue { get; set; }
>       public int Score { get; set; }
>   }

- [ ] `4.1`

> Adiciona uma conversão definida pelo utilizador para converter CharWithAScore
> em int (usando o valor de Score).

```c#
public static explicit operator int(CharWithAScore cws) => cws.CharValue;
```

- [ ] `4.2`

> Adiciona uma conversão definida pelo utilizador para converter int em
> CharWithAScore, no qual Score toma o valor do int e CharValue toma o valor do
> caráter espaço em branco.

```c#
public static implicit operator CharWithAScore(int value) => 
    new CharWithAScore() { Score = value; CharValue = ' ' };
```

- [ ] `4.3`

> Faz overload do operador + (adição) de modo a que o resultado seja uma instância
> de CharWithAScore com Score igual à soma dos scores de cada uma das instâncias
> somadas, e com CharValue igual ao CharValue com maior valor numérico Unicode de
> cada uma das instâncias somadas.

```c#
public static CharWithAScore operator +(CharWithAScore cws1, CharWithAScore cws2)
{
    return new CharWithAScore() 
    {
        Score = cws1.Score + cws2.Score,
        CharValue = (cws1.CharValue > cws2.CharValue) 
            ? cws1.CharValue : cws2.CharValue
    };
}
```

- [ ] `4.4`

> Escreve 3 linhas de código, cada uma exemplificando como são utilizados os
> operadores e conversores pedidos nas alíneas anteriores.

```c#
4.1 -> int n = (int)cws; // cws = CharWithAScore instance.
4.2 -> CharWithAScore cws = 5;
4.3 -> CharWithAScore cws = cws1 + cws2;
```

---

## Teste 3 V2 - `B111C`

- [ ] `2`

> Descreve por palavras tuas:  
>
> - O Singleton design pattern (o que é e o que nos permite fazer)
> - As vantagens e desvantagens desse pattern
> - Uma possível alternativa, realçando que problemas do Singleton essa
> alternativa resolve ou minimiza (podes referir um pattern alternativo ou uma
> técnica alternativa exclusiva do Unity, se preferires).

```md
O singleton design pattern assegura que uma classe que o implemente tenha apenas
uma instância, fornecendo um ponto de acesso global à mesma, como uma classe static.

A vantagem de usar o mesmo, é que ao contrario de uma classe static, este pode
implementar interfaces e ser estendido. Contudo, o singleton pattern viola também o
princípio de Least Knowledge, por ser um ponto de acesso global a que todos podem
aceder, e ainda o Single Responsibility Principle, ao adicionar à classe a 
funcionalidade extra de se auto-inicializar. A lista de desvantagens continua.

Uma boa alternativa a Singletons são os Unity Scriptable Objects. Instâncias que
podem ser partilhadas entre vários componentes, cujo estado é independente de
game objects e scenes. Isto é uma alternativa melhor uma vez que tem as mesmas
vantagens que um membro global, sem ser acessível por todo o programa, sendo
apenas injetado nas classes que precisam de o usar (possível até através do 
Editor).
```

- [ ] `3`

> Considera a struct:
>
> ```c#
>   public struct AlienRace
>   {
>       public bool AlienExist { get; set; }
>       public char Symbol { get; set; }
>   }

- [ ] `3.1`

> Adiciona uma conversão definida pelo utilizador para converter bool em
> AlienRace, no qual AliensExist toma o valor do bool e Symbol toma o valor do
> caráter espaço em branco se o bool for false ou o valor ’X’ se o bool for true.

```c#
public static implicit operator AlienRace(bool exists)
    => new AlienRace() { AlienExist = exists, Symbol = exists ? 'X' : ' ' };
```

- [ ] `3.2`

> Adiciona uma conversão definida pelo utilizador para converter AlienRace em
> bool (usando o valor de AliensExist).

```c#
public static explicit operator bool(AlienRace ar) => ar.AlienExist;
```

- [ ] `3.3`

> Adiciona um indexador só de leitura c/ índices inteiros, devolvendo um char
> cujo valor numérico é igual ao valor numérico de Symbol mais o valor inteiro do
> índice.

```c#
public char this[int index] => (char)(Symbol + index)
```

- [ ] `3.4`

> Escreve 3 linhas de código, cada uma exemplificando como são utilizados os
> conversores e indexadores pedidos nas alíneas anteriores.

```c#
3.1 -> AlienRace ar = true;
3.2 -> bool arExists = (bool) ar; // ar = AlienRace instance.
3.3 -> char newSymbol = ar[5];
```

- [ ] `4`

> Considera a classe:
>
> ```c#
>   class ParallelMult
>   {
>       private int result;
>       public void MultResult(int multiplier) => result *= multiplier;
>   }

- [ ] `4.1`

> Modifica a classe de modo a que as operações realizadas pelo método MultResult()
> sejam thread-safe.

```c#
public class ParallelMult
{
    private static readonly object threadLock = new object();
    private int result;

    public void MultResult(int multiplier)
    {
        lock (threadLock)
        {
            result *= multiplier;
        }
    }
}
```

- [ ] `4.2`

> Cria um programa que cria uma instância de ParallelMult, lança 30 threads em
> paralelo, sendo que o método executado por cada uma das threads multiplica um
> valor aleatório entre 2 e 7 ao valor result da instância de ParallelMult.

```c#
public class Program
{
    private static ParallelMult parallelMult;
    private static Random rnd;

    public static void Main()
    {
        rnd = new Random();
        parallelMult = new ParallelMult();
        
        for (int i = 0; i <30; i++)
        {
            Thread t = new Thread(RandomValue2To7);
            t.Start();
        }
    }

    private static void RandomValue2To7()
    {
        parallelMult.MultResult(rnd.Next(2, 8));
    }
}
```

---

## Exercícios Github

- [X] `48` **Threads + Lazy Singleton**

> Cria as seguintes classes:
>
> 1. Classe AddManager, com uma propriedade só de leitura de nome Total do tipo int
> (suportada numa variável de instância privada de nome total), e com um método
> AddToTotal(), que aceita um inteiro e adiciona-o à variável total. Esta classe
> deve ser um singleton com inicialização lazy, e tanto a sua inicialização como
> a modificação da variável total (dentro do método AddToTotal()) devem ser
> thread-safe.
>
> 2. Classe Adder, com o método LetsAdd(), que cria e lança uma thread que invoca
> 1000 vezes o método AddToTotal() da instância solitária de AddManager,
> passando-lhe inteiros aleatórios entre 0 e 100. A classe tem também a
> propriedade auto-implementada Partial, na qual a thread guarda o total parcial
> relativo aos inteiros que somou. O método LetsAdd() retorna a instância da
> thread criada e lançada.
>
> 3. Classe Program, com o método Main(), no qual: a) são criadas 20 instâncias de
> Adder; b) é invocado o método LetsAdd() em cada delas, sendo mantidas referência
> às threads devolvidas; c) é feita uma espera (com join) em todas as threads
> devolvidas; d) é realizada e mostrada no ecrã a soma do Partial de todas as
> instâncias de Adder; e) é mostrado no ecrã o valor Total da instância solitária
> de AddManager; e, f) é indicado no ecrã se as somas são iguais ou não.

- `48.1`

```c#
public class AddManager
{
    // Lazy singleton.
    private static readonly Lazy<AddManager> _instance = 
        new Lazy<AddManager>(() => new AddManager());

    // Thread lock.
    private static readonly object threadLock = new object();

    // Total property.
    public int Total => _total;
    private int _total;

    // Singleton instance.
    public static AddManager Instance => _instance;
    private AddManager() {}

    public AddToTotal(int p_toAdd)
    {
        lock (threadLock)
        {
            _total += p_toAdd;
        }
    }
}
```

- `48.2`

```c#
public class Adder
{
    // Partial property.
    public int Partial { get; private set; }

    public Thread LetsAdd()
    {
        Thread t = new Thread(RandomNum);
        t.Start();
        return t;
    }

    private void RandomNum()
    {
        Random rnd = new Random();
        int randomValue;

        for (int i = 0; i < 1000; i++)
        {
            randomValue = rnd.Next(101);
            Partial += randomValue;
            AddManager.Instance.AddToTotal(randomValue);
        }
    }
}
```

- `48.3`

```c#
public class Program
{
    private static void Main()
    {
        List<Adder> adderList = new List<Adder>();
        List<Thread> threadsList = new List<Thread>();

        // a) criadas e guardadas 20 instâncias de Adder.
        for (int i = 0; i < 20; i++)
            adderList.Add(new Adder());

        // b) invocado LetsAdd() em cada uma, mantendo threads devolvidas.
        foreach (Adder a in adderList)
            threadsList.Add(a.LetsAdd());

        // c) Esperar por todas as threads devolvidas.
        foreach (Thread t in threadsList)
            t.Join();

        // d) Mostrada a soma de Partial de todas as instâncias de Adder.
        int totalAdders = 0;
        foreach (Adder a in adderList)
            totalAdders += a.Partial;

        Console.WriteLine($"Total somado em todos os Adders: {totalAdders}");

        // e) Mostrado o Total da instância AddManager
        Console.WriteLine($"Total de AddManager: {AddManager.Instance.Total}");

        // f) Mostrado se somas são iguais.
        if (totalAdders == AddManager.Instance.Total) Console.WriteLine("Somas iguais.");
        else Console.WriteLine("Somas diferentes.");
    }
}
```

---

- [X] `50` **Threads**

> Considera o método com assinatura void DoStuff(). Assumindo que estás noutro
> método da mesma classe, escreve código para:
>
> 1. Declarar 100 threads que executem o método DoStuff().
>
> 2. Iniciar as 100 threads de modo a que executem em paralelo.
>
> 3. Esperar que a execução dessas mesmas threads termine.

```c#
List<Thread> threadsList = new List<Thread>();

// 1.
for (int i = 0; i < 100; i++)
{
    Thread t = new Thread(DoStuff);
    threadsList.Add(t);

    // 2.
    t.Start();
}

// 3.
foreach (Thread t in threadsList)
    t.Join();
```

---

- [X] `51` **Threads + Eventos**

> Considera a classe:
>
> ```c#
>   class ParallelCalculation
>   {
>       private double result;
>       public void AddToResult(double toAdd) => result += toAdd;
>   }
>   // other code.
>   public event Action Bingo;
> ```
>
> 1. Modifica a classe de modo a que as operações realizadas pelo método
> AddToResult() sejam thread-safe.
>
> 2. Considera que pc é uma instância de ParallelCalculation, e que tens um método
> com assinatura void BingoHandler(). Escreve uma linha de código na qual subscrevas
> o método BingoHandler() no evento Bingo.
>
> 3. Escreve o código do método OnBingo() da classe ParallelCalculation, usando
> as melhores práticas de visibilidade, extensão e tratamento de nulls.

```c#
// 1.
class ParallelCalculation
{
    private static readonly object threadLock = new object();
    private double result;

    public void AddToResult(double toAdd)
    {
        lock(threadLock)
        {
            result += toAdd;
        }
    }
}

// 2.
pc.Bingo += BingoHandler;

// 3.
protected virtual void OnBingo() => Bingo?.Invoke();
```

---

- [X] `52` **Conversões**

> Considera a classe:
>
> ```c#
>   public class AnnotatedDouble
>   {
>       public double DoubleValue { get; set; }
>       public string Annotation { get; set; }
>
>       public override string ToString() => $"{DoubleValue:f2} ({Annotation})";
>   }
> ```
>
> 1. Adiciona uma conversão definida pelo utilizador para converter AnnotatedDouble
> em double (usando o valor da propriedade DoubleValue).
>
> 2. Adiciona uma conversão definida pelo utilizador para converter AnnotatedDouble
> em string (usando o valor da propriedade Annotation).
>
> 3. Adiciona uma conversão definida pelo utilizador para converter double em
> AnnotatedDouble, na qual a propriedade DoubleValue toma o valor do double e a
> propriedade Annotation é inicializada com uma string vazia "".
>
> 4. Adiciona uma conversão definida pelo utilizador para converter uma string em
> AnnotatedDouble, na qual o campo Annotation toma o valor dessa string, e o campo
> double é inicializado a zero.
>
> 5. Apresenta algumas linhas de código que exemplifiquem as conversões definidas
> nas alíneas anteriores.

```c#
// 1.
public static explicit operator double(AnnotatedDouble ad) => ad.DoubleValue;

// 2.
public static explicit operator string(AnnotatedDouble ad) => ad.Annotation;

// 3.
public static implicit operator AnnotatedDouble(double double) 
    => new AnnotatedDouble() { DoubleValue = double, Annotation = "" };

// 4.
public static implicit operator AnnotatedDouble(string string)
    => new AnnotatedDouble() { DoubleValue = 0, Annotation = string };

// 5.
// ad = AnnotatedDouble instance.
double d = (double)ad;
string s = (string)ad;
AnnotatedDouble ad = 15.3;
AnnotatedDouble ad = "yes, it is a number";
```

---

- [X] `53` **Overload de operadores**

> Considera a classe `AnnotatedDouble` da questão anterior. Faz overload dos
> seguintes operadores de modo a que realizem as operações indicadas:
>
> 1. Operador + (adição): soma valores na propriedade DoubleValue; concatena
> strings na propriedade Annotation.
>
> 2. Operador - (subtração): subtrai valores na propriedade DoubleValue; remove
> caracteres da propriedade Annotation do primeiro operando que estejam presentes
> na propriedade Annotation do segundo operando.
>
> 3. Operador - (negação): aplica negação à propriedade DoubleValue, inverte
> string na propriedade Annotation (e.g. "ola" passa a ser "alo").

```c#
// 1.
public static AnnotatedDouble operator +(AnnotatedDouble ad1, AnnotatedDouble ad2)
{
    return new AnnotatedDouble() { 
        DoubleValue = ad1.DoubleValue + ad2.DoubleValue,
        Annotation = ad1.Annotation + ad2.Annotation };
}

// 2.
public static AnnotatedDouble operator -(AnnotatedDouble ad1, AnnotatedDouble ad2)
{
    StringBuilder ad1Short = new StringBuilder();

    foreach (char c in ad1.Annotation)
        if (!ad2.Annotation.Contains(c))
            ad1Short.Append(c);
    
    return new AnnotatedDouble() {
        DoubleValue = ad1 - ad2,
        Annotation = ad1Short };
}

// 3.
public static AnnotatedDouble operator -(AnnotatedDouble ad)
{
    char[] annotationArray = ad.Annotation.ToCharArray();
    Array.Reverse(annotationArray);

    return new AnnotatedDouble() {
        DoubleValue = -ad.DoubleValue,
        Annotation = new string(annotationArray) };
}
```

---

- [X] `54` **Overload de operadores**

> Relativamente aos operadores implementados na alínea anterior, qual é o output
> do seguinte código:
>
> ```c#
> ad1 = new AnnotatedDouble() { DoubleValue = -4.2, Annotation = "Negative" };
> ad2 = new AnnotatedDouble() { DoubleValue = 9.653, Annotation = "Highest" };
> Console.WriteLine(ad1 + ad2);
> Console.WriteLine(ad2 + ad1);
> Console.WriteLine(ad1 - ad2);
> Console.WriteLine(-ad2);
> ```

```md
5.45 (NegativeHighest)
5.45 (HighestNegative)
-13.85 (Nav)
-9.65 (tsehgiH)
```

---

- [ ] `55` **Overload de operadores**

> Indica o principal problema da sobre-utilização de overloading de operadores.

```md
Overloads, cuja função principal é tornar o código mais legível, quando
sobre-utilizados em casos mais complexos e menos intuitivos, podem acabar por ter
o efeito contrário, diminuindo a legibilidade do código.
```

---

- [X] `57` **Indexadores**

> Considera o seguinte tipo:
>
> ```c#
> public struct Weird { }
> ```
>
> 1. Implementa um indexador só de leitura no tipo Weird que aceite como índice
> uma variável do tipo object e devolva uma string contendo o resultado da
> invocação de ToString() na instância de object convertido em maiúsculas. Deves
> usar notação Lambda para simplificar a resolução do problema.
>
> 2. Considera o seguinte código:
>
> ```c#
>   Weird weirdVar;
>   string str = weirdVar["Hello world!"];
>   Console.WriteLine(str);
> ```
>
> - O que vai ser impresso no ecrã?
>
> - Porque é que não foi preciso instanciar weirdVar antes de usarmos o indexador
> (linha 2)? Teria sido necessário instanciar weirdVar se o tipo Weird fosse uma
> classe?
>
> - Na sequência do código apresentado, o que seria impresso no ecrã pela seguinte
> linha de código: Console.WriteLine(weirdVar[100]);

- `57.1`

```c#
public string this[object index] => index.ToString().ToUpper();
```

- `57.2`

```md
Impresso no ecrã: HELLO WORLD!

Não foi preciso instanciar weirdVar por ser uma struct, um tipo de valor, alocando
a memória apenas quando a variável é utilizada. Se fosse uma classe, um tipo de
referência, então a variável teria de ser instanciada com new para que pudesse
ser guardada na heap.

Seria impresso no ecrã: 100
```

---

- [X] `62` **Singletons**

> Descreve, por palavras tuas, três dos principais problemas no uso de singletons.
> Qual é a principal vantagem no uso deste design pattern?

```md
Três desvantagens dos usos de singletons são:

1. Viola o Single Responsibility Principle, adicionando à classe que o implemente
a funcionalidade extra de se auto-inicializar.

2. Viola o Least Knowledge Principle, por ser um ponto de acesso global a que
todas as classes têm acesso, promovendo dependência entre as mesmas.

3. Não é possível testar elementos isoladamente, visto que o singleton está
sempre envolvido.

A principal vantagem de usar o mesmo, é que ao contrario de classes static,
pode implementar interfaces e ser estendido.
```
