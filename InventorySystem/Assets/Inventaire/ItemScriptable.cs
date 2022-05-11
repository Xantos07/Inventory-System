using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public abstract class ItemScriptable : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
}

public class Ressource : ItemScriptable
{

}

public class Weapon : ItemScriptable
{

}

public class Tool : ItemScriptable
{

}
