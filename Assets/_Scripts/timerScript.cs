using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timerScript : MonoBehaviour
{
    public float Timer = 0f;
    public TextMeshProUGUI timerText;
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        // Format timer into MM:SS:SS
        int minutes = Mathf.FloorToInt(Timer / 60F);
        int seconds = Mathf.FloorToInt(Timer - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
