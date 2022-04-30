using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemScriptable : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
}
