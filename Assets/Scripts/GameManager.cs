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
    public TextMeshProUGUI instruction;
    public Button restartButton;

    private void Start()
    {
        ball = GameObject.Find("Ball");
        instruction.gameObject.SetActive(true);
    }


    public void Restart()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
  
}
