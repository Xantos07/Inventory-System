﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
[System.Serializable]
public class DetectionController : MonoBehaviour
{
    [SerializeField]
    private List<ParametreDetection> parametreDetections;
    public Collider[] coll {  get; private set; }
    private Dictionary<GameObject, float> elementDetected = new Dictionary<GameObject, float>();

    [SerializeField]
    private Interaction interaction;

    private float dist;

    void Start()
    {
        interaction = GetComponent<Interaction>();
    }
    private void Update()
    {
        DetectionElements();
    }

    public void DetectionElements()
    {
        for (int i = 0; i < parametreDetections.Count; i++)
        {
            coll = Physics.OverlapSphere(transform.position, parametreDetections[i].radius);  
             
            for (int j = 0; j < coll.Length; j++)
            {
                Identity identity = coll[j].GetComponent<Identity>();
                Interactable interactable = coll[j].GetComponent<Interactable>();

                Vector3 collDist =  coll[j].transform.position - transform.position;
                dist = Vector3.Distance (transform.position, coll[j].transform.position);

                if (interactable == null || identity == null )
                {
                    continue;
                }

                if (!interaction.GetInteractionElement().Contains(identity.GetDetectionElement())) 
                {
                       // Debug.Log("Mauvais item : " + identity.gameObject.name);
                        continue;
                }

                if (!InRangeZone(parametreDetections[i].angleView, collDist))
                {
                    if (elementDetected.ContainsKey(coll[j].gameObject))
                    {
                        elementDetected.Remove(coll[j].gameObject);   
                    }
                    
                    continue;
                }
                

                if (identity.GetDetectionElement() == parametreDetections[i].detectionElement)
                {
                    Debug.DrawLine(transform.position,coll[j].transform.position, parametreDetections[i].colorLineDetection);
                    
                    if (!elementDetected.ContainsKey(coll[j].gameObject))
                    {
                        elementDetected.Add (coll[j].gameObject,dist);   
                        continue;
                    }

                    elementDetected[coll[j].gameObject] = dist;
                }

            }
            NearestElement(parametreDetections[i].radius);
        }
    }
    
    public void NearestElement(float _dist)
    {
        if (elementDetected.Count != 0)
        {            
            var myList = elementDetected.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            
            if (myList[0].Key == null)
                return;
            
            interaction.GetPanelE().transform.position = myList[0].Key.gameObject.transform.position;
            //Debug.Log( "pair1.Key : " + myList[0].Key + " object : " + myList[0].Value);

            interaction.SetObjectInteratable(myList[0].Key.GetComponent<Interactable>());
            
            if (myList[0].Value >= _dist)
            {
                elementDetected.Remove(myList[0].Key );
            }

            return;
        }
        
        interaction.SetObjectInteratable(null);
        interaction.GetPanelE().transform.position = new Vector3(0, 0, 0);
        
    }

    public void RemoveObjectInterractable(GameObject _obj)
    { 
        elementDetected.Remove(_obj);
    }
    
    public bool InRangeZone(float _angleInDegree, Vector3 _directionObject)
    {
        if (Vector3.Angle (transform.forward, _directionObject) < _angleInDegree / 2)
        {
            return true;
        }
        
        return false;
    }

    public Vector3 DirAngle(float _angleInDegree)
    {
        return new Vector3(Mathf.Sin((_angleInDegree+transform.eulerAngles.y) * Mathf.Deg2Rad), 0, Mathf.Cos((_angleInDegree+transform.eulerAngles.y)  * Mathf.Deg2Rad));
    }
    
    public List<ParametreDetection> GetParametreDetections()
    {
        return parametreDetections;
    }
}
