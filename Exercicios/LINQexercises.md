# LINQ Exercises

1. [Number of tiles without resources](#1-number-of-tiles-without-resources)
2. [Average coin of Mountain tiles](#2-average-coin-in-mountain-tiles)
3. [List of terrains, ordered](#3-list-of-existing-terrains-alphabetically)
4. [Tile with least coin](#4-tile-with-least-coin)
5. [Number of unique tiles](#5-number-of-unique-tiles)
6. [Number of all resources](#6-number-of-all-resources)
7. [Number of metal resources](#7-number-of-all-metal-resources)
8. [Top 3 Tiles with most food (positions)](#8-top-3-tiles-with-most-food-positions)
9. [Number of equal tiles](#9-number-of-equal-tiles)

## 1. Number of tiles without resources

```cs
// Displays title for this data analytic.
_titleTxt.text = "1. No. of tiles without resources";

// Sets up answer font size to better fit a number.
_answerTxt.fontSize = FONT_SIZE_NUM;

// Displays the answer as the number of game tiles where
// the resources count is equal to 0.
_answerTxt.text = p_mapData.GameTiles
    .Count(t => t.Resources.Count == 0)
    .ToString();
```

## 2. Average Coin in Mountain tiles

```cs
// Displays title for this data analytic.
_titleTxt.text = "2. Average Coin in Mountain tiles";

// Sets up answer font size to better fit a number.
_answerTxt.fontSize = FONT_SIZE_NUM;

// If there are any mountain tiles.
if (p_mapData.GameTiles.OfType<MountainTile>().Any())
{
    // Displays the answer as the average of all coin values belonging
    // only to mountain tiles.
    _answerTxt.text = p_mapData.GameTiles
        .OfType<MountainTile>()
        .Average(t => t.Coin)
        .ToString("0.00");
}

// If there aren't any, set the answer to 0.
else _answerTxt.text = "0";
```

## 3. List of existing terrains, alphabetically

```cs
// Displays title for this data analytic.
_titleTxt.text = "3. Existing terrains, alphabetically";

// Sets up answer font size to better fit a string.
_answerTxt.fontSize = FONT_SIZE_STRING;

// Creates an IEnumerable of the different existing terrains' names, ordered
// alphabetically.
IEnumerable<string> _existingTerrains = p_mapData.GameTiles
    .OrderBy(t => t.Name)
    .Select(t => t.Name)
    .Distinct();

// Iterates each terrain name and appends it to the string builder.
foreach (string f_terrain in _existingTerrains)
    m_stringBuilder.Append(f_terrain + "\n");

// Displays the string builder text.
_answerTxt.text = m_stringBuilder.ToString();
```

## 4. Tile with least Coin

```cs
// Displays title for this data analytic.
_titleTxt.text = "4. Tile with least Coin";

// Sets up answer font size to better fit a string.
_answerTxt.fontSize = FONT_SIZE_STRING;

// Saves the first game tile found with the least coin value.
GameTile m_tile = p_mapData.GameTiles
    .OrderBy(t => t.Coin)
    .FirstOrDefault();

// Appends it's name to the string builder.
m_stringBuilder.Append(m_tile.Name + "\n\n");

// Iterates all resources of said tile.
foreach (Resource r in m_tile.Resources)
{
    // Appends each resource's name to the string builder.
    m_stringBuilder.Append("-" + r.Name + "\n");
}

// Calculates relative game tile based on it's list index.
float m_relativePos = p_mapData.GameTiles.IndexOf(m_tile) *
    p_mapData.YRows / (float)(p_mapData.YRows * p_mapData.XCols);

// Y equals the relative position's integer value.
long m_yCoords = (long)m_relativePos;

// X equals the relative position's decimal value * Y.
int m_xCoords = (int)((m_relativePos - m_yCoords) 
    * p_mapData.XCols);

// Appends the coordinates to the string builder.
m_stringBuilder.Append(
    "\n" + $"ROW: {(m_yCoords + 1).ToString()} | "
    + $"COL: {(m_xCoords + 1).ToString()}");

// Displays the string builder text.
_answerTxt.text = m_stringBuilder.ToString();
```

## 5. Number of unique tiles

```cs
// Displays title for this data analytic.
_titleTxt.text = "5. No. of unique tiles";

// Sets up answer font size to better fit a number.
_answerTxt.fontSize = FONT_SIZE_NUM;

// Displays the answer as the count of every distinct game tile, based on
// GameTileComparer().
_answerTxt.text = p_mapData.GameTiles
    .Distinct(new GameTileComparer())
    .Count()
    .ToString();

public class GameTileComparer : IEqualityComparer<GameTile>
{
    // Reference to String Builder.
    StringBuilder _stringB;

    // IEnumerables to store resources names to compare.
    IEnumerable<string> _firstRStrings; 
    IEnumerable<string> _secondRStrings; 

    // Compares the tiles' names and resources names.
    public bool Equals(GameTile p_first, GameTile p_second)
    {
        // Saves the tiles string names in the corresponding variables. 
        _firstRStrings = p_first.Resources.Select(t => t.Name);
        _secondRStrings = p_second.Resources.Select(t => t.Name);

        // Returns true if the tile's names and resources are the same.
        return p_first.Name == p_second.Name && _firstRStrings.All
            (_secondRStrings.Contains);
    }

    // Compares the game tiles Hash Code.
    public int GetHashCode(GameTile p_tile)
    {
        // Local String Builder instance. 
        _stringB = new StringBuilder();

        // Goes through each resource and adds its name to string.
        foreach (string r in p_tile.Resources.Select(t => t.Name))
            _stringB.Append(r);

        // Returns true if the game tiles' Hash Codes are the same.
        return p_tile.Name.GetHashCode() ^ _stringB.ToString().GetHashCode();
    }
}
```

## 6. Number of all resources

```cs
// Displays title for this data analytic.
_titleTxt.text = "6. No. of all resources";

// Sets up answer font size to better fit a number.
_answerTxt.fontSize = FONT_SIZE_NUM;

// Displays the answer as the sum of all resources.
_answerTxt.text = p_mapData.GameTiles
    .Sum(t => t.Resources.Count)
    .ToString();
```

## 7. Number of all metal resources

```cs
// Displays title for this data analytic.
_titleTxt.text = "7. No. of all metal resources";

// Sets up answer font size to better fit a number.
_answerTxt.fontSize = FONT_SIZE_NUM;

_answerTxt.text = p_mapData.GameTiles
    .SelectMany(t => t.Resources)
    .OfType<MetalsResource>()
    .Count()
    .ToString();
```

## 8. Top 3 Tiles with most food (positions)

```cs
// Displays title for this data analytic.
_titleTxt.text = "8. Top 3 tiles with most food";

// Sets up answer font size to better fit a string.
_answerTxt.fontSize = FONT_SIZE_STRING;

// Creates an IEnumerable of the top 3 game tiles with most food.
IEnumerable<GameTile> _top3tiles = p_mapData.GameTiles
    .OrderByDescending(t => t.Food)
    .Take(3);

float m_relPos;
long m_yRow;
int m_xCol;

// Iterates each terrain name and appends it to the string builder.
foreach (GameTile f_tile in _top3tiles)
{
    m_stringBuilder.Append(f_tile.Name + " (F: " + f_tile.Food + ")");

    // Calculates relative game tile based on it's list index.
    m_relPos = p_mapData.GameTiles.IndexOf(f_tile) *
        p_mapData.YRows / (float)(p_mapData.YRows * p_mapData.XCols);

    // Y equals the relative position's integer value.
    m_yRow = (long) m_relPos;

    // X equals the relative position's decimal value * Y.
    m_xCol = (int)((m_relPos - m_yRow) * p_mapData.XCols);

    // Appends the coordinates to the string builder.
    m_stringBuilder.Append(
    "\n" + $"ROW: {(m_yRow + 1).ToString()} | "
    + $"COL: {(m_xCol + 1).ToString()}\n\n");
}

// Displays the string builder text.
_answerTxt.text = m_stringBuilder.ToString();
```

## 9. Number of equal tiles
