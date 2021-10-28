using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] private GameObject head;
    private List<GameObject> body;
    private GameObject tail;
    
    [SerializeField] private GameObject cellPrefab;
    
    private const float DistanceBetweenCells = 2.4f;
        
    private void Awake()
    {
        body = new List<GameObject>();
        tail = head;
    }

    public void EatFood()
    {
        AppendCellToTail();
    }

    public void DestroySnake()
    {
        foreach (var cell in body)
        {
            Destroy(cell);
        }
        
        ResetSnake();
    }

    private void ResetSnake()
    {
        body.Clear();
        
        head.transform.position = new Vector3(0, 1.5f, 0);
        head.transform.rotation = new Quaternion(0, 0, 0, 0);

        tail = head;
    }
    
    private void AppendCellToTail()
    {
        Transform tailTransform = tail.transform;

        Vector3 newTailPosition = tailTransform.position - tailTransform.forward * DistanceBetweenCells;

        GameObject newTail = Instantiate(cellPrefab, newTailPosition, tail.transform.rotation, gameObject.transform);
        newTail.name = $"Cell ({body.Count})";
        newTail.GetComponent<HingeJoint>().connectedBody = tail.GetComponent<Rigidbody>();

        tail = newTail;
        body.Add(newTail);
    }
}
