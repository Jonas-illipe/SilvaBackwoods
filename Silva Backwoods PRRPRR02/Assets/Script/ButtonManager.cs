using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Byter till spel scenen
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }

    //St�nger av spelet
    public void QuitButton()
    {
        Application.Quit();
    }
}
