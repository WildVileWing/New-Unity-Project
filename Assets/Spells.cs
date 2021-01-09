using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    private NewBehaviourScript Temp;
    public void Start()
    {
        Temp = GetComponent<NewBehaviourScript>();
    }
    public void HealButton(int healing)
    {
        if (Temp.player.CurrentPlayerHealth < Temp.player.PlayerHealth)
        {

            if (Temp.player.PlayersGold > (int)(healing * 2))
            {
                Temp.player.CurrentPlayerHealth += healing;
                Temp.player.PlayersGold -= (int)(healing * 2);
                if(Temp.player.CurrentPlayerHealth > Temp.player.PlayerHealth)
                {
                    Temp.player.CurrentPlayerHealth = Temp.player.PlayerHealth;
                }
                Temp.PlayerInformation();

            }
        }
    }   
}
