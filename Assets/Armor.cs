using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public override string Name { get; }
    public override int Price { get; set; }
    public override string Rarity { get; set; }
    public string Type { get; set; }
}
