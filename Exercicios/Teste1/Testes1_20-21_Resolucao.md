# Resolução Testes 1 (20/21)

## `VERSÃO A590DB`

- [ ] `1`

```md
Sim, porque ambos os seus membros são propriedades apenas de leitura e que apenas
podem ser definidos no construtor. Para além disso, é uma classe sealed, o que
significa que não pode ser herdada por nenhuma outra classe.
```

- [ ] `2`

```md
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
    public override IEnumerable<Resource> Resources
    {
        get => _resources;
    }


    private List<Resource> _resources;
    
    public HillTile(int _defensiveBonus)
    {
        _resources = new List<Resource>();

        base.DefensiveBonus = _defensiveBonus;
        base.MovementCost = 2;
    }

    public override void AddResource(Resource resource)
    {
        _resources.Add(resource);
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

- [ ] `8`

![UML_20-21_1590DB_V2](https://github.com/andrepucas/lp2_classes_2022/blob/main/Exercicios/Support/UML_20-21_A590DB_V2.png)
