using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public override void Equip()
    {
        Debug.Log($"Tu as équipé {gameObject.name}");
    }
}
