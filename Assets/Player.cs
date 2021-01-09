using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public int PlayerHealth;
    public int PlayerMana;
    public int CurrentPlayerMana;
    public int PlayerDamage;
    public int PlayerDefense;
    public int CurrentPlayerHealth;
    public int PlayersGold;
    public int PlayerLuck;
    public Player(int health, int mana, int damage, int defense, int luck) 
    {
        PlayerHealth = health; 
        PlayerMana = mana;
        CurrentPlayerMana = PlayerMana;
        PlayerDamage = damage; 
        PlayerDefense = defense; 
        CurrentPlayerHealth = PlayerHealth;
        PlayerLuck = luck;
    }
 
    public bool Atack(Monster monster)
    {
        CurrentPlayerMana = CurrentPlayerMana + (int)(PlayerMana * 0.10) <= PlayerMana ? CurrentPlayerMana + (int)(PlayerMana * 0.10) : PlayerMana;
        monster.CurrentMonsterHealth = (PlayerDamage - monster.MonsterDefense) < 0 ? monster.CurrentMonsterHealth :
        (monster.CurrentMonsterHealth - (PlayerDamage - monster.MonsterDefense));
        if (monster.CurrentMonsterHealth < 1) return false;
        else return true; 
    }
    public bool MagicAttack(Monster monster)
    {
        CurrentPlayerMana = CurrentPlayerMana - (int)(PlayerMana * 0.5) >= 0 ? CurrentPlayerMana - (int)(PlayerMana * 0.5) : 0;
        monster.CurrentMonsterHealth = (magicDamage) < 0 ? monster.CurrentMonsterHealth : (monster.CurrentMonsterHealth - magicDamage);
        if (monster.CurrentMonsterHealth < 1) return false;
        else return true;

    }
    public void InformationAboutPlayer(Text text)
    {
        text.text = $"Gold: {PlayersGold},  Health: {CurrentPlayerHealth}/{PlayerHealth}, Mana: {CurrentPlayerMana}/{PlayerMana}" +
        $"          \n Damage: {PlayerDamage}, Defense: {PlayerDefense}";
    }

}
