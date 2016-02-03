using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //Static instance for easy access (there should only ever be one game manager)
    public static GameManager instance;

    public LevelInfo levelInfo;
    public EnemyManager enemyManager;

    public GameObject player;

    void Awake()
    {
        //Ensures there is only one game manager
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();

        //If no player has been set, attempt to find one
        if (!player)
            player = GameObject.FindWithTag("Player");
    }

    //Called when the player peforms an action
    public void UsePlayerTurn()
    {
        //Allow enemies to use their turns
        enemyManager.UseEnemyTurns();
    }
}
