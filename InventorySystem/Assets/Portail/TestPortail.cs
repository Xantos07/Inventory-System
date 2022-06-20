using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPortail : MonoBehaviour
{
    public Vector3[] _newVertices;
    public Vector2[] _newUV; 
    public int[]_newTriangles;
    
   public int numberOfSegments = 360; 
   Vector3[] points;
   
    public Material mat;
    void Start()
    {
        /*
        _newVertices[0] = new Vector3(0,0);
        _newVertices[1] = new Vector3(3,0);
        _newVertices[2] = new Vector3(2,3);
        _newVertices[3] = new Vector3(0,4);
        _newVertices[4] = new Vector3(-2,3);
        _newVertices[5] = new Vector3(-3,0);
        _newVertices[6] = new Vector3(-2,-3);
        _newVertices[7] = new Vector3(0,-4); 
        _newVertices[8] = new Vector3(2,-3);
        
        _newUV[0] = new Vector2(0,0);
        _newUV[1] = new Vector2(3,0);
        _newUV[2] = new Vector2(2,3);
        _newUV[3] = new Vector2(0,4);
        _newUV[4] = new Vector2(-2,3);
        _newUV[5] = new Vector2(-3,0);
        _newUV[6] = new Vector2(-2,-3);
        _newUV[7] = new Vector2(0,-4);
        _newUV[8] = new Vector2(2,-3);

        _newTriangles[0] = 0;
        _newTriangles[1] = 1;
        _newTriangles[2] = 2;
        
        _newTriangles[3] = 0;
        _newTriangles[4] = 2;
        _newTriangles[5] = 3;
        
        //
        _newTriangles[6] = 0;
        _newTriangles[7] = 3;
        _newTriangles[8] = 4;
        
        _newTriangles[9] = 0;
        _newTriangles[10] = 4;
        _newTriangles[11] = 5;
        
        _newTriangles[12] = 0;
        _newTriangles[13] = 5;
        _newTriangles[14] = 6;
        
        _newTriangles[15] = 0;
        _newTriangles[16] = 6;
        _newTriangles[17] = 7;
        
        _newTriangles[18] = 0;
        _newTriangles[19] = 7;
        _newTriangles[20] = 8;
        
        _newTriangles[21] = 0;
        _newTriangles[22] = 8;
        _newTriangles[23] = 1;
        
        
        Mesh mesh = new Mesh();
        
        mesh.vertices = _newVertices;
        mesh.uv = _newUV;
        mesh.triangles = _newTriangles;
        
        GameObject obj = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MeshRenderer>().material = mat;
*/

        
        //points = new Vector3[numberOfSegments+1];
        
        _newVertices = new Vector3[numberOfSegments+2];
        _newUV = new Vector2[numberOfSegments +2];
        _newTriangles = new int[(numberOfSegments ) * 3];
        
        _newVertices[0] = Vector3.zero;
        _newUV[0] = Vector3.zero;
        
        for (int i = 0; i < numberOfSegments; i++)
        {

            float rad = Mathf.Deg2Rad * (360/numberOfSegments) * i;
            /*
points[i] = new Vector3(Mathf.Sin(rad) * 10, Mathf.Cos(rad) * 10,0 );

GameObject a = new GameObject("New object !");
Instantiate(a, points[i], transform.rotation);
*/
            _newVertices[i +1] = new Vector3(Mathf.Sin(rad) * 10,Mathf.Cos(rad) * 10);

            Debug.Log( _newVertices[i +1] );
            _newUV[i +1] = new Vector2(Mathf.Sin(rad) * 10,Mathf.Cos(rad) * 10);

            _newTriangles[i * 3] = 0;
            _newTriangles[i * 3 + 1] = i + 1;
            _newTriangles[i * 3 + 2] = i + 2;

            if (i * 3 + 2 == _newTriangles.Length -1)
            {
                _newTriangles[_newTriangles.Length-1] = 1;
            }
        }

        Mesh mesh = new Mesh();
        
        mesh.vertices = _newVertices;
        mesh.uv = _newUV;
        mesh.triangles = _newTriangles;
        
        GameObject obj = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MeshRenderer>().material = mat;
        
    }
}
