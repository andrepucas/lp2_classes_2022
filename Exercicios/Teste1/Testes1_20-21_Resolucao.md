# Resolução Testes 1 (20/21)

## `VERSÃO A590DB`

- [ ] `1`

```md
Sim, porque ambos os seus membros são propriedades apenas de leitura e que apenas
podem ser definidos no construtor. Para além disso, é uma classe sealed, o que
significa que não pode ser herdada por nenhuma outra classe.
```

- [ ] `2`

```c#
Resources, DefensiveBonus e MovementCost.
```

- [ ] `3`

```c#
Console.WriteLine(mountains.MovementCost);
```

- [ ] `4`

```c#
private IEnumerable<Resource> GetExpensiveResources(float minCost = 2)
{
    foreach(Resource resource in Resources)
    {
        if (resource.Cost > minCost)
            yield return resource;
    }
}
```

- [ ] `5`

```md
Não, uma vez que depende da propriedade de instância Resources.
```

- [ ] `6`

```c#
public class HillTile : GameTile
{
    public override IEnumerable<Resource> Resources => _resourcesList;

    private List<Resource> _resourcesList;
    
    public HillTile(int _defensiveBonus)
    {
        _resourcesList = new List<Resource>();

        base.DefensiveBonus = _defensiveBonus;
        base.MovementCost = 2;
    }

    public override void AddResource(Resource resource)
    {
        _resourcesList.Add(resource);
    }
}
```

- [ ] `7`

```c#
public override int GetHashCode() => 
    Cost.GetHashCode() ^ Name.GetHashCode();

public override bool Equals(object obj)
{
    Resource other = obj as Resource;

    if (obj is null) return false;

    else return Cost == other.Cost && Name == other.Name;
}
```

- [X] `8`

![UML_20-21_1590DB_V3](https://github.com/andrepucas/lp2_classes_2022/blob/main/Exercicios/Support/UML_20-21_A590DB_V3.png)

## `VERSÃO B0102F`

- [ ] `1`

```md
Não, porque se trata de uma classe abstrata. Apenas uma subclasse não abstrata
da mesma poderia ser instanciada.
```

- [ ] `2`

```c#
AddResource(Resource resource)
```

- [ ] `3`

```c#
Console.WriteLine(GameTile.MaxDefensiveBonus);
```

- [X] `4`

```c#
public abstract class GameTile
{
    public float TotalCost 
    {
        get
        {
            float _totalCost = 0;
            foreach(Resource r in Resources) _totalCost += r.Cost;
            return _totalCost;
        }
    }
}
```

```md
Sim, porque o total cost é calculado com base nos recursos existentes.
```

- [X] `5`

```md
Não, porque o valor total do custo de todos os recursos não será igual para 
todas as instâncias das subclasse de GameTile.
```

- [X] `6`

```c#
public class DesertTile : GameTile
{
    public override IEnumerable<Resource> Resources => _resourcesList;

    private List<Resource> _resourcesList;

    public DesertTile(int p_defensiveBonus, int p_movementCost = 3)
    {
        _resourcesList = new List<Resource>();

        if (p_defensiveBonus > base.MaxDefensiveBonus)
            p_defensiveBonus = base.MaxDefensiveBonus;

        base.DefensiveBonus = p_defensiveBonus;
        base.MovementCost = p_movementCost;
    }
    
    public override void AddResource(Resource resource)
    {
        _resourcesList.Add(resource);
    }
}
```

- [X] `7`

```c#
public abstract class GameTile : IComparable<GameTile>
{
    (...)

    public int CompareTo(GameTile other)
    {
        if (other == null) return 1;
        if (TotalCost > other.TotalCost) return -1;
        if (TotalCost < other.TotalCost) return 1;
        return 0;
    }
}
```

- [X] `8`

![UML_20-21_B0102F_V3](https://github.com/andrepucas/lp2_classes_2022/blob/main/Exercicios/Support/UML_20-21_B0102F_V3.png)
