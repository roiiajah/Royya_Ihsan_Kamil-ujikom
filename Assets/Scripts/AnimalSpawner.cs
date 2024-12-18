using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject animalPrefab; 
    public Transform spawnPoint; 
    public float spawnInterval = 2f; 

    [Header("Movement Settings")]
    public float moveSpeed = 5f; 

    private float spawnTimer;

    void Update()
    {
        
        spawnTimer -= Time.deltaTime;

        // Jika waktunya spawn
        if (spawnTimer <= 0f)
        {
            SpawnAnimal();
            spawnTimer = spawnInterval; 
        }
    }

    void SpawnAnimal()
    {
        
        GameObject newAnimal = Instantiate(animalPrefab, spawnPoint.position, spawnPoint.rotation);

        
        AnimalMovement movement = newAnimal.AddComponent<AnimalMovement>();
        movement.SetMoveSpeed(moveSpeed);
    }
}

public class AnimalMovement : MonoBehaviour
{
    private float moveSpeed;

   
    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    void Update()
    {
        
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        
        if (transform.position.z < -20f) 
        {
            Destroy(gameObject);
        }
    }
}
