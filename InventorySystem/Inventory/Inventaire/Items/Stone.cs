using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Stone : MonoBehaviour, Ressource
public class Stone : Ressource 
{
    public virtual void Drop()
    {
        Debug.Log("Je suis entrain de Drop mon item");   
    }

}
