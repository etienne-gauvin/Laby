using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TileView3D : MonoBehaviour, ITileView {
    
    public Tile tile;

    public GameObject meshContainer;

    public Dictionary<Cube.Direction, GameObject> walls;
    
    public static readonly Vector2 size = new Vector2(3, 3);

    // Use this for initialization
    public void Awake()
    {
        walls = new Dictionary<Cube.Direction, GameObject>();

        // Ajout des GameObjects pour les 4 directions
        foreach (Cube.Direction direction in Cube.Direction.GetAll())
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
            foreach (Cube.Direction direction in Cube.Direction.GetAll())
            {
                walls[direction].SetActive(tile.walls[direction] != null);
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
