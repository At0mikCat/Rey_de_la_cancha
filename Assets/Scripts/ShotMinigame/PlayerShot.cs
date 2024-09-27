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

    public float laneChangeSpeed = 5f;
    private Vector3 targetPosition;

    private Animator animator;
    public GameObject buttonWin;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleLaneChange();
        transform.position = Vector3.Lerp(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);

        if (score == 10)
        {
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        panel.SetActive(true);
        buttonWin.SetActive(true);
    }

    void HandleLaneChange()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentLane < numberOfLanes - 1)
            {
                currentLane++;
                SetTargetLanePosition();
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentLane > 0)
            {
                currentLane--;
                SetTargetLanePosition();
            }
        }
    }

    void SetTargetLanePosition()
    {
        targetPosition = new Vector3(transform.position.x, (currentLane - 1) * laneDistance, transform.position.z);
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
                animator.SetTrigger("Shot");
            }
        }
    }
}

