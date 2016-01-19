using UnityEngine;
using System.Collections;

//Automatically orders isometric tiles in 2D
[ExecuteInEditMode]
public class TileOrderIsometric : MonoBehaviour
{
    public bool canReorder = true;

    private Vector3 pos;

    void Update()
    {
        //If this tile can be reordered, and the game is not running...
        if (canReorder && !Application.isPlaying)
        {
            //...set the z position to equal the y position
            pos = transform.position;
            pos.z = pos.y;
            transform.position = pos;
        }
    }
}
