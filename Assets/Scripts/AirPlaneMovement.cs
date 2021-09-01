using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class AirPlaneMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speedValue;
    [SerializeField] private float _acceleration;
    [SerializeField] private int _enginePower;
    [SerializeField] private UITextWriter _uiTextWriter;
    [SerializeField] private float _turningValue;
    
    private int _enginePowerChangeValue = 1;
    
    public int EnginePower => _enginePower;

    private void FixedUpdate()
    {
        PlaneHorizontalVerticalMoving();
        EnginePowerChanger();
        PlaneTurning();
        Falling();
    }

    private void PlaneHorizontalVerticalMoving()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        _rigidbody.AddRelativeForce(Vector3.forward * _enginePower);
        _rigidbody.AddRelativeForce(Vector3.forward * _speedValue * _acceleration * Mathf.Clamp(
            _enginePower, 0, 1), ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(vertical * Mathf.Clamp(
            _enginePower, 0, 1) * _turningValue , 0, 0, ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(0,0,-horizontal * Mathf.Clamp(
            _enginePower, 0, 1) * _turningValue, ForceMode.VelocityChange);
        _uiTextWriter.VehicleSpeedWriter(
            Vector3.forward.z * _enginePower + Vector3.forward.z * _speedValue * _acceleration * Mathf.Clamp(
                _enginePower, 0, 1));
    }

    private void PlaneTurning()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _rigidbody.AddRelativeTorque(0, -_turningValue * Mathf.Clamp(
                _enginePower, 0, 1), 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.E))
        {
            _rigidbody.AddRelativeTorque(0, _turningValue * Mathf.Clamp(
                _enginePower, 0, 1), 0, ForceMode.VelocityChange);
        }
    }

    private void Falling()
    {
        if (_enginePower == 0)
        {
            _rigidbody.drag = 1;
            _rigidbody.angularDrag = 1;
        }
        else if (_enginePower <= 35)
        {
            _acceleration = 0;
            _rigidbody.drag = 3;
            _rigidbody.angularDrag = 20;
        }
        else if (_enginePower >= 35)
        {
            _acceleration = 4;
            _rigidbody.drag = 20;
            _rigidbody.angularDrag = 20;
        }
    }

    private void EnginePowerChanger()
    {
        _uiTextWriter.EnginePowerWriter(_enginePower);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _enginePower += _enginePowerChangeValue;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _enginePower -= _enginePowerChangeValue;
        }
        _enginePower = Mathf.Clamp(_enginePower, 0, 100);
    }
}
