using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private const float MoveSpeed = 7f;
    private const float TurnSpeed = 2f / 3f * 3.1415926f;

    private void Start()
    {
        rb.velocity = new Vector3(0, 0, MoveSpeed);
        rb.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int turn = ((Input.GetKey(KeyCode.A)) ? -1 : 0) + ((Input.GetKey(KeyCode.D)) ? 1 : 0);
        rb.angularVelocity = turn * new Vector3(0, TurnSpeed, 0);
        rb.velocity = transform.forward * MoveSpeed;
    }
}
