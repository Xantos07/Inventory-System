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

    private Dictionary<float, GameObject> testDis = new Dictionary<float, GameObject>();
    private void Update()
    {
        DetectionElements();
    }

    public void DetectionElements()
    {
        testDis.Clear();
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
                        testDis.Add (dist, coll[j].gameObject);
                    }
                }
                
                if (testDis.Count != 0)
                {
                    var myList = testDis.ToList();

                    myList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
                    
                    foreach (var value in myList)
                    {
                        Debug.Log(value + " object : " + myList[myList.Count - 1].Value.name);
                    }
                }

            }
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
