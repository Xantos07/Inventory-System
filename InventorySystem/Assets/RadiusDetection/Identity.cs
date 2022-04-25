using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identity : MonoBehaviour
{
    [SerializeField] private DetectionElement _detectionElement;

    public DetectionElement GetDetectionElement()
    {
        return _detectionElement;
    }
}
