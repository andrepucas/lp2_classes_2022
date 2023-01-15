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

> Modifica a classe de modo a que as operações realizadas pelo método AddToResult
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
    new CharWithAScore() { Score = value; CharValue = '' };
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
            ? cws1.CharValue
            : cws2.CharValue
    };
}
```

- [ ] `4.4`

> Escreve 3 linhas de código, cada uma exemplificando como são utilizados os
> operadores e conversores pedidos nas alíneas anteriores.

```c#
4.1 -> int n = (int)cws; // cws is CharWithAScore
4.2 -> CharWithAScore cws = 5;
4.3 -> CharWithAScore cws = cws1 + cws2;
```
