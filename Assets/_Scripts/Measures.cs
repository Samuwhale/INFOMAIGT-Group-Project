using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Measures : MonoBehaviour
{
    private string path = Application.dataPath + "/data";

    public int EnemiesKilled;
    public float DamageTaken;
    public float DamageTakenPerSecond;
    public float DamageDealt;
    public float DamageDealtPerSecond;
    public float Accuracy;
    public float TimeSpentOnWave;
    public int WavesCleared;

    public string participantID;
    public string trialNr;
    public string fileString;

    public Image surveyscreen1;
    public Image surveyscreen2;

    public void WriteFile()
    {
        System.IO.File.WriteAllText(path + $"/data_participant{participantID}-tn{trialNr}.txt", fileString);
        Debug.Log("Created file at " + path);
    }

    public void AddMeasure(string variablename,string number)
    {
        fileString += $"{variablename}: {number}\n";
    }

    public void AddMeasures()
    {
        AddMeasure(nameof(EnemiesKilled), EnemiesKilled.ToString());
        AddMeasure(nameof(DamageTaken), DamageTaken.ToString());
        AddMeasure(nameof(DamageTakenPerSecond), DamageTakenPerSecond.ToString());
        AddMeasure(nameof(DamageDealt), DamageDealt.ToString());
        AddMeasure(nameof(DamageDealtPerSecond), DamageDealtPerSecond.ToString());
        AddMeasure(nameof(Accuracy), Accuracy.ToString());
        AddMeasure(nameof(TimeSpentOnWave), TimeSpentOnWave.ToString());
        AddMeasure(nameof(WavesCleared), WavesCleared.ToString());
        fileString += "\n";
    }

    public void StartSurvey1()
    {
        surveyscreen1.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartSurvey2()
    {
        surveyscreen2.gameObject.SetActive(true);
        surveyscreen1.gameObject.SetActive(false);
    }

    public void EndSurvey()
    {
        surveyscreen2.gameObject.SetActive(false);
        AddMeasures();
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            StartSurvey1();
        }
    }

    public void AddAnswer(int question,string answer)
    {
        fileString += $"Question {question} answer: {answer}\n";
    }

    public void Button1()
    {
        AddAnswer(1, "Too Easy");
        StartSurvey2();
    }

    public void Button2()
    {
        AddAnswer(1, "Just Right");
        StartSurvey2();
    }

    public void Button3()
    {
        AddAnswer(1, "Too Hard");
        StartSurvey2();
    }

    public void Button4()
    {
        AddAnswer(2, "Frustrated");
        EndSurvey();
    }
    public void Button5()
    {
        AddAnswer(2, "Neutral/Flow");
        EndSurvey();
    }
    public void Button6()
    {
        AddAnswer(2, "Bored");
        EndSurvey();
    }
}
