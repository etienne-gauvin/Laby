using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TileView3D : MonoBehaviour, ITileView {
    
    public Tile tile;

    public GameObject meshContainer;

    public Dictionary<Tile.Direction, GameObject> walls;

    public GameObject northWestColumn;
    public GameObject northEastColumn;
    public GameObject southWestColumn;
    public GameObject southEastColumn;

    public static readonly Vector2 size = new Vector2(3, 3);

    // Use this for initialization
    public void Awake()
    {
        walls = new Dictionary<Tile.Direction, GameObject>();

        // Ajout des GameObjects pour les 4 directions
        foreach (Tile.Direction direction in Enum.GetValues(typeof(Tile.Direction)))
        {
            walls.Add(direction, meshContainer.transform.FindChild(direction.ToString() + "Wall").gameObject);
        }
    }

    // Use this for initialization
    public void Start()
    {
    }

    // Update is called once per frame
    void Update () {
	
	}

    /**
     * Mise à jour des murs
     */
    public void UpdateWalls()
    {
        if (tile != null)
        {
            foreach (Tile.Direction direction in Enum.GetValues(typeof(Tile.Direction)))
            {
                walls[direction].SetActive(tile.walls.Contains(direction));
            }
        }
    }

    /**
     * Attacher une tile
     */
    public void AttachTile(Tile tile)
    {
        this.tile = tile;
        name = tile.ToString();
        UpdateWalls();
    }
}
