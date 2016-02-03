using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    //The enemy prefab to spawn
    public GameObject enemyPrefab;

    public List<GameObject> enemies;

    //Reference to level info (to know where to spawn enemies)
    private LevelInfo levelInfo;

    void Start()
    {
        levelInfo = GameManager.instance.levelInfo;

        enemies = new List<GameObject>();

        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        //iterates through the 2D node array
        foreach (TileNode node in levelInfo.nodes)
        {
            //If a node is if the type EnemySpawn, spawn an enemy
            if (node.type == TileNode.Type.EnemySpawn)
            {
                GameObject enemy = Instantiate(enemyPrefab, node.worldPosition, Quaternion.identity) as GameObject;

                //Adds the enemy to a list of all enemies
                enemies.Add(enemy);

                //Sets the spawn node variable of the movement script
                enemy.GetComponent<CharacterMove>().spawnNode = node;
            }
        }
    }

    //Calls the move function on all enemy controllers
    public void UseEnemyTurns()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyControl>().Move();
        }
    }
}
