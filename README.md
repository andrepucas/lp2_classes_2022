# Aulas de LP2 (2022)

+ [Aula 1 (27/09)](#aula-1-2709)
+ [Aula 2 (04/10)](#aula-2-0410)

---

## Aula 1 (27/09)

### Exercício 2 - Variáveis e Métodos

1. Possíveis variáveis e métodos para a classe Cat

    > **Vars:** Name, Age, Color, Weight, Owner  
    > **Métodos:** SetName(), GetAge(), GetColor(), SetOwner().

2. Uma das variáveis deve ser enum

    > Enum Color {Black, White, Orange, Striped}

> ### Usar Static
>
> **Apenas para variáveis da classe, independentes da instância.**
>
> Numa classe 'Cat', a variável 'NumberOfCats' seria igual para todas as instâncias,
portanto faz sentido ser uma variável da classe - static.
>
> Métodos static são chamados diretamente na classe, em vez de na instância.
Exemplo: Console.WriteLine, Debug.Log.
>
> São apenas úteis se não dependerem do estado da instância e se nunca for preciso
alterar diretamente.

[Back](#aulas-de-lp2-2022)

---

## Aula 2 (04/10)

### Exercício 1 - Classes

1. Classes são tipos de referencia

    > True.

2. Classes vs Instâncias

    > 'Classes' definem o que algo pode fazer e guardar, enquanto uma 'instância' é um objeto especifico que contém o seu próprio estado.

3. Quatro tipos de membros que podem pertencer a uma classe

    > Variáveis, Propriedades, Métodos, Construtor.

4. Algo static é partilhado por todas as instâncias desse tipo?

    > True.

5. Como se chamam os métodos que inicializam uma classe?

    > Métodos construtores.

6. De onde se pode aceder a algo private?

    > Apenas dentro da classe.

7. De onde se pode aceder a algo protected?

    > Dentro da classe e classes derivadas (subclasses).

8. De onde se pode aceder a algo public?

    > De qualquer sítio.

9. De onde se pode aceder a algo internal?

    > Dentro do mesmo projeto.

### Exercício 2 - Revisão de termos (CatFromLastWeek)

1. Classes

    > Cat, Program.

2. Instâncias criadas

    > cat1 e cat2, de Cat.

3. Métodos

    > Cat: RandomMoods(), Eat(), Sleep(), Play(), Meow().  
    > Program: Main(), ShowCat().

4. Construtores

    > Cat(), Cat(:all params:), Cat(string name).

5. Variáveis de Instância

    > energy, feedStatus, random, possibleFeedStatus, possibleMoods.

6. Variáveis de Classe

    > N/A.

7. Propriedades da Classe

    > MaxEnergy, EnergyGainAfterSleep, EnergyLossAfterPlay, EnergyLossAfterMeow.

8. Propriedades de Instância

    > Name, Energy, FeedStatus, MoodStatus.

9. Variáveis de Suporte

    > energy, feedStatus.

10. Variáveis Locais

    > moods, numMoods, i... O que estiver dentro de métodos.

11. Overloading

    > Nos construtores de Cat.

12. Encapsulação

    > Propriedades publicas com private set, readonly por outras classes.

> ### Instanciar com propriedades (Sem construtor)
>
> `Player p1 = new Player{Health = 100, Armor = 50}`

### Exercício 5 - Structs e Imutabilidade

1. Structs são tipos de valor ou referência?

    > Valor.

2. É fácil/recomendado alterar uma classe para struct ou vice-versa a meio de um programa?

    > Não.

3. Structs são sempre imutáveis?

    > Não.
4. Classes nunca são imutáveis?

    > Não.

5. Todos os tipos pré definidos no C# são structs?

    > Não.

### Exercício 6 - Keywords out e ref

1. Parâmetro `out` indica que foi passada uma referencia ao valor, em vez de uma cópia?

    > Sim.

2. Parâmetro `ref` indica que foi passada uma referencia ao valor, em vez de uma cópia?

    > Sim.

3. Parâmetro `out` tem de ser inicializado dentro do método?

    > Sim.

4. Parâmetro `ref` tem de ser inicializado dentro do método?

    > Não.

> ### UML - Cardinalidade
>
> Em associação, agregação e composição, o lado da classe que tem (de onde sai a seta), normalmente é sempre 1.

### Exercício 8 - Herança

1. Uma classe derivada adiciona funcionalidade a uma class base?

    > Sim, é para isso que serve.

2. Todos os membros da superclasse são acessíveis pela subclasse?

    > Só se não forem private.+-

3. Structs suportam herança?

    > Não.

4. Todas as classes derivam de object?

    > Sim.

5. Uma classe pode ser subclasse E superclasse?

    > Sim.

6. É possível evitar que uma classe seja usada como classe base?

    > Sim, com a keyword `sealed` ou se for uma classe `static`.

### Exercício 11 - Polimorfismo

1. Polimorfismo permite que subclasses ofereçam implementações alternativas de métodos da classe base.

    > Sim.

2. Keyword `override` indica que um método na subclasse é uma extensão/sobreposição de um método na classe base.

    > Sim.

3. Keyword `new` indica que um método na subclasse é uma extensão/sobreposição de um método na classe base.

    > Não.

4. Métodos `abstract` podem existir em classes não-`abstract`.

    > Não.

5. Métodos não-`abstract` podem existir em classes `abstract`.

    > Sim.

6. Subclasses podem sobrepor métodos `virtual` da superclasse.

    > Sim.

7. Subclasses podem sobrepor métodos `abstract` da superclasse.

    > Sim, não só podem como são obrigados.

8. Numa subclasse é possível dar `override` de um método não-`virtual` e não-`abstract` da superclasse.

    > Não.

9. O método `ToString()` de object não pode ser sobreposto.

    > Não, até é recomendado ser sobreposto.

[Back](#aulas-de-lp2-2022)
