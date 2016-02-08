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

        characterMove.Move(ConvertDirection(direction));
    }

    //Converts an integer value into a direction (Range: 0 - 3 inclusive)
    CharacterMove.IsoDirection ConvertDirection(int direction)
    {
        switch (direction)
        {
            case 0:
                return CharacterMove.IsoDirection.Down;
            case 1:
                return CharacterMove.IsoDirection.Right;
            case 2:
                return CharacterMove.IsoDirection.Up;
            case 3:
                return CharacterMove.IsoDirection.Left;
        }

        return CharacterMove.IsoDirection.Stationary;
    }
}
