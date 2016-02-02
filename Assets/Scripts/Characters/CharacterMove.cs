using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    public enum IsoDirection
    {
        Up, Down, Left, Right, Stationary
    }

    public float moveSmoothing = 0.1f;

    public TileNode spawnNode = null;

    //Current position on the 2d array (should always be integer values)
    public Vector2 currentGridPos = Vector2.zero;
    //target position in world space
    private Vector3 newPos;

    private LevelInfo levelInfo;

    void Start()
    {
        //Get reference to level info from the game manager
        levelInfo = GameManager.instance.levelInfo;

        //Get spawn node if player, enemies are set when spawned
        if(tag == "Player")
            spawnNode = levelInfo.GetSpawnTile(TileNode.Type.PlayerSpawn);

        //Start character at spawn node
        transform.position = spawnNode.worldPosition;
        //Set array position to spawn node
        MoveToNode(spawnNode.gridPosition);

        //set target position to current
        newPos = transform.position;
    }

    void Update()
    {
        //If the target position has changed, lerp smoothly to new value
        if (newPos != transform.position)
        {
            newPos.z = newPos.y;

            transform.position = Vector3.Lerp(transform.position, newPos, moveSmoothing);
        }
    }

    //Called by controller (AI or playercontrol)
    public void Move(IsoDirection dir)
    {
        //Initialise vector for grid position
        Vector2 newGridPos = Vector2.zero;

        //Determine new grid position based on direction
        if (dir == IsoDirection.Up)
            newGridPos = new Vector2(currentGridPos.x, currentGridPos.y - 1);
        else if (dir == IsoDirection.Down)
            newGridPos = new Vector2(currentGridPos.x, currentGridPos.y + 1);
        else if (dir == IsoDirection.Left)
            newGridPos = new Vector2(currentGridPos.x - 1, currentGridPos.y);
        else if (dir == IsoDirection.Right)
            newGridPos = new Vector2(currentGridPos.x + 1, currentGridPos.y);

        //If this new grid position can be walked on
        if (levelInfo.IsTileWalkable(newGridPos))
        {
            //Move to new node
            //Clear previous node
            levelInfo.nodes[(int)currentGridPos.x, (int)currentGridPos.y].Clear();
            //Set current node
            MoveToNode(newGridPos);

            //Set target world position to that of the node at the new grid position
            newPos = levelInfo.GetTile(currentGridPos).worldPosition;
        }
    }

    public void MoveToNode(Vector2 nodePos)
    {
        //Set current node
        currentGridPos = nodePos;
        //Set new node occupancy
        levelInfo.nodes[(int)currentGridPos.x, (int)currentGridPos.y].isOccupied = true;
        levelInfo.nodes[(int)currentGridPos.x, (int)currentGridPos.y].occupyingGameObject = gameObject;
    }
}
