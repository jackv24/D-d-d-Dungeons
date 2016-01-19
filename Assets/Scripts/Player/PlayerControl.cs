using UnityEngine;
using System.Collections;

//Handles inputs for the player, to be passed to PlayerMove
public class PlayerControl : MonoBehaviour
{
    //Reference to the player movement script on this gameobject
    private PlayerMove playerMove;

    //Ensures that keyboard inputs are only accepted on key down
    private bool acceptKeyboardInput = true;

    //Touch began and end positions for determining swipe direction
    private Vector2 beganTouchPos;
    private Vector2 endTouchPos;
    //The amount of pixels in which a swipe should be ignored
    public float swipeDeadzone = 30;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        HandleKeyboardInput();
        HandleTouchInput();
    }

    //Handles keyboard input - fairly self explanitory
    void HandleKeyboardInput()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && acceptKeyboardInput)
        {
            playerMove.Move(PlayerMove.IsoDirection.Right);

            acceptKeyboardInput = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && acceptKeyboardInput)
        {
            playerMove.Move(PlayerMove.IsoDirection.Left);

            acceptKeyboardInput = false;
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && acceptKeyboardInput)
        {
            playerMove.Move(PlayerMove.IsoDirection.Up);

            acceptKeyboardInput = false;
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && acceptKeyboardInput)
        {
            playerMove.Move(PlayerMove.IsoDirection.Down);

            acceptKeyboardInput = false;
        }

        //If no key is being held down, start accepting inputs again
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
            acceptKeyboardInput = true;
    }

    //Handles touch inputs (swipe direction);
    void HandleTouchInput()
    {
        //if the screen is being touched (no multitouch here - only handles the first touch)
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                //Save position where touch began
                beganTouchPos = Input.GetTouch(0).position;
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Save position where touch ended
                endTouchPos = Input.GetTouch(0).position;

                //If the swipe distance is above the threshold, count it as a swipe
                if (Vector2.Distance(beganTouchPos, endTouchPos) > swipeDeadzone)
                {
                    //Calculate swipe direction
                    Vector2 direction = endTouchPos - beganTouchPos;

                    //Initialise isometric direction variable
                    PlayerMove.IsoDirection isoDirection = PlayerMove.IsoDirection.Stationary;

                    //Determine isometric direction
                    if (direction.x >= 0)
                    {
                        if (direction.y >= 0)
                            isoDirection = PlayerMove.IsoDirection.Right;
                        else if (direction.y < 0)
                            isoDirection = PlayerMove.IsoDirection.Down;
                    }
                    else if (direction.x < 0)
                    {
                        if (direction.y >= 0)
                            isoDirection = PlayerMove.IsoDirection.Up;
                        else if (direction.y < 0)
                            isoDirection = PlayerMove.IsoDirection.Left;
                    }

                    //Send direction to player movement script
                    playerMove.Move(isoDirection);
                }
            }
        }
    }
}
