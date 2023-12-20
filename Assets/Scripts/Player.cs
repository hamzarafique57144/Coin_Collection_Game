using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class Player : MonoBehaviour
{
    
    private GameManager gameManager;
   public GameObject winT;
    public GameObject gameoverPanel;
    int coinCollect=0;
    public float moveSpeed = 5f;
    public TextMeshProUGUI coinText;
    Rigidbody rb;
    public GameObject LevelCompletePanel;
    private bool changeDirection=false;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            changeDirection = true;
        }
        if (changeDirection)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            if (movementDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(movementDirection);
            }
            changeDirection = false;
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


        if (transform.position.y <= -7)
          {

              gameManager = GameManager.Instance;
              gameManager.GameOver();

          }
         else
          {
              Time.timeScale = 1f;
          }
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Coin")
        {
            coinCollect++;
            coinText.text=coinCollect.ToString();
            other.gameObject.SetActive(false);
        }
        if(coinCollect>=32 )
        {
            //Win
            

            winT.SetActive(true);
            
            StartCoroutine(ActiveLevelCompletedPanel());
            

        }    
        
   
    }
    private IEnumerator ActiveLevelCompletedPanel()
    {
       // Time.timeScale = 0f;
        yield return new WaitForSeconds(3f);
        winT.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}