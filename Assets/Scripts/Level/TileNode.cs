using UnityEngine;
using System.Collections;

//Class to be used in 2D array (seperating level logic from displayed sprites)
public class TileNode
{
    public enum Type { Blank, Ground, PlayerSpawn, EnemySpawn }
    //What type of node this is
    public Type type = Type.Blank;

    public Vector2 worldPosition;
    public Vector2 gridPosition;

    //Tile occupancy
    public bool isOccupied = false;
    //THe game object which occupies the tile. Enemy, item, etc.
    public GameObject occupyingGameObject;

    public TileNode(Type nodeType, Vector2 gridPos, Vector2 worldPos)
    {
        type = nodeType;

        gridPosition = gridPos;

        worldPosition = worldPos;
    }

    public void Clear()
    {
        isOccupied = false;
        occupyingGameObject = null;
    }
}
