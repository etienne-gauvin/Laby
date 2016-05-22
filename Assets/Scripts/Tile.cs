using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile {

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    /**
     * Retourne une direction aléatoire
     */
    public static Direction RandomDirection()
    {
        Direction[] directions = {
            Direction.North,
            Direction.West,
            Direction.South,
            Direction.East
        };

        return directions[Random.Range(0, 4)];
    }

    /**
     * Retourne la direction opposée à une autre
     */
    public static Direction OppositeDirection(Direction direction)
    {
        Direction opposite;

        switch (direction)
        {
            case Direction.North:
                opposite = Direction.South;
                break;

            case Direction.South:
                opposite = Direction.North;
                break;

            case Direction.East:
                opposite = Direction.West;
                break;

            default:
            case Direction.West:
                opposite = Direction.East;
                break;

        }

        return opposite;
    }
    
    /**
     * Murs de la tile
     */
    public HashSet<Direction> walls;

    /**
     * Tiles voisines
     */
    public Dictionary<Direction, Tile> neighbors;

    /**
     * Si il est possible de se déplacer sur cette tile
     */
    public bool walkable = true;

    /**
     * Position de la tile sur la map
     */
    public readonly Vector2 position;
    
    /**
     * Raccourci pour position.x
     */
    public int X
    {
        get
        {
            return Mathf.FloorToInt(position.x);
        }
    }

    /**
     * Raccourci pour position.y
     */
    public int Y
    {
        get
        {
            return Mathf.FloorToInt(position.y);
        }
    }

    /**
     * Map associée à la tile
     */
    private Map map;

    /**
     * Créer une tile.
     * /!\ Utiliser Map.MakeTile() à la place.
     */
    public Tile(Map map, int x, int y)
    {
        this.map = map;
        this.position = new Vector2(x, y);

        walls = new HashSet<Direction>();
        walls.Add(Direction.North);
        walls.Add(Direction.East);
        walls.Add(Direction.South);
        walls.Add(Direction.West);

        neighbors = new Dictionary<Direction, Tile>();
        FindNeighbors();
    }

    /**
     * Trouver les tiles voisines
     */
    public void FindNeighbors()
    {
        neighbors[Direction.North] = map.GetTile(X, Y - 1);
        neighbors[Direction.East] = map.GetTile(X + 1, Y);
        neighbors[Direction.South] = map.GetTile(X, Y + 1);
        neighbors[Direction.West] = map.GetTile(X - 1, Y);
    }

    /**
     * Détruit un mur
     */
    public void DestroyWall(Direction direction)
    {
        Debug.Log(walls.Contains(direction));
        if (walls.Contains(direction))
        {
            walls.Remove(direction);
        }
        Debug.Log(walls.Contains(direction));
    }

    /**
     * Get String
     */
    override public string ToString()
    {
        return position.x + ";" + position.y;
    }
}
