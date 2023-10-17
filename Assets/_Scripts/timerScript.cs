using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timerScript : MonoBehaviour
{
    float timer = 0f;
    public TextMeshProUGUI timerText;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Format timer into MM:SS:SS
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
