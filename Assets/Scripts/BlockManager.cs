using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockManager : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;

    [SerializeField] private Scorer ballScorer;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private Vector3 firstStartingPos = new Vector3(-7.0f, 0f, 0f);

    [SerializeField] private Transform currentPoint;
    [SerializeField] private GameObject block;
    private void Start()
    {
        //startPos = block.transform.position;
        ballScorer = GameObject.Find("Ball").GetComponent<Scorer>();
        startPos = firstStartingPos;
    }
    private void Update()
    {
        if (ballScorer.isGameFinished == false) 
        MoveRightToLeft();
        if (ballScorer.isGameCompleted == false)
            speed = 0f;
    }
    void MoveRightToLeft()
    {
        block.transform.position = Vector3.MoveTowards(block.transform.position, startPos, Time.deltaTime * speed);
        if (block.transform.position == startPos)
        {
            startPos = endPosition;
            if (startPos == endPosition)
            {
                endPosition = block.transform.position;
            }
        }
    }
}

