using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHealth : MonoBehaviour
{
    public Slider healthBar; // Referensi ke Slider health bar
    public int health = 0;
    public int maxHealth = 100;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food")) // Jika objek lemparan menyentuh
        {
            AddHealth(20); // Tambah health
            Destroy(other.gameObject); // Hancurkan objek lemparan
        }
    }

    void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth); // Batasi antara 0 dan maxHealth
        healthBar.value = health; // Update health bar UI

        if (health >= maxHealth)
        {
            Destroy(gameObject); // Hapus hewan jika health penuh
        }
    }
}

