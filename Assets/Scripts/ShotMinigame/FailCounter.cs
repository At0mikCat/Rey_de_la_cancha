using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FailCounter : MonoBehaviour
{
    public int failCounter = 0;

    public GameObject panel;
    public TextMeshProUGUI failText;
    public GameObject buttonFail;

    private void Update()
    {
        if (failCounter >= 3)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            failText.text = "¡Perdiste!";
            buttonFail.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            failCounter++;
            Destroy(collision.gameObject);
        }
    }
}
