using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("POINTFORRED"))
        {
            gameManager.RedScored();
        }

        if (collision.gameObject.CompareTag("POINTFORBLUE"))
        {
            gameManager.BlueScored();
        }

        if(collision.gameObject.CompareTag("OUTFORBLUE"))
        {
            gameManager.RedScored();
        }
        if (collision.gameObject.CompareTag("OUTFORRED"))
        {
            gameManager.BlueScored();
        }
    }
}
