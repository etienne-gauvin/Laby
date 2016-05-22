using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator {

    protected Map map;
    protected List<HashSet<Tile>> groups;

    /**
     * Générer une map
     */
    public MapGenerator()
    {
        map = new Map();
        groups = new List<HashSet<Tile>>();
    }

    /**
     * Démarrer la génération de la map
     */
    public Map GenerateMap()
    {
        Tile tile;
        Tile neighbour;

        HashSet<Tile> tileGroup;
        HashSet<Tile> neighbourGroup;


        // Créer des tiles entourées de murs
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                tile = map.MakeTile(x, y);
                tile.walkable = true;

                // Création d'un groupe unique pour cette tile
                tileGroup = new HashSet<Tile>();
                tileGroup.Add(tile);
                groups.Add(tileGroup);
            }
        }

        // Retrouver toutes les tiles voisines des autres
        map.FindAllNeighbors();

        // Taille de la map
        Vector2 size = map.GetSize();

        // Ouverture aléatoire de murs
        while (groups.Count > 1)
        {
            tile = map.RandomTile();
            tileGroup = GetGroupOf(tile);

            Tile.Direction direction = Tile.RandomDirection();

            if (tile.neighbors[direction] != null)
            {
                neighbour = tile.neighbors[direction];
                neighbourGroup = GetGroupOf(neighbour);

                if (tileGroup != neighbourGroup)
                {
                    // Destruction des murs
                    map.DestroyWalls(tile, direction);

                    // Fusion des groupes
                    foreach (Tile neighbourGroupTile in neighbourGroup)
                    {
                        tileGroup.Add(neighbourGroupTile);
                    }

                    neighbourGroup.Clear();
                    groups.Remove(neighbourGroup);
                }
            }
        }
        
        return map;
    }

    /**
     * Retourner le groupe d'une tile
     */
    public HashSet<Tile> GetGroupOf(Tile tile)
    {
        foreach (HashSet<Tile> group in groups)
        {
            if (group.Contains(tile))
            {
                return group;
            }
        }

        throw new System.Exception("The tile " + tile + " isn't in a group !");
    }
}
