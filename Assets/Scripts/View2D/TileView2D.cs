using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TileView2D : MonoBehaviour, ITileView {

    public Tile tile;
    
    public GameObject[] walls;

    // Use this for initialization
    public void Awake()
    {
        //walls = new GameObject[6];

        // Ajout des GameObjects pour les 4 directions
        //foreach (Cube.Direction direction in Cube.Direction.GetAll())
        //{
        //    walls[direction.d] = gameObject.transform.FindChild("Wall" + direction.d).gameObject;
        //}
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
                walls[direction.d].SetActive(tile.walls.ContainsKey(direction));
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
