using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject ball;
    private void Update()
    {
        scoreText.text =score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            score++;
        }
    }
}
