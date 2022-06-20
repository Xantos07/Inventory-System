using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CraftScriptable : MonoBehaviour
{ 
    public List<ressourceCraft> ressource = new List<ressourceCraft>();
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
    BottomRigth = 0,
    BottomMiddle = 1,
    BottomLeft = 2,
    
    MiddleRight = 3,
    Middle = 4,
    MiddleLeft = 5,
    
    TopRight = 6,
    TopMiddle = 7,
    TopLeft = 8
}