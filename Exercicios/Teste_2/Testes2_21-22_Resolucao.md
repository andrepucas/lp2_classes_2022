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
(4).IsMultipleOf(3);

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
protected virtual void OnPickedUpAPowerUp() => PickedUpAPowerUp?.Invoke();
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
(7).IsDivisorOf(14);

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

## VERSÃO 3 - `C41DA`

- [X] `1`

> Considera a seguinte enumeração:
>
> ```c#
>   enum Monster { Troll, Ogre, Elf, Demon, Vampire, Werewolf, Minion}
> ```

- [X] `1.1`

> Declara uma lista de Monster na qual seja possível também introduzir nulls.

```c#
List<Monster?> monstersList;
```

- [X] `1.2`

> Assume que a variável 'monst' é do tipo Monster. Escreve uma linha de código
> onde atribuis à variável 'monst' o valor do primeiro elemento da lista da
> alínea anterior, tendo em conta que se este valor for null, o valor
> efetivamente a atribuir será Minion.

```c#
monst = monstersList?[0] ?? Monster.Minion;
```

- [X] `1.3`

> Escreve o código de um método que receba a lista da primeira alínea e devolva
> um inteiro indicando quantos nulls existem na lista. O método deve ser o mais
> compacto possível, fazendo uso de Lambdas e LINQ.

```c#
private static int HowManyNullsIn(List<Monster?> list) => list.Count(m => !m.HasValue);
```

- [ ] `2`

> Estás a desenvolver um jogo em que uma arma pode realizar uma ou mais ações
> durante um ataque, sem qualquer ordem pré-definida e podendo inclusive repetir
> ações, dentro das seguintes possibilidades:
>
> - ParticleSmoke() - Aplicar um efeito de partículas semelhante a fumo devido
> ao disparo.
> - ParticleFire() - Aplicar um efeito de partículas que represente o disparo de
> uma bala.
> - EnemyDamage() - Aplicar dano ao inimigo.
> - Cooldown() - Aplicar um tempo de cooldown.
> - WeaponDamage() - Aplicar dano à arma.
> - PlayerDamage() - Aplicar dano infligido pela arma no próprio jogador (e.g.
> devido a backfire).
>
> Numa primeira versão o jogo terá duas armas, **sword** e **shotgun**.

- [ ] `2.1`

> Que design pattern te parece mais apropriado para resolver este problema?
> Justifica a tua resposta.

```md
Uma boa hipótese pode ser o Subclasses Sandbox, uma vez que permite ter todos
esses comportamentos base numa classe base, que depois as armas especificas
(como sword e shotgun, nesta fase) estendem como subclasses e usam apenas os
comportamentos que lhes interessa, na ordem e as vezes que quiserem.
```

- [ ] `2.2`

> Apresenta o diagrama UML completo de uma possível solução, contendo a
> informação mínima e necessária que realce o pattern utilizado. Em particular,
> indica se os métodos têm implementações por omissão ou são abstract.

![T2_V3 UML](Imagens/uml_t2v3.png "UML Completo")

- [ ] `3`

> Considera a seguinte classe:
>
> ```c#
> public static class VectorOps
> {
>     // Convert angle in degrees into normalized vector
>     public static Vector2 Deg2Vec(float angle)
>     {
>         float angleRad = angle * Mathf.Deg2Rad;
>         return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
>     }
> 
>     // Determine angle of vector in degrees
>     public static float Vec2Deg(Vector2 vector)
>     {
>         return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
>     }
> 
>     // Normalized direction between two game objects
>     public static Vector2 Direction(Vector2 from, Vector2 to)
>     {
>         return (to - from) / (to - from).magnitude;
>     }
> 
>     // Distance between two game objects
>     public static float Distance(Vector2 obj1, Vector2 obj2)
>     {
>         return (obj1 - obj2).magnitude;
>     }
> }
> ```

- [ ] `3.1`

> Simplifica os métodos usando lambdas.

```c#
public static Vector2 Deg2Vec(float angle) => 
    new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

public static float Vec2Deg(Vector2 vector) => 
    Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

public static Vector2 Direction(Vector2 from, Vector2 to) =>
    (to - from) / (to - from).magnitude;

public static float Distance(Vector2 obj1, Vector2 obj2) => 
    (obj1 - obj2).magnitude;
```

- [ ] `3.2`

> Indica, para cada método, um delegate pré-definido do C# que seja compatível.

```c#
// Vector2 Deg2Vec(float)
Func<float, Vector2>

// float Vec2Deg(Vector2)
Func<Vector2, float>

// Vector2 Direction(Vector2, Vector2)
Func<Vector2, Vector2, Vector2>

// float Distance(Vector2, Vector2)
Func<Vector2, Vector2, float>
```

- [ ] `3.3`

> Assumindo que estás num método noutra classe, escreve quatro linhas de código
> nas quais declaras quatro variáveis do tipo delegate pré-definido que indicaste
> na alínea anterior, atribuindo-lhes o respetivo método compatível.

```c#
Func<float, Vector2> deg2vec = VecMethods.Deg2Vec;
Func<Vector2, float> vec2deg = VecMethods.Vec2Deg;
Func<Vector2, Vector2, Vector2> direction = VecMethods.Direction;
Func<Vector2, Vector2, float> distance = VecMethods.Distance;
```

