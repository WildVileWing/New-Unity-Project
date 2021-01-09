using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item 
{
    public abstract string Name { get; }
    public abstract int Price { get; set; }
    public abstract string Rarity { get; set; }

}
