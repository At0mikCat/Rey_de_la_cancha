using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public GameObject Ball;
    public float moveSpeed = 5f;
    public float passForce = 10f;  
    public float attackForce = 15f;  

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected void MoveTowardsBall()
    {
        if (Ball != null)
        {
            Vector2 direction = (Ball.transform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }
    protected bool HasDetectedBall()
    {
        return Ball != null && Vector2.Distance(transform.position, Ball.transform.position) < 10f;
    }
}
