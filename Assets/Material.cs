using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : Item
{
    public override string Name { get; }
    public override int Price { get; set; }
    public override string Rarity { get; set; }
    public Material ( string name, string rarity, int price) { Name = name; Rarity = rarity; Price = price; }

}
