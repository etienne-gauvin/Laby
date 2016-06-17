using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile {
    
    /**
     * Murs de la tile
     */
    public Dictionary<Cube.Direction, Wall> walls;

    /**
     * Tiles voisines
     */
    public Dictionary<Cube.Direction, Tile> neighbors;

    /**
     * Si il est possible de se déplacer sur cette tile
     */
    public bool walkable = true;

    /**
     * Position de la tile sur la map
     */
    public Cube position;
    
    /**
     * Map associée à la tile
     */
    public Map map;

    /**
     * Créer une tile.
     * /!\ Utiliser Map.MakeTile() à la place.
     */
    public Tile(Map map, Cube position)
    {
        this.map = map;
        this.position = position;

        walls = new Dictionary<Cube.Direction, Wall>();
        walls[Cube.Direction.Get(0)] = new Wall();
        walls[Cube.Direction.Get(1)] = new Wall();
        walls[Cube.Direction.Get(2)] = new Wall();
        walls[Cube.Direction.Get(3)] = new Wall();
        walls[Cube.Direction.Get(4)] = new Wall();
        walls[Cube.Direction.Get(5)] = new Wall();

        neighbors = new Dictionary<Cube.Direction, Tile>();
        FindNeighbors();
    }

    /**
     * Trouver les tiles voisines
     */
    public void FindNeighbors()
    {
        Cube.Direction direction;

        for (int i = 0; i < 6; i++)
        {
            direction = Cube.Direction.Get(i);
            neighbors[direction] = map[position + direction];
        }
    }

    /**
     * Détruit un mur
     */
    public void DestroyWall(Cube.Direction direction)
    {
        if (walls[direction] != null)
        {
            walls.Remove(direction);
        }
    }

    /**
     * Get String
     */
    override public string ToString()
    {
        return position.ToString();
    }
}
