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
    }
}
