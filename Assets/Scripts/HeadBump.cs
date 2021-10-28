using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBump : MonoBehaviour
{
    [SerializeField] private SnakeManager _snakeManager;
    [SerializeField] private Spawn _spawn;
    private const string FirstCellName = "Cell (0)";

    private void Start()
    {
        _spawn.SpawnNewFood();
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject collider = other.gameObject;

        if (collider.CompareTag("Food"))
        {
            Destroy(collider);
            _snakeManager.EatFood();
            _spawn.SpawnNewFood();
        }
        else if (collider.CompareTag("Border") 
                 || (collider.CompareTag("BodyCell") && collider.name != FirstCellName))
        {
            _snakeManager.DestroySnake();
        }
    }
}
