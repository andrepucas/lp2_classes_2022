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

- [ ] `2.1`

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

- [ ]  `2.2`

```md
Ana is a Tank
Paulo is a Slayer
```

- [ ] `2.3`

```md
Se Player fosse uma struct, então seria considerado "igual" se todos os
valores da struct fossem iguais. Portanto, não seriam necessários os overrides.
```

## `VERSÃO 4AB92`

- [ ] `1.1`

```c#
public static ICollection<T> GetArray<T>(int size = 10, params T[] values)
{
    T[] array = new T[size];

    for (int i = 0; i < values.Length; i++)
        array[i] = values[i];

    for (int i = values.Length+1; i < size; i++)
        array[i] = default;

    return array;
}
```

- [ ] `1.2`

```c#
int[]  arrayOfInts = GetArrayOf<int>();
int[]  arrayOf5DefaultInts = GetArrayOf<int>(5);
int[]  arrayOf5SetInts = GetArrayOf<int>(5, 1, 2);
bool[] arrayOf3Bools = GetArrayOf<bool>(3, false, true, true);
bool[] arrayOf10FalseBools = GetArrayOf<bool>();
```

- [X] `2.1` `2.2` `2.3`

> Iguais à [versão anterior](#versão-185a2)
