using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatMovement : MonoBehaviour
{
    Rigidbody _rb;
    public bool _playerControlled = false;
    [SerializeField, Range(0, 1)]
    float _turningHeel = 0.35f;

    public float forwardSpeed = 0f;
    public float turnSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        var forcePosition = _rb.position;
        _rb.AddForceAtPosition(transform.forward *  forwardSpeed, forcePosition, ForceMode.Acceleration);

        if (_playerControlled)
            turnSpeed += (Input.GetKey(KeyCode.A) ? -1f : 0f) + (Input.GetKey(KeyCode.D) ? 1f : 0f);
        var rotVec = transform.up + _turningHeel * transform.forward;
        _rb.AddTorque(rotVec * turnSpeed, ForceMode.Acceleration);
    }
}
