using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour
{
    //Player has different things it needs to clear upon death
    public bool isPlayer = false;

    public int currentHealth = 75;
    public int maxHealth = 100;

    //Removes the specified amount of health
    public void RemoveHealth(int amount)
    {
        currentHealth -= amount;

        //If health falls to 0
        if (currentHealth <= 0)
        {
            //Clamp health at 0 (for displaying in health bars, etc)
            currentHealth = 0;

            //Kill the character
            Die();
        }
    }

    //Clears character references and destroys gameobject
    public void Die()
    {
        LevelInfo levelInfo = GameManager.instance.levelInfo;

        //If this is an enemy character
        if (!isPlayer)
        {
            //Remove this enemy from the list of enemy gameobjects
            GameManager.instance.enemyManager.enemies.Remove(gameObject);
            //Clear the tile this enemy occupies
            levelInfo.GetTile(GetComponent<CharacterMove>().currentGridPos).Clear();

            //Destroy the gameobject
            Destroy(gameObject);
        }
    }
}
