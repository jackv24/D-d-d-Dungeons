using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public Slider slider;

    public Text text;

    private CharacterStats stats;

    void Start()
    {
        stats = GameManager.instance.player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        if (slider)
            slider.value = (float)stats.currentHealth / stats.maxHealth;

        if (text)
            text.text = stats.currentHealth + "/" + stats.maxHealth;
    }
}
