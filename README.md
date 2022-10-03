# Aulas de LP2 (2022)

+ [Aula 1 (27/09)](#aula-1-2709)
+ [Aula 2 (04/10)](#aula-2-0410)

---

## Aula 1 (27/09)

### Exercício 2 - Variáveis e Métodos

#### 2.1. Possíveis variáveis e métodos para a classe Cat

> **Vars:** Name, Age, Color, Weight, Owner  
> **Métodos:** SetName(), GetAge(), GetColor(), SetOwner().

#### 2.2. Uma das variáveis deve ser enum

> Enum Color {Black, White, Orange, Striped}

### Usar Static

**Apenas para variáveis da classe, independentes da instância.**

Numa classe 'Cat', a variável 'NumberOfCats' seria igual para todas as instâncias,
portanto faz sentido ser uma variável da classe - static.

Métodos static são chamados diretamente na classe, em vez de na instância.
Exemplo: Console.WriteLine, Debug.Log.

São apenas úteis se não dependerem do estado da instância e se nunca for preciso
alterar diretamente.

[Back](#aulas-de-lp2-2022)

---

## Aula 2 (04/10)

### Exercício 1 - Classes

#### 1.1. Classes são tipos de referencia

> True.

#### 1.2. Classes vs Instâncias

> 'Classes' definem o que algo pode fazer e guardar, enquanto uma 'instância' é um objeto especifico que contém o seu próprio estado.

#### 1.3. Quatro tipos de membros que podem pertencer a uma classe

> Variáveis, Propriedades, Métodos, Construtor.

#### 1.4. Algo static é partilhado por todas as instâncias desse tipo?

> True.

#### 1.5. Como se chamam os métodos que inicializam uma classe?

> Métodos construtores.

#### 1.6. De onde se pode aceder a algo private?

> Apenas dentro da classe.

#### 1.7. De onde se pode aceder a algo protected?

> Dentro da classe e classes derivadas (subclasses).

#### 1.8. De onde se pode aceder a algo public?

> De qualquer sítio.

#### 1.9. De onde se pode aceder a algo internal?

> Dentro do mesmo projeto.

### Exercício 2 - Revisão de termos (CatFromLastWeek)

#### Classes

> Cat, Program, Feed, Mood.

#### Instâncias criadas

> cat1 e cat2, de Cat.

#### Métodos

> Cat: RandomMoods(), Eat(), Sleep(), Play(), Meow().  
> Program: Main(), ShowCat().

#### Construtores

> Cat(), Cat(:all params:), Cat(string name).

#### Variáveis de Instância

> energy, feedStatus, random, possibleFeedStatus, possibleMoods.

#### Variáveis de Classe

> N/A.

#### Propriedades da Classe

> MaxEnergy, EnergyGainAfterSleep, EnergyLossAfterPlay, EnergyLossAfterMeow.

#### Propriedades de Instância

> Name, Energy, FeedStatus, MoodStatus.

#### Variáveis de Suporte

> energy, feedStatus.

#### Variáveis Locais

> numMoods, i... O que estiver dentro de métodos.

#### Overloading

> No construtor de Cat.

#### Encapsulação

> ion know.

[Back](#aulas-de-lp2-2022)
