using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGenerator : MonoBehaviour
{
    public GameObject[] ballPrefabs;   
    public float laneDistance = 2.0f; 
    public Transform spawnPoint;   
    public float ballSpeed = 5.0f;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    IEnumerator SpawnBallRoutine()
    {
        while (true)
        {
            SpawnBall();
            yield return new WaitForSeconds(1.8f);
        }
    }

    void SpawnBall()
    {
        int randomLane = Random.Range(0, 3);

        GameObject selectedBallPrefab = ballPrefabs[randomLane];

        float targetYPosition = (randomLane - 1) * laneDistance;

        GameObject ball = Instantiate(selectedBallPrefab, spawnPoint.position, Quaternion.identity);

        Vector2 targetPosition = new Vector2(spawnPoint.position.x - 10f, targetYPosition); 
        Vector2 direction = (targetPosition - (Vector2)spawnPoint.position).normalized;  

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = direction * ballSpeed;
    }
}
