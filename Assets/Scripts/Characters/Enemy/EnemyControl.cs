using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    public bool canMove = false;

    private CharacterMove characterMove;

    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
    }

    //Function is placeholder - randomness will be placed with AI at some point
    public void Move()
    {
        int direction = Random.Range(0, 4);

        switch (direction)
        {
            case 0:
                characterMove.Move(CharacterMove.IsoDirection.Down);
                break;
            case 1:
                characterMove.Move(CharacterMove.IsoDirection.Right);
                break;
            case 2:
                characterMove.Move(CharacterMove.IsoDirection.Up);
                break;
            case 3:
                characterMove.Move(CharacterMove.IsoDirection.Left);
                break;
        }
    }
}
