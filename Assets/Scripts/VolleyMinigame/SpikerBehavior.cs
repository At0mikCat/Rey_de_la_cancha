using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikerBehavior : PlayerBase
{
    public Transform opponentField;
    public Animator animator;

    private void Update()
    {
        if (HasDetectedBall())
        {
            MoveTowardsBall();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetTrigger("attack");
            Attack();
        }
    }

    private void Attack()
    {
        Rigidbody2D ballRb = Ball.GetComponent<Rigidbody2D>();
        Vector2 attackDirection = (opponentField.position - transform.position).normalized;
        ballRb.AddForce(attackDirection * attackForce, ForceMode2D.Impulse);
    }
}
