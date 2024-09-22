using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int RedScore = 0;
    public static int BlueScore = 0;

    public TextMeshProUGUI RedScoreText;
    public TextMeshProUGUI BlueScoreText;

    public GameObject panelWINORLOSE;
    public TextMeshProUGUI winOrLoseText;
    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        RedScoreText.text = RedScore.ToString();
        BlueScoreText.text = BlueScore.ToString();

        if (RedScore >= 10)
        {
            Time.timeScale = 0;
            panelWINORLOSE.SetActive(true);
            winOrLoseText.text = "¡Rojo gana!";
        }

        if(BlueScore >= 10)
        {
            Time.timeScale = 0;
            panelWINORLOSE.SetActive(true);
            winOrLoseText.text = "¡Azul gana!";
        }
    }

    public void RedScored()
    {
        RedScore++;
        ReloadScene();
    }

    public void BlueScored()
    {
        BlueScore++;
        ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
