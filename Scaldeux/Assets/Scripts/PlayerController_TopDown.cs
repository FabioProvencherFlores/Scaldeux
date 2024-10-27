using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_TopDown : MonoBehaviour
{
    [SerializeField]
    new Rigidbody2D rigidbody2D;

    [Header("Movement")]
    [SerializeField]
    [Min(0.1f)]
    float movementSpeed = 100f;

    Vector2 _movementDirection;

    void Start()
    {
        
    }


    void Update()
    {
        _movementDirection.x = -Input.GetAxisRaw("Horizontal");
        _movementDirection.y = Input.GetAxisRaw("Vertical");
        if(_movementDirection.sqrMagnitude > 1f) 
        {
            _movementDirection.Normalize();
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = _movementDirection * movementSpeed * Time.fixedDeltaTime;    
    }
}
