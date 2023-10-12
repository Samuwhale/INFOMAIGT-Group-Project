using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Measures : MonoBehaviour
{
    public int EnemiesKilled;
    public float DamageTaken;
    public float DamageTakenPerSecond;
    public float DamageDealt;
    public float DamageDealtPerSecond;
    public float Accuracy;
    public float TimeSpentOnWave;
    public int WavesCleared;

    public TextMeshProUGUI QuestionText;

    public void Update()
    {
        QuestionText.text = "test";
    }


}
