using UnityEngine;
using System.Collections;

public interface ITileView {

    void UpdateWalls();
    
    void AttachTile(Tile tile);

}
