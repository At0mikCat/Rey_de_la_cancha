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

    bool canJump = true;
    bool isGameStarted = false;

    public GameObject Panel;
    public TextMeshProUGUI Text;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    { 
        yield return new WaitForSeconds(2.0f);
        isGameStarted = true;
    }

    void Update()
    {
        if(isGameStarted)
        {
            MoveAlongPath();
            HandleJump();
        }    }

    void MoveAlongPath()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
            }
            
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            boxCollider.enabled = false;
            canJump = false;
            spriteRenderer.color = Color.blue;
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.65f);
        boxCollider.enabled = true;
        canJump = true;
        spriteRenderer.color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
            Text.text = "¡Perdiste!";
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
