# Resolução Testes 1 (18/19)

## `VERSÃO D29EB`

- [X] `1.1`

```c#
Console.WriteLine(monster.Health);
Console.WriteLine(Enemy.NumberOfEnemies);
```

- [X] `1.2`

```md
Porque é igual para todas as instâncias de Enemy.
```

- [X] `1.3`

```md
Apenas dentro da classe Enemy, uma vez que a propriedade tem um private set.
```

- [X] `2.1`

```md
Sim, as constantes MaxHealth e MaxStrength são static por omissão, uma vez que
este valor será partilhado por todas as instâncias de Monster.
```

- [X] `2.2`

```c#
private static IEnumerable<Monster> CreateRandomMonsters(int n)
{
    Random rnd = new Random();
    Monster randomMonster = new Monster();

    for (int i = 0; i < n; i++)
    {
        randomMonster.Type = (MonsterType)rnd.Next(0,4);
        randomMonster.Health = rnd.NextDouble() * MaxHealth;
        randomMonster.Strength = rnd.Next(MaxStrength+1);
        yield return randomMonster;
    }
}
```

- [X] `2.3`

```md
Sim, uma vez que serve para criar instâncias, faz sentido portanto não
precisar de uma para ser instanciado. Para além disso, o método não usa
nenhum membro de instância.
```

- [X] `2.4`

```c#
public override string ToString() => 
    $"Type: {Type, -10} | Health: {Health, 8:f2} | Strength {Strength, 8}";
```

- [X] `2.5`

```c#
IEnumerable<Monster> randMonsters = Monster.CreateRandomMonster(20);
foreach(Monster m in randMonsters) Console.WriteLine(m);
```

## `VERSÃO 185A2`

- [X] `1`

```c#
public class Star : ILightSource, IComparable<T>
{
    public double Illuminance {get;}
    private const double d = 5.670E-8;

    public float A {get;}
    public float T {get;}
    
    public Star(float a, float t)
    {
        A = a;
        T = t;
        Illuminance = d * A * Math.Pow(t, 4);
    }

    public int CompareTo(Star other)
    {
        if (other == null) return 1;
        else return (int)(other.A - A);
    }
}
```

- [X] `2.1`

```c#
public override int GetHashCode() => 
    Type.GetHashCode() ^ Name.GetHashCode();

public override bool Equals(object obj)
{
    Player other = obj as Player;

    if (obj is null) return false;
    return Type == other.Type && Name == other.Name;
}
```

- [X]  `2.2`

```md
Ana is a Tank
Paulo is a Slayer
```

- [X] `2.3`

```md
Se Player fosse uma struct, então seria considerado "igual" se todos os
valores da struct fossem iguais. Portanto, não seriam necessários os overrides.
```

## `VERSÃO 4AB92`

- [X] `1.1`

```c#
public static T[] GetArray<T>(int size = 10, T value = default)
{
    T[] array = new T[size];

    for (int i = 0; i < size; i++) 
        array[i] = value;

    return array;
}
```

- [X] `1.2`

```c#
Array _5buildings = GetArray<Building>(5);
Array _10intsOf3 = GetArray<int>(value: 3);
Array _10floatsOf0 = GetArray<float>();
Array _10boolsFalse = GetArray<bool>();
Array _7boolsTrue = GetArray<bool>(7, true);
```

- [X] `2.1` `2.2` `2.3`

> Iguais à [versão anterior](#versão-185a2)

## `VERSÃO CF625`

- [X] `1.1`

```c#
public class Sword : GameItem
{
    private float _length;
    private WeaponCondition _condition;

    public Sword(string p_name, string p_description, float p_length, 
        WeaponCondition p_condition) : base(p_name, p_description)
    {
        _length = p_length
        _condition = p_condition;
    }
}
```

- [X] `1.2`

```c#
public enum WeaponCondition
{
    Perfect,
    Good,
    Decent,
    Poor,
    Destroyed
}
```

- [X] `1.3`

```c#
Sword sword = new Sword("sword", "a fine weapon", 60, WeaponCondition.Perfect);
```

- [X] `1.4`

```md
Neste caso não é tão grave uma vez que se tratam de valores readonly que só podem
ser alterados no construtor. Por isso, após serem instanciadas tornam-se imutáveis.
```

- [X] `1.5`

```md
Não, uma vez que se trata de uma classe abstrata.
```

- [X] `2.1`

```c#
public static IEnumerable<T> GetNCopies<T>(int size, T value)
{
    T[] array = new T[size];

    for (int i = 0; i < size; i++) 
        array[i] = value;

    return array;
}
```

- [X] `2.2`

```md
Para poder ser usado sem uma instância e porque não depende de nenhum membro de
instância.
```
