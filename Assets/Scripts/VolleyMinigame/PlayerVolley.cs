using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVolley : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float forceMagnitude = 20f;
    [SerializeField] private float moveSpeed = 5f;

    //public GameObject ActionsPanel;
    //public GameObject Ball;
    //private Collider2D playerCollider;
    //private bool isInSlowMotion = false;
    //private bool hasTouchedBall = false;
    //private bool choiceMade = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

        //if (isInSlowMotion)
        //{
        //    isInSlowMotion = true;
        //    Time.timeScale = 0.01f;
        //    ActionsPanel.SetActive(true);
        //    StartCoroutine(WaitForDecision());
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ball") && !hasTouchedBall)
        //{
        //    hasTouchedBall = true;
        //}

        if(collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceMagnitude, ForceMode2D.Impulse);
        }
    }

    //IEnumerator WaitForDecision()
    //{
    //    float decisionTime = 3.0f;
    //    yield return new WaitForSecondsRealtime(decisionTime);

    //    if (!choiceMade)
    //    {
    //        Time.timeScale = 1f;
    //        ActionsPanel.SetActive(false);
    //        AllowBallToPass();
    //    }
    //}

    //private void AllowBallToPass()
    //{
    //    Physics2D.IgnoreCollision(Ball.GetComponent<Collider2D>(), playerCollider, true);
    //}

    //public void MakeChoice()
    //{
    //    choiceMade = true;
    //    Time.timeScale = 1f;
    //    ActionsPanel.SetActive(false);
    //}

    //public void Goal()
    //{
    //    Debug.Log("Gol seleccionado");
    //    if (Ball != null)
    //    {
    //        Ball.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceMagnitude, ForceMode2D.Impulse);
    //    }
    //}

    //public void PassToTeammate()
    //{

    //}
}
