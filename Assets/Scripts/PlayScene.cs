using UnityEngine;
using System.Collections;

public class PlayScene : MonoBehaviour {

    public MapView2D mapView2D;
    //public MapView3D mapView3D;

    protected Map map;

	// Use this for initialization
	void Start () {
        MapGenerator generator = new MapGenerator();
        map = generator.GenerateMap();
        
        mapView2D.AttachMap(map);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
