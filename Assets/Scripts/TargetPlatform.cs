using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlatform : MonoBehaviour
{
    public float rotationDuration = 1f; // Rotation duration
    public float yRotationAmount = 360f; // Amount of rotation around the y axis

    private void Start()
    {
        RotateObjectOnY(); // Call the rotation function to begin rotation
    }

    private void RotateObjectOnY()
    {
        transform.DORotate(new Vector3(0f, yRotationAmount, 0f), rotationDuration, RotateMode.LocalAxisAdd) // Rotate the object around the y axis
            .SetEase(Ease.Linear) // Set the rotation to be linear
            .OnComplete(() => RotateObjectOnY()); // Call the rotation function again once the rotation is complete to create an infinite loop
    }
}
