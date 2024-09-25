using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public GameObject panelPause;
    public GameObject resume;
    public GameObject panelTutorial;

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

    public void PauseNow()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
        resume.SetActive(false);
    }

    public void ResumeNow()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        resume.SetActive(true);
    }

    public void QuitTutorial()
    {
        panelTutorial.SetActive(false);
        Time.timeScale = 1;
    }
}
