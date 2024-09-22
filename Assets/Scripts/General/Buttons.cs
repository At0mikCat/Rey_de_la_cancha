using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToVisualNovel()
    {
        SceneManager.LoadScene("Visual Novel");
    }

    public void GoToVolleyMinigame()
    {
        SceneManager.LoadScene("VolleyMinigame");
    }

    public void GoToShotMinigame()
    {
        SceneManager.LoadScene("ShotTrainingMinigameTEST");
    }

    public void GoToCircuitMinigame()
    {
        SceneManager.LoadScene("CircuitTraining");
    }
}
