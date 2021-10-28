using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCellMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private const float MoveSpeed = 7f;
    
    
    void FixedUpdate()
    {
        rb.velocity = transform.forward * MoveSpeed;
    }
}
