using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterBehavior : PlayerBase
{
    public GameObject spiker1;
    public GameObject spiker2;

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetTrigger("pass");
            PassToSpiker();
        }
    }
    private void PassToSpiker()
    {
        GameObject chosenSpiker = DecideSpiker(); 
        Rigidbody2D ballRb = Ball.GetComponent<Rigidbody2D>();
        Vector2 passDirection = (chosenSpiker.transform.position - transform.position).normalized;
        ballRb.AddForce(passDirection * passForce, ForceMode2D.Impulse);
    }

    private GameObject DecideSpiker()
    {
        float distanceToSpiker1 = Vector2.Distance(transform.position, spiker1.transform.position);
        float distanceToSpiker2 = Vector2.Distance(transform.position, spiker2.transform.position);

        if (distanceToSpiker1 < distanceToSpiker2)
            return spiker1;
        else
            return spiker2;
    }
}
