using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PropellerMover : MonoBehaviour
{
    [SerializeField] private Transform _propeller;
    
    private AirPlaneMovement _airPlaneMovement;
    private Transform _transform;

    private void Awake()
    {
        _airPlaneMovement = gameObject.GetComponent<AirPlaneMovement>();
    }
    
    private void FixedUpdate()
    {
        PropellerSpinning();
    }
    
    private void PropellerSpinning()
    {
        _propeller.Rotate(0, _airPlaneMovement.EnginePower, 0);
    }
}
