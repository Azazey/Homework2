using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamRotation : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _rotationSpeed;
    
    private void FixedUpdate ()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseRotation = Input.GetAxis("Mouse X");
        _transform.Rotate(0, mouseRotation * _rotationSpeed, 0);
    }
}
