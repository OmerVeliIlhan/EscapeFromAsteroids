using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthHandler : MonoBehaviour
{
    public static HealthHandler instance;
    public int health;
    public int heartNumber;
    public Image[] hearts;
    public Sprite heart;
    public Sprite no_heart;


    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if(DamageHandler.instance.unvulnerable > 0)
        {
            DamageHandler.instance.unvulnerable -= 3f * Time.deltaTime;
        }
        if(health > heartNumber)
        {
            health = heartNumber;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = heart;
            }
            else
            {
                hearts[i].sprite = no_heart;
            }
            if (i < heartNumber)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
