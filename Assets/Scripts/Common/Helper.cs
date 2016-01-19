using UnityEngine;
using System.Collections;

public static class Helper
{
    //Converts grid position to isometric world position (by offset)
    public static Vector2 GridToIso(Vector2 gridPos, Vector2 offset)
    {
        Vector2 pos = new Vector2((gridPos.x * offset.x) + (gridPos.y * offset.x), (gridPos.y * offset.y * -1) + (gridPos.x * offset.y));

        return pos;
    }
}
