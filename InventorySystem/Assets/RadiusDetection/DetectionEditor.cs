using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor( typeof(DetectionController))]
public class DetectionEditor : Editor
{
    void OnSceneGUI()
    {
        DetectionController detectionController = (DetectionController) target;

        foreach (ParametreDetection _parametreDetection in detectionController.GetParametreDetections())
        {
            Handles.color = _parametreDetection.colorCircleDetection;
            Handles.DrawWireArc(detectionController.transform.position,  Vector3.up, Vector3.forward, 360f, _parametreDetection.radius);

            Vector3 angleA = detectionController.DirAngle(_parametreDetection.angleView/ 2);
            Vector3 angleB = detectionController.DirAngle(-_parametreDetection.angleView/ 2);
            
            Handles.DrawLine(detectionController.transform.position,detectionController.transform.position + angleA * _parametreDetection.radius);
            Handles.DrawLine(detectionController.transform.position,detectionController.transform.position + angleB * _parametreDetection.radius);
            
            GUIStyle style = new GUIStyle();
            style.normal.textColor = _parametreDetection.colorCircleDetection;
            Vector3 positionDC = new Vector3(detectionController.transform.position.x,detectionController.transform.position.y,detectionController.transform.position.z+_parametreDetection.radius);
            Handles.Label(positionDC, _parametreDetection.detectionElement.ToString(), style);
        }

        if (detectionController.coll == null)
        {
            return;
        }
        foreach (var myColl in detectionController.coll)
        {
            Handles.Label(myColl.transform.position,
                "" + Vector3.Distance(detectionController.transform.position, myColl.transform.position));
        }
    }
}
