using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public void pickup()
    {
        
    }
}

public interface IInteractable
{
    void pickup();
}
