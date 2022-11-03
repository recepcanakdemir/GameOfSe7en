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
    private Scorer ballScorer;
    public TextMeshProUGUI instruction;
    public TextMeshProUGUI levelCompletedText;
    public Button restartButton;
    public Button nextLevelButton;
    [SerializeField] int targetNumber;

    private void Awake()
    {
        ballScorer = GameObject.Find("Ball").GetComponent<Scorer>();
        
    }
    private void Start()
    {
        ball = GameObject.Find("Ball");


        instruction.gameObject.SetActive(true);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 2)
            targetNumber = currentScene-1;
        if (currentScene == 3)
            targetNumber = currentScene - 1;
        if (currentScene == 4)
            targetNumber = currentScene - 1;
        if (currentScene == 5)
            targetNumber = currentScene - 1;
        if (currentScene == 6)
            targetNumber = currentScene - 1;
        if (currentScene == 7)
            targetNumber = currentScene - 1;
        if (currentScene == 8)
            targetNumber = currentScene - 1;

    }
    private void Update()
    {
        GameController();
            
    }


    public void Restart()
    {  
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void GameController()
    {
        if (ballScorer.isGameFinished == true)
        {
            if (targetNumber == ballScorer.score)
            {
                Debug.Log("You won");
                nextLevelButton.interactable = true;
                levelCompletedText.gameObject.SetActive(true);
                
            }
        }
    }
    
}
