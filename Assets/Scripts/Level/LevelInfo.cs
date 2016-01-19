using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour
{
    //Static instance
    public static LevelInfo instance;

    //2D array of level nodes
    public TileNode[,] nodes;

    //Placeholder integer array for creating node array (until level generation is implemented)
    public int[,] level = {
        { 0, 0, 1, 0, 0, 0 },
        { 0, 0, 1, 0, 0, 0 },
        { 0, 0, 1, 0, 0, 0 },
        { 0, 1, 1, 0, 0, 0 },
        { 0, 1, 1, 0, 0, 0 },
        { 2, 1, 1, 1, 1, 1 },
        { 0, 1, 1, 0, 0, 1 },
        { 0, 0, 0, 0, 1, 1 },
        { 0, 0, 0, 0, 1, 1 },
        };

    //How much each isometric tile should be offset
    public Vector2 worldTileOffset = new Vector2(0.5f, 0.25f);

    //The prefab tile sprite to instantiate
    public GameObject groundTile;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //make nodes array the same size as placeholder array (x and y swapped for code readbility)
        nodes = new TileNode[level.GetLength(1), level.GetLength(0)];

        for (int y = 0; y < level.GetLength(0); y++)                    //This iteration code will be changed when placeholder array is removed
        {
            for (int x = 0; x < level.GetLength(1); x++)
            {
                //Convert array position to world position
                Vector2 position = Helper.GridToIso(new Vector2(x, y), worldTileOffset);

                if (level[y, x] == 0)
                    nodes[x, y] = new TileNode(TileNode.Type.Blank, new Vector2(x, y), position);
                else
                {
                    if (level[y, x] == 2)
                        nodes[x, y] = new TileNode(TileNode.Type.Spawn, new Vector2(x, y), position);
                    else
                        nodes[x, y] = new TileNode(TileNode.Type.Ground, new Vector2(x, y), position);

                    if (groundTile)
                    {
                        GameObject obj = Instantiate(groundTile, new Vector3(position.x, position.y, position.y), Quaternion.identity) as GameObject;
                        obj.name = groundTile.name + " (" + x + ", " + y + ")";
                        obj.transform.parent = transform;
                    }
                }
            }
        }
    }

    //Returns tile at a grid position 
    public TileNode GetTile(Vector2 gridPos)
    {
        return nodes[(int)gridPos.x, (int)gridPos.y];
    }

    //Searches the array for a spawn tile, and returns it
    public TileNode GetSpawnTile()
    {
        for (int x = 0; x < nodes.GetLength(0); x++)
        {
            for (int y = 0; y < nodes.GetLength(1); y++)
            {
                if (nodes[x, y].type == TileNode.Type.Spawn)
                {
                    return nodes[x, y];
                }
            }
        }

        //If no spawn tile is found, return null
        return null;
    }

    //Returns true of tile is walkeable
    public bool IsTileWalkable(Vector2 gridPos)
    {
        //Make sure position is withing array bounds
        if (gridPos.x < nodes.GetLength(0) && gridPos.x >= 0 && gridPos.y < nodes.GetLength(1) && gridPos.y >= 0)
        {
            //If tile is not blank, it is walkeable
            if(GetTile(gridPos).type != TileNode.Type.Blank)
                return true;
        }

        return false;
    }
}
