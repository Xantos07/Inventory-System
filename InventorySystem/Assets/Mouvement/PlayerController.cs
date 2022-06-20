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
    [SerializeField] private Animator anim;
    
    float distanceMax;
    bool endingMovement = true;
    private Vector3 dir;
    private void Start()
    {
        endingMovement = true;
        anim = GetComponent<Animator>();
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
                 dir =  positionMouse - transform.position;
            }
            
            endingMovement = false;
        }

        if (!endingMovement)
            Move();
    }

    public void Move()
    {
        float dist = Vector3.Distance(positionMouse, transform.position);

        transform.position += new Vector3(dir.x,0,dir.z) * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0,dir.z),transform.up);
        
        anim.SetBool("Walk", true);
        
        if (dist <= .9f)
        {
            dist = 0;
            anim.SetBool("Walk", false);
            endingMovement = true;
        }
    }

    public void TakeObject()
    {
        anim.SetTrigger("PickUp");
    }
}
