using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownForMinigames : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }
}
