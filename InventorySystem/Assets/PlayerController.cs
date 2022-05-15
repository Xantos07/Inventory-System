using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Vector3 positionMouse;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float distanceToRay = 100f;
    [SerializeField]
    private AnimationCurve inertie;
    
    float distanceMax;
    bool endingMovement = true;
    private void Start()
    {
        endingMovement = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, distanceToRay))
            {
                positionMouse = hit.point;
                
                distanceMax = Vector3.Distance(positionMouse, transform.position);
            }
            
            endingMovement = false;
        }

        if (!endingMovement)
            Move();
    }

    public void Move()
    {
        Vector3 dir =  positionMouse - transform.position;
        float dist = Vector3.Distance(positionMouse, transform.position);
        float factor = 1 - dist / distanceMax;

        transform.position += new Vector3(dir.x,0,dir.z) * speed * Time.deltaTime * inertie.Evaluate(factor);
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0,dir.z),transform.up);
        
        if (dist <= 0.6f)
        {
            endingMovement = true;
        }
    }
}
