using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static GameManager Instance;
    public GameObject LevelCompleted;
    private void Awake()
    {
        Instance=this;

    }
   
    public void GameOver()
    {
        gameOverPanel.SetActive(true);

        
        Time.timeScale = 0f;
    }
    public void Restart()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     

        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

    }
   

}
