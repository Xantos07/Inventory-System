using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

//[System.Serializable]
//public class Item 
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
        Debug.Log("Je bois une potion");   
    }
    
}

public abstract class Weapon : Item
{
     int damage;
    public int strength { private get; set; }
    public int get_damage() { return damage; }
    
    
    public virtual void Equip()
    {
        Debug.Log($"Tu as équipé une arme");
    }
    
}


public abstract class Equipement : Item
{
    public virtual void Equip()
    {
        Debug.Log("Je suis entrain de m'équiper");   
    }
    
}


