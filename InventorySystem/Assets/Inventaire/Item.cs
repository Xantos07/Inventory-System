﻿using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string name;
    public string description;
    public int amount;
    public int amountStockableMax;
    public Sprite icon;
    
    public virtual void DropItem()
    {
        Debug.Log("Drop mon item");   
    }
}

public abstract class Ressource : Item
{

}

public abstract class Potion : Item
{
    public virtual void Use()
    {
        Debug.Log("Je suis entrain d'équiper mon item");   
    }
}

public abstract class Weapon : Item
{
    public virtual void Equip()
    {
        Debug.Log($"Tu as équipé une arme");
    }
}


public abstract class Equipement : Item
{
    public virtual void Equip()
    {
        Debug.Log("Je suis entrain d'équiper mon item");   
    }
}


