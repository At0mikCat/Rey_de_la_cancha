using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCircuit : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;  

    bool canJump = true;

    public GameObject buttonWin;
    public GameObject buttonLose;

    public GameObject Panel;
    public TextMeshProUGUI Text;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            MoveAlongPath();
            HandleJump();
    }

    void MoveAlongPath()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;

                transform.Rotate(0f, 0f, -90f);
            }
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            boxCollider.enabled = false;
            canJump = false;
            animator.SetTrigger("Jump");
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.65f);
        boxCollider.enabled = true;
        canJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
            Text.text = "¡Fallaste, el entrenador te va a regañar!";
            buttonLose.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
            Text.text = "¡Muy bien, lo lograse!";
            buttonWin.SetActive(true);
        }
    }
}
