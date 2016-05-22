using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Map : IEnumerable {
    
    /**
     * Liste (désordonnée) des tiles de la map
     */
    protected List<Tile> tiles;

    /**
     * Retourne uen tile aléatoire
     */
    public Tile RandomTile()
    {
        return tiles[Mathf.FloorToInt(UnityEngine.Random.Range(0, tiles.Count))];
    }
    
    /**
     * Crée une nouvelle tile
     */
    public Tile MakeTile(int x, int y)
    {
        if (GetTile(x, y) != null)
        {
            throw new System.Exception("A tile already exists at this position");
        }

        Tile tile = new Tile(this, x, y);
        tiles.Add(tile);
        return tile;
    }

    /**
     * Retourne une tile d'après sa position sur la map.
     * Retourne null si il n'y a pas de tile.
     */
    public Tile GetTile(int x, int y)
    {
        foreach (Tile tile in tiles)
        {
            if (x == tile.X && y == tile.Y)
            {
                return tile;
            }
        }
        
        return null;
    }

    /**
     * Retourne une tile d'après une position sur la map.
     */
    public Tile GetTile(float x, float y)
    {
        return GetTile(Mathf.FloorToInt(x), Mathf.FloorToInt(y));
    }

    /**
     * Retourne une tile d'après une position sur la map.
     */
    public Tile GetTile(Vector2 position)
    {
        return GetTile(position.x, position.y);
    }

    /**
     * Créer et générer la map
     */
    public Map()
    {
        tiles = new List<Tile>();
    }

    /**
     * Retrouver toutes les tiles voisines des autres
     */
    public void FindAllNeighbors()
    {
        foreach (Tile tile in tiles)
        {
            tile.FindNeighbors();
        }
    }

    /**
     * Calcule la taille de la map.
     */
    public Vector2 GetSize()
    {
        Vector2 min = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        Vector2 max = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        foreach (Tile tile in tiles)
        {
            min.x = Mathf.Min(min.x, tile.X);
            min.y = Mathf.Min(min.y, tile.Y);

            max.x = Mathf.Max(max.x, tile.X);
            max.y = Mathf.Max(max.y, tile.Y);
        }

        return max - min + new Vector2(1, 1);
    }

    /**
     * Supprimer le mur entre deux tiles
     */
    public void DestroyWalls(Tile tile, Tile.Direction direction)
    {
        tile.DestroyWall(direction);

        if (tile.neighbors[direction] != null)
        {
            tile.neighbors[direction].DestroyWall(Tile.OppositeDirection(direction));
        }
    }

    public IEnumerator GetEnumerator()
    {
        return tiles.GetEnumerator();
    }
}
