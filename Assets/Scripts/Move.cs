using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject jointPoint;
    private const float MoveSpeed = 7f;
    private const float TurnSpeed = 2f / 3f * 3.1415926f;
    // private float MoveThrust = 1f;
    private const float TurnThrust = 17f;

    private void Start()
    {
        rb.velocity = new Vector3(0, 0, MoveSpeed);
        rb.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int turn = ((Input.GetKey(KeyCode.A)) ? -1 : 0) + ((Input.GetKey(KeyCode.D)) ? 1 : 0);
        // float turn = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, turn * TurnSpeed * Time.deltaTime);
        // rb.AddForce(transform.forward * MoveThrust, ForceMode.Force);
        // rb.AddTorque(turn * transform.up * TurnThrust, ForceMode.Force);
        rb.angularVelocity = turn * new Vector3(0, TurnSpeed, 0);
        rb.velocity = transform.forward * MoveSpeed;
    }
}
