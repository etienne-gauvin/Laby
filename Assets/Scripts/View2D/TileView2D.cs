using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TileView2D : MonoBehaviour {

    public Tile tile;
    
    public Dictionary<Tile.Direction, GameObject> walls;

    // Use this for initialization
    public void Awake()
    {
        walls = new Dictionary<Tile.Direction, GameObject>();

        // Ajout des GameObjects pour les 4 directions
        foreach (Tile.Direction direction in Enum.GetValues(typeof(Tile.Direction)))
        {
            walls.Add(direction, gameObject.transform.FindChild(direction.ToString()).gameObject);
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
