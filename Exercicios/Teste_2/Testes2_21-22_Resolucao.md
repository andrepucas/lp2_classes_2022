# Resolução Testes 2 (21/22)

## VERSÃO 1 - `AF07B`

- [X] `1.1`

> Escreve o código dos seguintes métodos de extensão para int, bem como da
> classe que os contém:
>
> - **bool IsEven()** – Devolve true se inteiro for par, false caso contrário.
> - **bool IsPositive()** – Devolve true se inteiro for positivo, false caso
> contrário.
> - **bool IsMultipleOf(int otherInt)** – Devolve true se inteiro for múltiplo
> do inteiro passado como argumento, false caso contrário.

```c#
public static class IntExtensions
{
    public static bool IsEven(this Int32 i) => i % 2 == 0;

    public static bool IsPositive(this Int32 i) => i >= 0;

    public static bool IsMultipleOf(this Int32 i, int otherInt) => i % otherInt == 0;
}
```

- [X] `1.2`

> Considera o inteiro 4. Como invocarias o método IsMultipleOf(3) nesse valor?
> E qual seria o resultado?

```c#
4.IsMultipleOf(3);

O resultado seria false.
```

- [X] `1.3`

> Considera a variável bagOfInts do tipo IEnumerable\<int>. Usando expressões
> Lambda e LINQ, escreve as seguintes expressões:
>
> - Expressão que resulte no número (quantidade) de inteiros pares existentes
> em bagOfInts.
> - Expressão que resulte num IEnumerable\<int> só com múltiplos de 10.

```c#
bagOfInts.Select(i => i.IsEven()).Count();
bagOfInts.Where(i => i.IsMultipleOf(10));
```

- [X] `1.4`

> Qual teria de ser o tipo da variável bagOfIntsOrNulls de modo a que possa
> também conter também nulls?

```c#
IEnumerable<int?>
```

- [X] `1.5`

> Considerando que a variável bagOfIntsOrNulls é do tipo que indicaste na alínea
> anterior, escreve uma expressão, usando expressões Lambda e LINQ, que indique
> se o enumerável contém ou não nulls.

```c#
bagOfIntsOrNull.Any(i => !i.HasValue);
```

- [X] `1.6`

> Escreve o código para percorrer todos os elementos de bagOfIntsOrNulls e somar
> todos os seus valores na variável total, do tipo int, assumindo que a mesma
> foi previamente declarada e inicializada a zero. Os nulls devem ser
> considerados como tendo o valor zero para efeitos da soma. Usa, sempre que
> possível, operadores para tratamento de nulls.

```c#
foreach (int? i in bagOfIntsOrNulls)
    total += i ?? 0;
```

- [X] `2`

> Modifica a seguinte linha do seguinte código de modo a que respeite o
> dependency inversion principle, tendo em conta que a coleção em questão terá
> de suportar a adição, remoção e contagem de itens:
>
> ```c#
> List<string> containerOfStrings = new List<string>();
> ```
>
> Justifica a tua resposta.

```md
ICollection<string> containerOfStrings = new List<string>();

Uma vez que o Dependency Inversion Principle suporta que devemos depender de
abstrações e não de concretizações, a melhor hipótese é a interface ICollection<T>,
uma vez que possui os membros mais abstratos possíveis para adicionar, remover
e contar itens.
```

- [ ] `3`

> Considera a classe:
>
> ```c#
>   public class PlayerStats : MonoBehaviour
>   {
>       private Player player;
>
>       private void Awake()
>       {
>           player = GameObject.FindWithTag("Player").GetComponent<Player>();
>       }
>
>       private void UpdatePowerUpStats(float powerUpMagnitude)
>       {
>           // Código que atualiza as estatísticas de power-ups do player
>       }
>   }
> ```

- [ ] `3.1`

> Indica um delegate pré-definido do C# compatível com o método UpdatePowerUpStats.

```c#
Action<float>
```

- [ ] `3.2`

> Considera que a classe Player tem um evento nativo do C# chamado PickedUpAPowerUp.
> Completa a classe PlayerStats de modo a que o método UpdatePowerUpStats seja
> notificado desse evento quando a respetiva instância de PlayerStats estiver ativa.

```c#
private void OnEnable() => player.PickedUpAPowerUp += UpdatePowerUpStats;
```

- [ ] `3.3`

> Que design pattern é explicitamente implementado pelos eventos do C#?
> Explica o teu raciocínio.

```md
Os eventos de C# explicitamente implementam o Observer pattern, de uma forma mais
simples, porque quando uma classe subscreve a um evento de outra classe é como se
se registasse como um observador da classe com o evento, que seria o sujeito.
Para além disso, da mesma forma que subscreve um evento e se regista como um
observador, sendo notificado sempre que um evento é lançado, pode também remover
a subscrição e parar de ser notificado.
```

## VERSÃO 2 - `B9A26`

- [X] `1`

