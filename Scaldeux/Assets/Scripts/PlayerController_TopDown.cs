using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_TopDown : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;

    [Header("Movement")]
    [SerializeField]
    [Min(0.1f)]
    float movementSpeed = 100f;

    Vector3 _movementDirection;

    void Start()
    {
        
    }


    void Update()
    {
        _movementDirection.x = Input.GetAxisRaw("Horizontal");
        _movementDirection.z = Input.GetAxisRaw("Vertical");
        if(_movementDirection.sqrMagnitude > 1f) 
        {
            _movementDirection.Normalize();
        }
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = _movementDirection * movementSpeed * Time.fixedDeltaTime;    
    }
}
