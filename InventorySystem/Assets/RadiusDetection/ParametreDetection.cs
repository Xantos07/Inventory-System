using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New parametre", menuName = "Dectection Parameter")]
public class ParametreDetection : ScriptableObject
{
    [Range(1f,100f)]
    public float radius;
    [Range(0f,360f)]
    public float angleView;
    public DetectionElement detectionElement;
    public Color colorCircleDetection;
    public Color colorLineDetection;
}

public enum DetectionElement
{
    enemy = 0,
    player = 1,
    item = 2,
    energy = 3,
    Element00 = 4,
}
