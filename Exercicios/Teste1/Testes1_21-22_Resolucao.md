# Resolução Testes 1 (21/22)

## `VERSÃO A16BE`

- [ ] `1`

```md
Membros de instância são a variável name, a propriedade Health e o método Die.
Membros de classe são a propriedade static NumberOfEnemies e o método 
construtor Enemy.
```

- [ ] `2`

```md
Não, tanto name como Health podem ambos ser alterados depois de instanciados
(dentro da classe).
```

- [ ] `3`

```md
Sim, uma vez que a classe não tem as keywords sealed ou static.
```

- [ ] `4`

```md
Sim, a classe não é abstrata e por isso pode ser instanciada.
```

- [X] `5`

```c#
Console.WriteLine(beast.Health);
Console.WriteLine(Enemy.NumberOfEnemies);
```

- [X] `6`

```md
Porque o seu valor é partilhado entre todas as instâncias de Enemy.
```

- [X] `7`

```md
Apenas dentro da classe Enemy, uma vez que tem um private set.
```

- [ ] `8`

```c#
public class Enemy
{
    public string ReverseName
    {
        get
        {
            string reverse = String.Empty;

            for (int i = name.Length - 1, i >= 0; i--)
                reverse += name[i];

            return reverse;
        }
    }
}
```

- [ ] `9`

```c#
public int BetterThan(IEnumerable<Enemy> otherEnemies)
{
    int count = 0;

    foreach(Enemy other in otherEnemies)
        if (other.Health < Health) count++;

    return count;
}
```

- [ ] `10`

```md
Não, uma vez que depende da propriedade de instância Health.
```

- [ ] `11`

```c#
public class Thanos : Enemy
{
    public override int Health => base.Health * 2;

    public Thanos() : base(name: "THANOS", health: 150) {}
}
```

- [ ] `12`

![UML_21-22_A16BE](https://github.com/andrepucas/lp2_classes_2022/blob/main/Exercicios/Support/UML_21-22_A16BE.png)
