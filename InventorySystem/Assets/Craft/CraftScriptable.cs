using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Craft", menuName = "Craft")]
public abstract class CraftScriptable : ScriptableObject
{ 
    public List<ressourceCraft> ressourceCraft = new List<ressourceCraft>();
}

[Serializable]
public class ressourceCraft
{
    public Item item;
    public int numberItem;
}