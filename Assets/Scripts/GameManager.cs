using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameManager : MonoBehaviour
{
    private GameObject ball;
    [SerializeField] Rigidbody2D ballRb;
    private Scorer ballScorer;
    public TextMeshProUGUI instruction;
    public TextMeshProUGUI levelCompletedText;
    public TextMeshProUGUI tryAgainText;
    public Button restartButton;
    public Button nextLevelButton;
    [SerializeField] int targetNumber;
    [SerializeField] int blockTargetNumber;
    [SerializeField] int yellowBlockTargetNumber;
    public bool isTargetPassed = false;

    private void Awake()
    {
        ballScorer = GameObject.Find("Ball").GetComponent<Scorer>();
        ballRb = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        
    }
    private void Start()
    {
        ball = GameObject.Find("Ball");


        instruction.gameObject.SetActive(true);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        //level scene
        switch (currentScene)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                targetNumber = currentScene - 1;
                break;
            case 3:
                targetNumber = currentScene - 1;
                break;
            case 4:
                targetNumber = currentScene - 1;
                break;
            case 5:
                targetNumber = currentScene - 1;
                break;
            case 6:
                targetNumber = currentScene - 1;
                break;
            case 7:
                targetNumber = currentScene - 1;
                break;
            case 8:
                targetNumber = currentScene - 1;
                break;
            case 9:
                targetNumber = 0;
                blockTargetNumber = 1;
                break;
            case 10:
                targetNumber = 1;
                blockTargetNumber = 1;
                break;
            case 11:
                targetNumber = 2;
                blockTargetNumber = 1;
                break;
            case 12:
                targetNumber = 0;
                blockTargetNumber = 0;
                yellowBlockTargetNumber = 1;
                break;
            case 13:
                targetNumber = 0;
                blockTargetNumber = 1;
                yellowBlockTargetNumber = 1;
                break;
            case 14:
                targetNumber = 2;
                blockTargetNumber = 1;
                yellowBlockTargetNumber = 0;
                break;
            case 15:
                targetNumber = 1;
                blockTargetNumber = 1;
                yellowBlockTargetNumber = 0;
                break;
            case 16:
                targetNumber = 3;
                blockTargetNumber = 0;
                yellowBlockTargetNumber = 0;
                break;
            case 17:
                targetNumber = 2;
                blockTargetNumber = 1;
                yellowBlockTargetNumber = 1;
                break;
            case 18:
                targetNumber = 1;
                blockTargetNumber = 0;
                yellowBlockTargetNumber = 1;
                break;
            case 19:
                targetNumber = 1;
                blockTargetNumber = 0;
                yellowBlockTargetNumber = 0;
                break;
            case 20:
                targetNumber = 0;
                blockTargetNumber = 1;
                yellowBlockTargetNumber = 1;
                break;
            case 21:
                targetNumber = 1;
                blockTargetNumber = 1;
                yellowBlockTargetNumber = 1;
                break;
        }



    }
    private void Update()
    {   if (SceneManager.GetActiveScene().buildIndex < 12)
            GameController();
        else if (SceneManager.GetActiveScene().buildIndex >= 12)
            GameController2();
            
    }


    public void Restart()
    {  
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //if (SceneManager.GetActiveScene().buildIndex > 8) 
        tryAgainText.gameObject.SetActive(false);
    }
    public void GameController()
    {
        if (ballScorer.isGameFinished == true || ballScorer.isGameCompleted == false)
        {
            if (targetNumber == ballScorer.scoreGround && SceneManager.GetActiveScene().buildIndex <= 8)
            {
                YouWon();
            }
            else if (SceneManager.GetActiveScene().buildIndex < 8)
            {
                YouLost();
                
            }
            if (SceneManager.GetActiveScene().buildIndex > 8 && targetNumber == ballScorer.scoreGround && blockTargetNumber == ballScorer.scoreBlock && ballScorer.isGameCompleted == true)
            {
                YouWon();
            }
            else if (ballScorer.isGameCompleted == false )
            {
                YouLost();
            }
            else if (levelCompletedText.gameObject.activeSelf == false)
            {
                YouLost();
            }
            
        }
        if (targetNumber < ballScorer.scoreGround || blockTargetNumber < ballScorer.scoreBlock)
        {
            YouLost();
            isTargetPassed = true;
            //ball.gameObject.SetActive(false);
        }
    }
    
    public void YouLost()
    {
        Debug.Log("You Lost Try Again");
        tryAgainText.gameObject.SetActive(true);
    }
    public void YouWon()
    {
        Debug.Log("You Won Skip to Next Level");
        levelCompletedText.gameObject.SetActive(true);
        nextLevelButton.interactable = true;
    }

    public void GameController2()
    {
        if(ballScorer.isGameFinished == true || ballScorer.isGameCompleted == false)
        {
            if(targetNumber == ballScorer.scoreGround && blockTargetNumber == ballScorer.scoreBlock && yellowBlockTargetNumber == ballScorer.yellowBlockScore)
            {
                YouWon();
            }
            else 
            {
                YouLost();
            }
        }
       /* else if(targetNumber < ballScorer.scoreGround || blockTargetNumber < ballScorer.scoreBlock || yellowBlockTargetNumber < ballScorer.yellowBlockScore)
        {
            YouLost();
            isTargetPassed = true;
        }*/
       
    }
}
