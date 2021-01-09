using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 
public class Monster
{
    public string MonsterName;
    public int MonsterHealth;
    public int MonsterDamage;
    public int MonsterDefense;
    public int CurrentMonsterHealth;
    public int MonsterGold;
    public Dictionary<Item, int> Items;

    public NewBehaviourScript Temp;



    public Monster(string name, int health, int damage, int defense,int monsterGold, Dictionary <Item, int>items ) 
    { 
        MonsterName = name; 
        MonsterHealth = health; 
        MonsterDamage = damage; 
        MonsterDefense = defense; 
        CurrentMonsterHealth = health;
        MonsterGold = monsterGold;
        Items = items;
    }
    public Monster(Monster monster)
    {
        MonsterName = monster.MonsterName;
        MonsterHealth = monster.MonsterHealth;
        MonsterDamage = monster.MonsterDamage;
        MonsterDefense = monster.MonsterDefense;
        CurrentMonsterHealth = monster.MonsterHealth;
        MonsterGold = monster.MonsterGold;
        Items = monster.Items;
    }
    public bool PlayerAttack(int damage)
    {   
        Temp.player.CurrentPlayerMana += (int)(Temp.player.PlayerMana * 0.10);
        if((Temp.player.CurrentPlayerMana > Temp.player.PlayerMana) || (Temp.player.CurrentPlayerMana < Temp.player.PlayerMana))
        {
            Temp.player.CurrentPlayerMana = Temp.player.PlayerMana;
        }
        CurrentMonsterHealth = (damage - MonsterDefense) < 0 ? CurrentMonsterHealth : (CurrentMonsterHealth - (damage - MonsterDefense));
        if (CurrentMonsterHealth < 1) return false;
        else return true; 
    }
    public bool PlayerMagicAttack(int magicDamage)
    {
        Temp.player.CurrentPlayerMana -= (int)(Temp.player.PlayerMana * 0.5);
        if ((Temp.player.CurrentPlayerMana > Temp.player.PlayerMana) || (Temp.player.CurrentPlayerMana < Temp.player.PlayerMana))
        {
            Temp.player.CurrentPlayerMana = Temp.player.PlayerMana;
        }
        CurrentMonsterHealth = (magicDamage) < 0 ? CurrentMonsterHealth : (CurrentMonsterHealth - magicDamage);
        if (CurrentMonsterHealth < 1) return false;
        else return true;

    }
    public void InformationAboutMonster(Text text)
    {
        text.text = $"Name: {MonsterName},  Health: {CurrentMonsterHealth}/{MonsterHealth},\n Damage: {MonsterDamage}, Defense: {MonsterDefense}";
    }
    public int RandomGold(int luck)
    {
        return Random.Range(0, (int)(MonsterGold + MonsterGold*(0.01*luck)));
    }
    public List<Item> RandomDrop()
    {
        int currentChance = Random.Range(0, 101);
        List<Item> droppedItems = new List<Item>();

        foreach(Item item in Items.Keys)
        {
            if(Items[item] > currentChance)
            {
                droppedItems.Add(item);
            }
        }
        return droppedItems;
    }
    

}