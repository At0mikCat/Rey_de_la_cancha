using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameSceneController : MonoBehaviour
{
    public GameController GameController;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.currentScene.name == "Salto")
        {
            SceneManager.LoadScene("CircuitTraining");
        }

        if (GameController.currentScene.name == "11.b cambio de escena")
        {
            SceneManager.LoadScene("11.b cambio de escena");
        }

        if (GameController.currentScene.name == "13.b cambio de escena remate")
        {
            SceneManager.LoadScene("13.b cambio de escena remate");
        }

        if (GameController.currentScene.name == "13.d - transicion minijuego")
        {
            SceneManager.LoadScene("13.d - transicion minijuego");
        }

        if (GameController.currentScene.name == "16.a - Transición a minijuego")
        {
            SceneManager.LoadScene("16.a - Transicion a minijuego");
        }
        if (GameController.currentScene.name == "19.a - Transición minijuego partido final")
        {
            SceneManager.LoadScene("19.a - Transición minijuego partido final");
        }
    }
}
