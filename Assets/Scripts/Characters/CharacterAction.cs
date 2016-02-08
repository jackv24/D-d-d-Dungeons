using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMove))]

public class CharacterAction : MonoBehaviour
{
    private CharacterMove characterMove;
    private LevelInfo levelInfo;

    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
        levelInfo = GameManager.instance.levelInfo;
    }

    //Called by controller (AI or playercontrol)
    public void Attack(CharacterMove.IsoDirection dir)
    {
        //Initialise vector for grid position
        Vector2 newGridPos = Vector2.zero;

        //Determine new grid position based on direction
        if (dir == CharacterMove.IsoDirection.Up)
            newGridPos = new Vector2(characterMove.currentGridPos.x, characterMove.currentGridPos.y - 1);
        else if (dir == CharacterMove.IsoDirection.Down)
            newGridPos = new Vector2(characterMove.currentGridPos.x, characterMove.currentGridPos.y + 1);
        else if (dir == CharacterMove.IsoDirection.Left)
            newGridPos = new Vector2(characterMove.currentGridPos.x - 1, characterMove.currentGridPos.y);
        else if (dir == CharacterMove.IsoDirection.Right)
            newGridPos = new Vector2(characterMove.currentGridPos.x + 1, characterMove.currentGridPos.y);

        if (levelInfo.IsTileWalkable(newGridPos))
        {
            TileNode node = levelInfo.GetTile(newGridPos);

            //If this next tile is occupied
            if (node.isOccupied)
            {
                CharacterStats stats = node.occupyingGameObject.GetComponent<CharacterStats>();

                if (stats)
                    stats.RemoveHealth(10);

                //If this controller is that of the player, use a player turn
                if (characterMove.isPlayer)
                    GameManager.instance.UsePlayerTurn();
            }
        }
    }
}
