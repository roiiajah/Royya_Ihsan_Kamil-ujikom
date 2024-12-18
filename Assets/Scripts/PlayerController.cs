using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 5f; 
    public GameObject foodPrefab; 
    public Transform throwPoint; 
    public float throwForce = 10f; 

    void Update()
    {
        
        MovePlayer();

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowFood();
        }
    }

    void MovePlayer()
    {
        
        float moveDirection = 0;

        if (Input.GetKey(KeyCode.A)) 
        {
            moveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            moveDirection = 1;
        }

        
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
    }

    void ThrowFood()
    {
        
        GameObject food = Instantiate(foodPrefab, throwPoint.position, Quaternion.identity);
        
        
        Rigidbody rb = food.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.forward * throwForce, ForceMode.Impulse);
        }
    }
}

