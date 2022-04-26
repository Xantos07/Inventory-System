using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    [SerializeField]
    private List<ParametreDetection> parametreDetections;

    private Collider[] coll;

    private Dictionary<GameObject, float> elementDetected = new Dictionary<GameObject, float>();
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
                 
                Vector3 collDist =  coll[j].transform.position - transform.position;
                 
                if(InRangeZone(parametreDetections[i].angleView, collDist))
                {
                    if (identity != null && identity.GetDetectionElement() == parametreDetections[i].detectionElement)
                    {
                        Debug.DrawLine(transform.position,coll[j].transform.position, parametreDetections[i].colorLineDetection);  
                        
                        float dist = Vector3.Distance (transform.position, coll[j].transform.position);

                        //A revoir pour refractor
                        if (!elementDetected.ContainsKey(coll[j].gameObject))
                        {
                            elementDetected.Add (coll[j].gameObject,dist);   
                        }

                        if (elementDetected.ContainsKey(coll[j].gameObject))
                        {
                            elementDetected[coll[j].gameObject] = dist;
                        }
                    }
                }

            }
        }

        NearestElement();
    }

    public void NearestElement()
    {
        if (elementDetected.Count != 0)
        {
            var myList = elementDetected.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            Debug.Log( "pair1.Key : " + myList[0].Key + " object : " + myList[0].Value);
        }
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
        return new Vector3(Mathf.Sin(_angleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(_angleInDegree  * Mathf.Deg2Rad));
    }
    
    public List<ParametreDetection> GetParametreDetections()
    {
        return parametreDetections;
    }

}
