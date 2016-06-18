using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Map : System.Object, IEnumerable
{
    /**
     * Grille hexagonale
     */
    public HexGrid grid;

    /**
     * Dictionnaire des tiles de la map
     */
    public Dictionary<Cube, Tile> tiles;
    
    /**
     * Retourne une tile aléatoire
     */
    public Tile RandomTile()
    {
        int rand = UnityEngine.Random.Range(0, tiles.Values.Count);

        int i = 0;
        
        foreach (Tile tile in tiles.Values)
        {
            if (i == rand)
            {
                return tile;
            }

            i++;
        }

        return null;
    }
    
    /**
     * Crée une nouvelle tile
     */
    public Tile MakeTile(Cube position)
    {
        if (tiles.ContainsKey(position))
        {
            throw new System.Exception("A tile already exists at this position");
        }


        Tile tile = new Tile(this, position);
        tiles[position] = tile;

        //Debug.Log("New tile " + tile);

        return tile;
    }

    /**
     * Retourne une tile d'après sa position sur la map.
     * Retourne null si il n'y a pas de tile.
     */
    public Tile this[Cube position]
    {
        get
        {
            if (tiles.ContainsKey(position))
            {
                return tiles[position];
            }
            else
            {
                return null;
            }
        }
    }
    
    /**
     * Créer et générer la map
     */
    public Map()
    {
        grid = new HexGrid(HexGrid.HexagonalShape(6));
        grid.orientation = Orientation.Horizontal;

        tiles = new Dictionary<Cube, Tile>();
    }

    /**
     * Retrouver toutes les tiles voisines des autres
     */
    public void FindAllNeighbors()
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.FindNeighbors();
        }
    }

    /**
     * Calcule la taille de la map.
     */
    public Cube GetSize()
    {
        Cube min = new Cube(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        Cube max = new Cube(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

        foreach (Cube position in tiles.Keys)
        {
            min.x = Mathf.Min(min.x, position.x);
            min.y = Mathf.Min(min.y, position.y);
            min.z = Mathf.Min(min.z, position.z);

            max.x = Mathf.Max(max.x, position.x);
            max.y = Mathf.Max(max.y, position.y);
            max.z = Mathf.Max(max.z, position.z);
        }

        return max - min + new Cube(1, 1, 1);
    }

    /**
     * Supprimer le mur entre deux tiles
     */
    public void DestroyWalls(Tile tile, Cube.Direction direction)
    {
        tile.DestroyWall(direction);

        if (tile.neighbors[direction] != null)
        {
            tile.neighbors[direction].DestroyWall(direction.Opposite());
        }
    }

    public IEnumerator GetEnumerator()
    {
        return tiles.GetEnumerator();
    }
}
