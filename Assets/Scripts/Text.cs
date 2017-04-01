using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextStuff : MonoBehaviour { 
    private Rigidbody2D player;
   
    private int health = 3;
   

    public Text healthText;
    public Text countKillsText;
    public Text messText;

    private Rigidbody rb;
    private int countKills=0;

 

    void SetKillText()
    {
        countKillsText.text = "Kills: " + countKills.ToString();
        if (countKills >= 10)
        {
            messText.text = "NEXT ";
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            messText.text = "YOU LOSE, LOSER ";
        }
    }
}
