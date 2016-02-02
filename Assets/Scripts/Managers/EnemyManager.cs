using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    //The enemy prefab to spawn
    public GameObject enemyPrefab;

    //Reference to level info (to know where to spawn enemies)
    private LevelInfo levelInfo;

    void Start()
    {
        levelInfo = GameManager.instance.levelInfo;

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

                //Sets the spawn node variable of the movement script
                enemy.GetComponent<CharacterMove>().spawnNode = node;
            }
        }
    }
}
