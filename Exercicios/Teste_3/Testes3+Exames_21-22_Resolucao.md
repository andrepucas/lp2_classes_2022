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
