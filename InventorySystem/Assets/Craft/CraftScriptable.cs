using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "CraftScriptable", order = 1)]
public class CraftScriptable : ScriptableObject
{ 
    public List<ressourceCraft> ressource = new List<ressourceCraft>();

    public string craftingItemName;
    public Sprite CraftingItemImage;
    public string CraftingItemDescription;
}

[Serializable]
public class ressourceCraft
{
    public Item item;
    public int numberItem;
    public ItemPositionCraft positionCraft;
}

public enum ItemPositionCraft
{
    BottomLeft = 0,
    BottomMiddle = 1,
    BottomRigth = 2,

    MiddleLeft = 3,
    Middle = 4,
    MiddleRight = 5,
    
    TopLeft = 6,
    TopMiddle = 7,
    TopRight = 8
}