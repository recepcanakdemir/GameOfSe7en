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
    public Button restartButton;
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
            targetNumber = 1;

       
    }
    private void Update()
    {
        if (ballScorer.isGameFinished == true)
        {
            if (targetNumber == ballScorer.score)
            {
                Debug.Log("You won");
            }
        }
            
    }


    public void Restart()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
}
