using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private const float TurnSpeed = 160f;
    private const float Thrust = 17 * 2f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        int turn = ((Input.GetKey(KeyCode.A)) ? -1 : 0) + ((Input.GetKey(KeyCode.D)) ? 1 : 0);
        transform.Rotate(transform.up, turn * TurnSpeed * Time.deltaTime);
        rb.AddForce(transform.forward * Thrust, ForceMode.Force);
    }
}
