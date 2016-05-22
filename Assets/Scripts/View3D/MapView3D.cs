using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapView3D : MonoBehaviour, IMapView {

    public GameObject tilePrefab;
    public GameObject tilesContainer;

    protected Map map;
    
    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

        // Mise à jour de l'affichage de la map
        /*foreach (Transform child in tilesContainer.transform)
        {
            TileView2D tileView = child.gameObject.GetComponent<TileView2D>();
            tileView.UpdateWalls();
        }*/
    }

    /**
     * Attacher la map
     */
    public void AttachMap(Map map)
    {
        this.map = map;
        
        Vector2 size = map.GetSize();
        
        foreach (Tile tile in map)
        {
            GameObject tileViewGO = Instantiate(tilePrefab);
            tileViewGO.gameObject.transform.SetParent(tilesContainer.transform);
            tileViewGO.gameObject.transform.position = new Vector3(tile.X * TileView3D.size.x, 0, - tile.Y * TileView3D.size.y);

            tileViewGO.GetComponent<TileView3D>().AttachTile(tile);
        }
    }
}
