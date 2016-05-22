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

        GridLayoutGroup gridLayout = tilesContainer.GetComponent<GridLayoutGroup>();
        RectTransform transform = tilesContainer.GetComponent<RectTransform>();

        Vector2 size = map.GetSize();
        int maxXY = (int) Mathf.Max(size.x, size.y);

        // Redéfinir la taille de la grille en fonction de la taille de la map
        gridLayout.cellSize = new Vector2(
            transform.rect.width / maxXY,
            transform.rect.height / maxXY
        );

        Debug.Log(transform.rect.width + " ; " + maxXY);

        gridLayout.constraintCount = maxXY;

        
        for (int y = 0; y < maxXY; y++)
        {
            for (int x = 0; x < maxXY; x++)
            {
                GameObject tileViewGO = Instantiate(tilePrefab);
                tileViewGO.gameObject.transform.SetParent(tilesContainer.transform);
                
                Tile tile = map.GetTile(x, y);

                tileViewGO.GetComponent<TileView2D>().AttachTile(tile);
            }
        }
    }
}
