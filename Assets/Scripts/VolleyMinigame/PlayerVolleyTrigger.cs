using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVolleyTrigger : MonoBehaviour
{
    [SerializeField] float forceMagnitude = 20f;
    public GameObject ActionsPanel; 
    public GameObject Ball; 
    public Rigidbody2D BallRb; 
    public Collider2D triggerCollider; 

    private bool isInSlowMotion = false; 
    private bool choiceMade = false; 

    public Animator animator; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartSlowMotionAndPanel();
            triggerCollider.enabled = false; 
            StartCoroutine(ReactivateTrigger());
        }
    }

    private void StartSlowMotionAndPanel()
    {
        Time.timeScale = 0.01f; 
        ActionsPanel.SetActive(true); 
    }

    IEnumerator ReactivateTrigger()
    {
        yield return new WaitForSeconds(1.5f); 
        triggerCollider.enabled = true; 
    }

    public void MakeChoice()
    {
        choiceMade = true; 
        Time.timeScale = 1f; 
        ActionsPanel.SetActive(false); 
        choiceMade = false; 
    }

    public void StrongShot()
    {
        BallRb.AddForce(Vector2.right * forceMagnitude, ForceMode2D.Impulse);
        animator.SetTrigger("spiked");
        MakeChoice();
    }

    public void WeakShot()
    {
        float weakForceMagnitude = forceMagnitude * 0.5f;
        BallRb.AddForce(Vector2.right * weakForceMagnitude, ForceMode2D.Impulse);
        animator.SetTrigger("spiked");
        MakeChoice();
    }
}

