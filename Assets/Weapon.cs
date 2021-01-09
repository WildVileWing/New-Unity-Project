using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public override string Name { get; }
    public override int Price { get; set; }
    public override string Rarity { get; set; }
    public string Type { get; set; }
    public int MinimumDamage { get; set; }
    public int MaximumDamage { get; set; }
    public Weapon(string name, string type, string rarity, int price,  int minimumDamage, int maximumDamage)
    {
        Name = name;
        Type = type;
        Rarity = rarity;
        Price = price;
        MinimumDamage = minimumDamage;
        MaximumDamage = maximumDamage;
        
    }

}
