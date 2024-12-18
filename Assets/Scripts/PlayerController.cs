using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variabel untuk gerakan player
    public float moveSpeed = 5f; // Kecepatan gerak kiri/kanan
    public GameObject foodPrefab; // Prefab objek makanan
    public Transform throwPoint; // Titik spawn makanan
    public float throwForce = 10f; // Kekuatan lemparan

    void Update()
    {
        // Fungsi untuk bergerak kiri/kanan
        MovePlayer();

        // Fungsi untuk melempar objek makanan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowFood();
        }
    }

    void MovePlayer()
    {
        // Input tombol A dan D untuk pergerakan
        float moveDirection = 0;

        if (Input.GetKey(KeyCode.A)) // Tombol A → gerak ke kiri
        {
            moveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D)) // Tombol D → gerak ke kanan
        {
            moveDirection = 1;
        }

        // Gerakkan player dalam sumbu X
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
    }

    void ThrowFood()
    {
        // Spawn objek makanan di titik lemparan
        GameObject food = Instantiate(foodPrefab, throwPoint.position, Quaternion.identity);
        
        // Tambahkan gaya (force) ke makanan agar dilempar ke depan
        Rigidbody rb = food.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.forward * throwForce, ForceMode.Impulse);
        }
    }
}

