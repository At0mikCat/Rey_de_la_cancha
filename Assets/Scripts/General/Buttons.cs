using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public GameObject panelPause;
    public GameObject resume;
    public GameObject panelTutorial;
    public GameObject gameManager;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToVisualNovel()
    {
        SceneManager.LoadScene("1- Inicio Juego");
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

    public void ganarsalto()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("2.a Ganas Salto");
    }

    public void pierdesalto()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("2.b Pierdes Salto");
    }

    public void ganasvolleyprimerpartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("9.5.a - Continuacion Ganar");
    }
    public void OnceBGanaspartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("11.b - continuacion");
    }
    public void OnceBPierdespartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("11.b - continuacion");
    }

    public void pierdesvolleyprimerpartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("9.5.a - Continuacion perder");
    }

    public void ganasvolleysegundopartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("13.d - Ganar");
    }

    public void pierdesvolleysegundopartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("13.d - Perder");
    }

    public void ganasvolleytercerpartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("16.a continuacion");
    }

    public void pierdesvolleytercerpartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("16.a continuacion");
    }

    public void ganasvolleycuartopartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("19.a - continuacion");
    }

    public void pierdesvolleycuartopartido()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("19.a - continuacion");
    }
    public void Partido95Aganar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("9.5.a - Continuacion Ganar");
    }
    public void Partido95Aperder()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("9.5.a - Continuacion perder");
    }
    public void remate13Bganar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("13.b - continuacion");
    }
    

    public void remate13Bperder()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("13.b - continuacion");
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

    public void activateGameManager()
    {
        panelTutorial.SetActive(false);
        Time.timeScale = 1;
        gameManager.SetActive(true);
    }
}
