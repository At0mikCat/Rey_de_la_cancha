using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float laneDistance = 2.0f;  
    public float forwardSpeed = 5f;   
    private int currentLane = 1;        
    private int numberOfLanes = 3;
    public float forceBall = 5;

    [SerializeField] int score = 0;

    public GameObject panel;
    void Update()
    {
        HandleLaneChange();
        if(score == 10)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    void HandleLaneChange()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentLane < numberOfLanes - 1)
            {
                currentLane++;
                MoveToLane();
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentLane > 0)
            {
                currentLane--;
                MoveToLane();
            }
        }
    }

    void MoveToLane()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y = (currentLane - 1) * laneDistance; 

        transform.position = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (ballRb != null)
            {
                ballRb.velocity = Vector2.right * forceBall;
                score++;
            }
        }
    }
}

