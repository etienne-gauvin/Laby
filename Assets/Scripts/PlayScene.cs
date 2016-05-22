using UnityEngine;
using System.Collections;

public class PlayScene : MonoBehaviour {

    public MapView2D minimap;

    protected Map map;

	// Use this for initialization
	void Start () {
        MapGenerator generator = new MapGenerator();
        map = generator.GenerateMap();
        minimap.AttachMap(map);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
