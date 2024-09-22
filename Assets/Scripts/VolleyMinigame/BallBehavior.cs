using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //[SerializeField] bool isRed = false;
    //[SerializeField] bool isBlue = false;

    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Red"))
        //{
        //    isRed = true;
        //    isBlue = false;
        //}
        //if(collision.gameObject.CompareTag("Blue"))
        //{
        //    isRed = false;
        //    isBlue = true;
        //}

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
