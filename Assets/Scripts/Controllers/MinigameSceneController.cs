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
            // MINIJUEGO DE PARTIDO
        }

        if (GameController.currentScene.name == "13.b cambio de escena remate")
        {
            // MINIJUEGO DE REMATE
        }

        if (GameController.currentScene.name == "16.a - Transición a minijuego")
        {
            //MINIJUEGO DE PARTIDO
        }
        if (GameController.currentScene.name == "19.a - Transición minijuego partido final")
        {
            
            //MINIJUEGO DE PARTIDO
        }
    }
}
