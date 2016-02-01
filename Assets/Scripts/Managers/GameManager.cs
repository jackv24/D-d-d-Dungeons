using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //Static instance for easy access (there should only ever be one game manager)
    public static GameManager instance;

    public LevelInfo levelInfo;

    void Awake()
    {
        //Ensures there is only one game manager
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
