using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{ public GameObject ball;
    [SerializeField] float xBoundary = 13.0f;
    [SerializeField] float yBoundary = -5.0f;
    private void Update()
    {
        if (ball.transform.position.x > xBoundary || ball.transform.position.y < yBoundary)
        {
            ball.SetActive(false);
        }
    }
}
