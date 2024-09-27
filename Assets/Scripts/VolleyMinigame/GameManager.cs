using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public static int RedScore = 0;
    public static int BlueScore = 0;

    public TextMeshProUGUI RedScoreText;
    public TextMeshProUGUI BlueScoreText;

    public GameObject panelWINORLOSE;
    public TextMeshProUGUI winOrLoseText;

    public GameObject ball;
    public Transform redServePosition;
    public Transform blueServePosition;

    public float freezeDuration = 1f;
    public float serveForce = 15f;
    public string serveLayer = "ServeLayer";   
    private string defaultLayer = "Default";

    public GameObject buttonWin;
    public GameObject buttonLose;

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(ResetBall(redServePosition, new Vector2(1, 0)));
    }

    private void Update()
    {
        RedScoreText.text = RedScore.ToString();
        BlueScoreText.text = BlueScore.ToString();

        if (RedScore >= 7)
        {
            Time.timeScale = 0;
            panelWINORLOSE.SetActive(true);
            winOrLoseText.text = "¡Ganaste, lo lograste!";
            buttonWin.SetActive(true);
        }

        if (BlueScore >= 7)
        {
            Time.timeScale = 0;
            panelWINORLOSE.SetActive(true);
            winOrLoseText.text = "¡Una lástima!";
            buttonLose.SetActive(true);
        }
    }

    public void RedScored()
    {
        RedScore++;
        StartCoroutine(ResetBall(blueServePosition, new Vector2(-1, 0)));  
    }

    public void BlueScored()
    {
        BlueScore++;
        StartCoroutine(ResetBall(redServePosition, new Vector2(1, 0)));  
    }

    private IEnumerator ResetBall(Transform servePosition, Vector2 serveDirection)
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = servePosition.position;

        ball.layer = LayerMask.NameToLayer(serveLayer);

        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + freezeDuration;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null;
        }

        Time.timeScale = 1f;

        ball.GetComponent<Rigidbody2D>().AddForce(serveDirection * serveForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);

        ball.layer = LayerMask.NameToLayer(defaultLayer);
    }
}
