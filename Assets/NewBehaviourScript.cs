using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject panel;
    public Text textPanel;
    public Text playerText;
    public Monster currentMonster;

    private Monster[] monsters;
    private Weapon[] weapons;
    private Material[] materials;

    public Player player = new Player(20, 10, 2, 0, 10);
    public void MagicAttack()
    {
        player.CurrentPlayerMana -= (int)(player.PlayerMana * 0.5);
        if (currentMonster.PlayerMagicAttack((int)(player.PlayerMana * 0.25)))
        {
            if (!player.MonsterAtack(currentMonster.MonsterDamage))
            {
                Restart();
            }
        }
        else
        {
            currentMonster.RandomDrop();
            player.PlayersGold += currentMonster.RandomGold(player.PlayerLuck);
            Spawn();
        }
        currentMonster.InformationAboutMonster(textPanel);
        PlayerInformation();

    }
    public void Attack()
    {
        if (currentMonster.PlayerAttack(player.PlayerDamage))
        {
            if (!player.MonsterAtack(currentMonster.MonsterDamage))
            {
                Restart();
            }
        }
        else
        {
            currentMonster.RandomDrop();
            player.PlayersGold += currentMonster.RandomGold(player.PlayerLuck);
            Spawn();
        }
        currentMonster.InformationAboutMonster(textPanel);
        PlayerInformation();

    }
    public void PlayerInformation()
    {
        player.InformationAboutPlayer(playerText);
    }
    public void Restart()
    {
        player.CurrentPlayerMana = player.PlayerMana;
        player.CurrentPlayerHealth = player.PlayerHealth;
        player.PlayersGold = 0;
        Spawn();
    }

    void GenerateItems()
    {
        Material material1 = new Material("Goblin Ear", "Common", 5);
        Material material2 = new Material("Orc's Fang", "Common", 10);
        Material material3 = new Material("Rat Tail", "Trash", 5);
        Material material4 = new Material("Bear Hide", "Uncommon", 20);
        Material material5 = new Material("Doubloon", "Rare", 50);
        Material material6 = new Material("Crow Feather", "Rare", 75);

        Weapon weapon1 = new Weapon("Steel Sword", "Melee Weapon", "Uncommon", 100, 1, 3);
        Weapon weapon2 = new Weapon("Cutlass", "Melee Weapon", "Rare", 675, 3, 5);
        Weapon weapon3 = new Weapon("Sword of Kain the Betrayer", "Melee Weapon", "Unidentified", 0, 5, 10);


        Dictionary<Item, int> DropFromGoblin = new Dictionary<Item, int>()
        {
            { material1,100 },
        };
        Dictionary<Item, int> DropFromOrc = new Dictionary<Item, int>()
        {
            { material1,100 },
        };
        Dictionary<Item, int> DropFromRat = new Dictionary<Item, int>()
        {
            { material1,100 },
        };
        Dictionary<Item, int> DropFromBear = new Dictionary<Item, int>()
        {
            { material1,100 },
        };
        Dictionary<Item, int> DropFromPirat = new Dictionary<Item, int>()
        {
            { material1,100 },
        };
        Dictionary<Item, int> DropFromCrow = new Dictionary<Item, int>()
        {
            { material1,90 },
            { material5,9 },
            { weapon3, 1 },
        };


        Monster monster1 = new Monster("Goblin", 10, 2, 0, 100, DropFromGoblin);
        Monster monster2 = new Monster("Orc", 20, 2, 1, 100, DropFromOrc);
        Monster monster3 = new Monster("Rat", 5, 1, 0, 100, DropFromRat);
        Monster monster4 = new Monster("Bear", 10, 2, 1, 100, DropFromBear);
        Monster monster5 = new Monster("Pirat", 15, 2, 1, 100, DropFromPirat);
        Monster monster6 = new Monster("Crow", 5, 1, 0, 100, DropFromCrow);

        monsters = new Monster[] { monster1, monster2, monster3, monster4, monster5, monster6 };
        materials = new Material[] { material1, material2, material3, material4, material5, material6 };
        weapons = new Weapon[] { weapon1, weapon2, weapon3 };
    }
    void Spawn()
    {
        currentMonster = new Monster (monsters[Random.Range(0, monsters.Length)]);
        currentMonster.InformationAboutMonster(textPanel);
    }
    void Start()
    {
        GenerateItems();
        Spawn();
        PlayerInformation(); 
    }


    void Update()
    {
        
    }
}