## VERSÃO 4 - `DFBA3`

- [ ] `1`

> Considera a seguinte classe:
>
> ```c#
> public static class VecMethods
> {
>     // Normalized direction between two game objects
>     public static Vector2 Direction(Vector2 from, Vector2 to)
>     {
>         return (to - from) / (to - from).magnitude;
>     }
> 
>     // Distance between two game objects
>     public static float Distance(Vector2 obj1, Vector2 obj2)
>     {
>         return (obj1 - obj2).magnitude;
>     }
>
>     // Convert angle in degrees into normalized vector
>     public static Vector2 Deg2Vec(float angle)
>     {
>         float angleRad = angle * Mathf.Deg2Rad;
>         return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
>     }
> 
>     // Determine angle of vector in degrees
>     public static float Vec2Deg(Vector2 vector)
>     {
>         return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
>     }
> }
> ```

- [ ] `1.1`

> Simplifica os métodos usando lambdas.

```c#
public static Vector2 Direction(Vector2 from, Vector2 to) =>
    (to - from) / (to - from).magnitude;

public static float Distance(Vector2 obj1, Vector2 obj2) => 
    (obj1 - obj2).magnitude;

public static Vector2 Deg2Vec(float angle) => 
    new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

public static float Vec2Deg(Vector2 vector) => 
    Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
```

- [ ] `1.2`

> Indica, para cada método, um delegate pré-definido do C# que seja compatível.

```c#
// Vector2 Direction(Vector2, Vector2)
Func<Vector2, Vector2, Vector2>

// float Distance(Vector2, Vector2)
Func<Vector2, Vector2, float>

// Vector2 Deg2Vec(float)
Func<float, Vector2>

// float Vec2Deg(Vector2)
Func<Vector2, float>
```

- [ ] `1.3`

> Assumindo que estás num método noutra classe, escreve quatro linhas de código
> nas quais declaras quatro variáveis do tipo delegate pré-definido que indicaste
> na alínea anterior, atribuindo-lhes o respetivo método compatível.

```c#
Func<Vector2, Vector2, Vector2> direction = VecMethods.Direction;
Func<Vector2, Vector2, float> distance = VecMethods.Distance;
Func<float, Vector2> deg2vec = VecMethods.Deg2Vec;
Func<Vector2, float> vec2deg = VecMethods.Vec2Deg;
```

- [X] `2`

> Considera a seguinte enumeração:
>
> ```c#
> enum Star { RedDwarf, BrownDwarf, WhiteDwarf, SubGiant, Giant, SuperGiant, HyperGiant }
> ```

- [X] `2.1`

> Declara uma lista de Star na qual seja possível também introduzir nulls.

```c#
List<Star?> starsList;
```

- [X] `2.2`

> Assume que a variável 'star' é do tipo Star. Escreve uma linha de código
> onde atribuis à variável 'star' o valor do primeiro elemento da lista da
> alínea anterior, tendo em conta que se este valor for null, o valor
> efetivamente a atribuir será RedDwarf.

```c#
star = starsList?[0] ?? Star.RedDwarf;
```

- [X] `2.3`

> Escreve o código de um método que receba a lista da primeira alínea e devolva
> um inteiro indicando quantos nulls existem na lista. O método deve ser o mais
> compacto possível, fazendo uso de Lambdas e LINQ.

```c#
private static int HowManyNullsIn(List<Star?> list) => list.Count(s => !m.HasValue);
```

- [ ] `3`

> Estás a desenvolver um jogo em que os passos seguidos por uma arma ao realizar
> um ataque são sempre os mesmos, nomeadamente:
>
> 1. DecAmmo() - Decrementar munições (dependendo de quantas foram gastas).
> 2. ProbSuccess() - Determinar probabilidade de sucesso.
> 3. EnemyDamage() - Determinar estrago infligido no inimigo.
> 4. Cooldown() - Determinar tempo de cooldown.
>
> Existem diferentes tipos de arma, que apesar de seguirem estes quatro passos
> durante um ataque, poderão personalizá-los de formas distintas. É expectável
> que o tempo de cooldown para a maior parte das armas seja zero. Numa primeira
> versão o jogo terá duas armas, **melee** e **pistol**. A arma melee tem tempo
> de cooldown igual a zero.

- [ ] `3.1`

> Que design pattern te parece mais apropriado para resolver este problema?
> Justifica a tua resposta.

```md
Uma boa hipótese pode ser o Template Method, uma vez que permite todas as armas
seguirem os mesmos passos gerais através de uma classe base 'Weapon' que define
quais os passos (métodos) que uma arma deve executar e em qual ordem,
juntamente com subclasses de armas específicas, que personalizam os métodos como
entenderem.
```

- [ ] `3.2`

> Apresenta o diagrama UML completo de uma possível solução, contendo a
> informação mínima e necessária que realce o pattern utilizado. Em particular,
> indica se os métodos têm implementações por omissão ou são abstract.

![T2_V4 UML](Imagens/uml_t2v4.png "UML Completo")
