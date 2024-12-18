using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timerDuration = 60f; 
    private float currentTime; 
    public TextMeshProUGUI timerText; 

    private bool isTimerRunning = true; 

    public GameObject gameOverPanel;

    void Start()
    {
        currentTime = timerDuration; 
        UpdateTimerUI(); 
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            
            currentTime -= Time.deltaTime;

            
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isTimerRunning = false; 
                TriggerGameOver();
            }

            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TriggerGameOver()
    {
        Debug.Log("Game Over");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
}
