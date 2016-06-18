using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapView2D : MonoBehaviour, IMapView {

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
        
        foreach (Cube position in map.grid.Hexes)
        {
            GameObject tileViewGO = Instantiate(tilePrefab);

            tileViewGO.gameObject.transform.SetParent(tilesContainer.transform);

            Tile tile = map[position];

            ScreenCoordinate sc = map.grid.HexToCenter(position);

            RectTransform transform = (RectTransform) tileViewGO.gameObject.transform;

            float h = 87;
            float w = h - Mathf.Sqrt(3) / 2;
            
            transform.position = tilesContainer.transform.position + new Vector3(sc.position.x * w, sc.position.y * h, 0);
            
            tileViewGO.GetComponent<TileView2D>().AttachTile(tile);
        }
    }
}
