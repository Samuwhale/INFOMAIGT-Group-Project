using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timerScript : MonoBehaviour
{
    float Timer = 0f;
    public TextMeshProUGUI timerText;
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        timerText.text = Timer.ToString();
    }
}
