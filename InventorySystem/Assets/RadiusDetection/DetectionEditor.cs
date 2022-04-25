using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor( typeof(DetectionController))]
public class DetectionEditor : Editor
{
    void OnSceneGUI()
    {
        DetectionController dc = (DetectionController) target;

        foreach (ParametreDetection _parametreDetection in dc.GetParametreDetections())
        {
            Handles.color = _parametreDetection.colorCircleDetection;
            Handles.DrawWireArc(dc.transform.position,  Vector3.up, Vector3.forward, 360f, _parametreDetection.radius);

            Vector3 angleA = dc.DirAngle(_parametreDetection.angleView/ 2);
            Vector3 angleB = dc.DirAngle(-_parametreDetection.angleView/ 2);
            
            Handles.DrawLine(dc.transform.position,dc.transform.position + angleA * _parametreDetection.radius);
            Handles.DrawLine(dc.transform.position,dc.transform.position + angleB * _parametreDetection.radius);
        }
    }
}
