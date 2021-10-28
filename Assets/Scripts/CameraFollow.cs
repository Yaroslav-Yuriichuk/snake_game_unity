using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject snakeHead;
    private Vector3 _previousPosition;
    
    void Start()
    {
        _previousPosition = snakeHead.transform.position;
    }
    
    void Update()
    {
        Vector3 snakeHeadPosition = snakeHead.transform.position;
        transform.position += snakeHeadPosition - _previousPosition;
        _previousPosition = snakeHeadPosition;
    }
}