> Que princípio de programação orientada a objetos está a ser violado pelo
> seguinte método? Justifica a tua resposta e indica como podes corrigir a situação.
>
> ```c#
>   public static float Average(List<int> values)
>   {
>       float sum = 0f;
> 
>       foreach (int n in values)
>           sum += n;
>
>       return sum / values.Count;
>   }
> ```

```md
O principio a ser violado neste método é o Dependency Inversion Principle, uma
vez que não precisamos de depender de uma List<int>. 

Só precisamos de iterar e contar os valores recebidos, e para isso chegaria usar
um ICollection<int>, sem alterar o código. 

Outra maneira ainda mais abstrata, seria usar um IEnumerable<int> e values.Count
poderia ser substituído por uma variável int count, inicializada a 0 e
incrementada em cada iteração do foreach.
```

- [X] `2`

> Considera a classe:
>
> ```c#
>   public class Player : MonoBehaviour
>   {
>       // outras partes do código ...
> 
>       private void OnTriggerEnter(Collider other)
>       {
>           if (other.tag == "PowerUp")
>               // Evento lançado aqui.
>       }
>
>       // outras partes do código ...
>       public event Action<float> PickedUpAPowerUp;
>   }
> ```

- [X] `2.1`

> Cria um método cujo único propósito seja lançar o evento PickedUpAPowerUp,
> seguindo as boas práticas para o efeito. Este método é invocado, por exemplo,
> na linha de código que diz “// Evento lançado aqui”

```c#
protected virtual OnPickedUpAPowerUp() => PickedUpAPowerUp?.Invoke();
```

- [X] `2.2`

> Identifica o uso de delegates no código apresentado, indicando se os mesmos
> (caso existam) são ou não nativos do C#.

```md
O evento usa o delegate Action<float>, overload do delegate nativo do C#, Action.
```

- [ ] `2.3`

> Que design pattern é explicitamente implementado pelos eventos do C#?
> Explica o teu raciocínio.

```md
Os eventos de C# explicitamente implementam o Observer pattern, de uma forma mais
simples, porque quando uma classe subscreve a um evento de outra classe é como se
se registasse como um observador da classe com o evento, que seria o sujeito.
Para além disso, da mesma forma que subscreve um evento e se regista como um
observador, sendo notificado sempre que um evento é lançado, pode também remover
a subscrição e parar de ser notificado.
```

- [X] `3.1`

> Escreve o código dos seguintes métodos de extensão para int, bem como da
> classe que os contém:
>
> - **bool IsOdd()** – Devolve true se inteiro for ímpar, false caso contrário.
> - **bool IsZeroOrNegative()** – Devolve true se inteiro for zero ou negativo,
> false caso contrário.
> - **bool IsDivisorOf(int otherInt)** – Devolve true se inteiro for divisor
> do inteiro passado como argumento, false caso contrário.

```c#
public static class IntExtensions
{
    public static bool IsOdd(this Int32 i) => (i % 2 != 0);

    public static bool IsZeroOrNegative(this Int32 i) => (i <= 0);

    public static bool IsDivisorOf(this Int32 i, int otherInt) => otherInt % i == 0;
}
```

- [X] `3.2`

> Considera o inteiro 7. Como invocarias o método IsDivisorOf(14) nesse valor?
> E qual seria o resultado?

```c#
7.IsDivisorOf(14);

O resultado seria true.
```

- [X] `3.3`

> Considera a variável lotsOfInts do tipo IEnumerable\<int>. Usando expressões
> Lambda e LINQ, escreve as seguintes expressões:
>
> - Expressão que resulte no número (quantidade) de inteiros ímpares existentes
> em lotsOfInts.
> - Expressão que resulte num IEnumerable\<int> só com divisores de 100.

```c#
bagOfInts.Count(i => i.IsOdd());
bagOfInts.Where(i => i.IsDivisorOf(100));
```

- [X] `3.4`

> Qual teria de ser o tipo da variável lotsOfIntsOrNulls de modo a que possa
> também conter também nulls?

```c#
IEnumerable<int?>
```

- [X] `3.5`

> Considerando que a variável lotsOfIntsOrNulls é do tipo que indicaste na alínea
> anterior, escreve uma expressão, usando expressões Lambda e LINQ, que indique
> se o enumerável contém ou não nulls.

```c#
lotsOfIntsOrNull.Any(i => !i.HasValue);
```

- [X] `3.6`

> Escreve o código para percorrer todos os elementos de lotsOfIntsOrNulls e multiplicar
> todos os seus valores na variável product, do tipo int, assumindo que a mesma
> foi previamente declarada e inicializada a zero. Os nulls devem ser
> considerados como tendo o valor um para efeitos da soma. Usa, sempre que
> possível, operadores para tratamento de nulls.

```c#
foreach (int? i in lotsOfIntsOrNulls)
    product *= i ?? 1;
```
