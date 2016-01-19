using UnityEngine;
using System.Collections;

//Class to be used in 2D array (seperating level logic from displayed sprites)
public class TileNode
{
    public enum Type { Blank, Ground, Spawn }
    //What type of node this is
    public Type type = Type.Blank;

    public Vector2 worldPosition;
    public Vector2 gridPosition;

    public TileNode(Type nodeType, Vector2 gridPos, Vector2 worldPos)
    {
        type = nodeType;

        gridPosition = gridPos;

        worldPosition = worldPos;
    }
}
