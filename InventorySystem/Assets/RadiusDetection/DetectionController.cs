using System;
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
    private Collider[] coll;
    private Dictionary<GameObject, float> elementDetected = new Dictionary<GameObject, float>();
    
    [SerializeField] private GameObject e;
    [SerializeField] private Interactable objectInteratable;
    private float dist;
    private void Update()
    {
        DetectionElements();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(objectInteratable != null)
               Destroy(objectInteratable.gameObject);
        }
    }

    public void DetectionElements()
    {
        for (int i = 0; i < parametreDetections.Count; i++)
        {
            coll = Physics.OverlapSphere(transform.position, parametreDetections[i].radius);  
             
            for (int j = 0; j < coll.Length; j++)
            {
                Identity identity = coll[j].GetComponent<Identity>();
                IInteractable interactable = coll[j].GetComponent<IInteractable>();
                 
                Vector3 collDist =  coll[j].transform.position - transform.position;
                dist = Vector3.Distance (transform.position, coll[j].transform.position);
                
                if(InRangeZone(parametreDetections[i].angleView, collDist))
                {
                    if (identity != null && identity.GetDetectionElement() == parametreDetections[i].detectionElement)
                    {
                        Debug.DrawLine(transform.position,coll[j].transform.position, parametreDetections[i].colorLineDetection);

                        //A revoir pour refractor
                        if (!elementDetected.ContainsKey(coll[j].gameObject))
                        {
                            elementDetected.Add (coll[j].gameObject,dist);   
                        }
                        else
                        {
                            elementDetected[coll[j].gameObject] = dist;
                        }
                    }
                }

                
                if (!InRangeZone(parametreDetections[i].angleView, collDist) || dist >= parametreDetections[i].radius)
                {
                    if (elementDetected.ContainsKey(coll[j].gameObject))
                    {
                        elementDetected.Remove(coll[j].gameObject);   
                    }
                }
                

                NearestElement(parametreDetections[i].radius);
            }
        }
    }
    
    public void NearestElement(float _dist)
    {
        if (elementDetected.Count != 0)
        {
            var myList = elementDetected.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            e.transform.position = myList[0].Key.gameObject.transform.position;
            Debug.Log( "pair1.Key : " + myList[0].Key + " object : " + myList[0].Value);

            objectInteratable = myList[0].Key.GetComponent<Interactable>();
            
            if (myList[0].Value >= _dist)
            {
                elementDetected.Remove(myList[0].Key );
            }
        }
        else
        {
            objectInteratable = null;
            e.transform.position = new Vector3(0, 0, 0);
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
    
    private void OnDrawGizmosSelected()
    {
        if (coll.Length == 0)
        {
            return;
        }
        foreach (var j in coll)
        {
#if UNITY_EDITOR
            Handles.Label(j.transform.position,
                "" + Vector3.Distance(transform.position, j.transform.position).ToString());
#endif   
        }
    }
}
