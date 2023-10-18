using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Measures measure;
    public void Setup()
    {
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
    }

    public void MainMenuButton()
    {

        measure.WriteFile();
        SceneManager.LoadScene(0);
    }
}