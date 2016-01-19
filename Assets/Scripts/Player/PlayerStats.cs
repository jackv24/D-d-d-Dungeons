using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int currentHealth = 75;
    public int maxHealth = 100;

    void Awake()
    {
        instance = this;
    }
}
