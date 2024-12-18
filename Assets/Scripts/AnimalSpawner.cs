using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] animalPrefabs; 
    public Transform[] spawnPoints;    
    public float spawnInterval = 2f;   

    [Header("Movement Settings")]
    public float moveSpeed = 5f;       

    private float spawnTimer;

    void Update()
    {
        
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnAnimals(); 
            spawnTimer = spawnInterval; 
        }
    }

    void SpawnAnimals()
    {
        
        foreach (Transform spawnPoint in spawnPoints)
        {
           
            GameObject randomAnimal = animalPrefabs[Random.Range(0, animalPrefabs.Length)];

            
            GameObject newAnimal = Instantiate(randomAnimal, spawnPoint.position, spawnPoint.rotation);

            
            AnimalMovement movement = newAnimal.AddComponent<AnimalMovement>();
            movement.SetMoveSpeed(moveSpeed);
        }
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
