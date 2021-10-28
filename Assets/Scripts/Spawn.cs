using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    private const float FieldSize = 38f;
    private const float FoodSize = 1.5f;
    private const float Delta = 2f;
    private const float FoodY = 1.25f;
    
    private bool _isTouchingSnake = false;

    public void SpawnNewFood()
    {
        GameObject newFood = Instantiate(gameObject);
        newFood.transform.position = GetRandomPosition();

        while (_isTouchingSnake)
        {
            newFood.transform.position = GetRandomPosition();
            _isTouchingSnake = false;
        }

        newFood.GetComponent<BoxCollider>().isTrigger = false;
        newFood.GetComponent<Rigidbody>().useGravity = true;
    }

    private Vector3 GetRandomPosition()
    {
        float spawArea = FieldSize / 2 - FoodSize / 2 - Delta;
        
        return new Vector3(
            Random.Range(-spawArea, spawArea),
            FoodY,
            Random.Range(-spawArea, spawArea));
    }
    
    private void OnCollisionEnter(Collision other)
    {
        _isTouchingSnake = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _isTouchingSnake = false;
    }
}
