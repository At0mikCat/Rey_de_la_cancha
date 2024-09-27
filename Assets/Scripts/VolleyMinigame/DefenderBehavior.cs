using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBehavior : PlayerBase
{
    public GameObject setter;

    public Animator animator;

    private void Update()
    {
        if(HasDetectedBall())
        {
            MoveTowardsBall();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetTrigger("pass");
            PassToSetter();
        }
    }

    private void PassToSetter()
    {
        Rigidbody2D ballRb = Ball.GetComponent<Rigidbody2D>();
        Vector2 passDirection = (setter.transform.position - transform.position).normalized;
        ballRb.AddForce(passDirection * passForce, ForceMode2D.Impulse);
    }
}
