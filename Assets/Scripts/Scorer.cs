using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    public int scoreGround = 0;
    public int scoreBlock = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI blockScoreText;
    public GameObject ball;
    public bool isGameFinished = false;
    public bool isGameCompleted = true;



    private void Update()
    {
        scoreText.text = scoreGround.ToString();
        if(SceneManager.GetActiveScene().buildIndex > 8)
        blockScoreText.text = scoreBlock.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            scoreGround++;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary1" || collision.gameObject.tag== "Boundary2" )
        {
            isGameFinished = true;
            isGameCompleted = true;

        }
        if(collision.gameObject.tag == "Boundary3" || collision.gameObject.tag == "Boundary4")
        {
            isGameCompleted = false;
        }
        if (collision.gameObject.tag == "movingBlock" && SceneManager.GetActiveScene().buildIndex > 8)
        {
            scoreBlock++;
        }
    }


}
