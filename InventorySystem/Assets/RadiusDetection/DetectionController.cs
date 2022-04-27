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
    [SerializeField]
    private Collider[] coll;

    private Dictionary<GameObject, float> elementDetected = new Dictionary<GameObject, float>();
    
    /*Zone de test*/
    public List<GameObject> elementDetectedTEST = new List<GameObject>();
    public List<float> elementDetectedfloatTEST = new List<float>();
    [SerializeField] private GameObject e;
    private void Update()
    {
        DetectionElements();

        /*Zone de test*/
        elementDetectedTEST.Clear();
        elementDetectedfloatTEST.Clear();
        foreach (var VARIABLE in elementDetected.Keys)
        {
            elementDetectedTEST.Add(VARIABLE);
        }   
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            foreach (var VARIABLE in elementDetected.Keys)
            {
                Debug.LogWarning(VARIABLE);
            }
            
        }

        foreach (var VARIABLE in elementDetected.Values)
        {
            elementDetectedfloatTEST.Add(VARIABLE);
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

                if(!InRangeZone(parametreDetections[i].angleView, collDist))
                {
                    //Debug.Log($"tu es hors de ma ligne de mire");
                    continue;
                }
                
                if (identity == null || identity.GetDetectionElement() != parametreDetections[i].detectionElement)
                {
                    Debug.Log($"parametreDetections[i].detectionElement {identity.name}");
                    continue;
                }
                Debug.Log($"tu es {identity.name}");
                Debug.DrawLine(transform.position,coll[j].transform.position, parametreDetections[i].colorLineDetection);  
                    
                float dist = Vector3.Distance (transform.position, coll[j].transform.position);
                
                
                //A revoir pour refractor
                if (!elementDetected.ContainsKey(coll[j].gameObject))
                {         
                    Debug.LogWarning($"Pourquoi tu le rajoutes ? !");
                    elementDetected.Add (coll[j].gameObject,dist);   
                }
                else
                {
                    elementDetected[coll[j].gameObject] = dist;
                }
                
                NearestElement(parametreDetections[i].radius);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var j in coll)
        {
#if UNITY_EDITOR
            Handles.Label(j.transform.position,
                "" + Vector3.Distance(transform.position, j.transform.position).ToString());
#endif   
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

           if (myList[0].Value >= _dist)
           {
               elementDetected.Remove(myList[0].Key );
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
