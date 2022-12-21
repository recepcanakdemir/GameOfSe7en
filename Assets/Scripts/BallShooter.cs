using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallShooter : MonoBehaviour
{
    [SerializeField] float power = 10.0f;
    [SerializeField] bool isPlayable = true;
    [SerializeField] float pointOfZ = 15.0f;
    [SerializeField] TextMeshProUGUI instructionText;
    public Rigidbody2D ballRb;
    TrajectoryLine tl;
    

    public Vector2 maxPower;
    public Vector2 minPower;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
     //   instructionText = GameObject.Find("Instruction").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isPlayable==true)
            BallShoot();
    }

    void BallShoot()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = pointOfZ;

           // Debug.Log(startPoint);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = pointOfZ;

            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            instructionText.gameObject.SetActive(false);
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = pointOfZ;
            Debug.Log(endPoint);

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            ballRb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
            isPlayable = false;
            
            
        }
        
    }

}
