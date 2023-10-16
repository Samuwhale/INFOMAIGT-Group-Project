using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Measures : MonoBehaviour
{
    private string path = Application.dataPath + "/data";

    public int EnemiesKilled; //check
    public float DamageTaken; //check
    public float DamageTakenPerSecond;
    public float DamageDealt;
    public float DamageDealtPerSecond;
    //public float Accuracy;
    //public float TimeSpentOnWave;
    public int WavesCleared;
    public int XPGained;
    public int TotalXPGained;
    public int IcestaffDam;
    public int ScytheDam;
    public int DaggerDam;
    public int ForcefieldDam;

    private string Response1; //check
    private string Response2; //check

    public string participantID = "0";
    public string trialNr = "0";
    public string fileString;

    public Image surveyscreen1;
    public Image surveyscreen2;

    public void Start()
    {
        fileString += "WavesCleared, EnemiesKilled, DamageTaken, DamageTakenPerSecond, DamageDealt, DamageDealtPerSecond, XPGained, TotalXPGained, " +
            "IcestaffLevel, IcestaffDam, IcestaffDPS, ScytheLevel, ScytheDam, ScytheDPS, DaggerLevel, DaggerDam, DaggerDPS, ForcefieldLevel, ForcefieldDam, ForcefiledDPS, " +
            "maxHealth, currentHealth, attackPower, attackSpeed, defensePower, movementSpeed, Response1, Response2";
    }

    public void WriteFile()
    {
        System.IO.File.WriteAllText(path + $"/data_participant{participantID}-tn{trialNr}.txt", fileString);
        Debug.Log("Created file at " + path);
    }

    public void AddMeasure(string number)
    {
        fileString += $", {number}";
    }

    public void AddMeasures()
    {
        CalculateMeasures();
        fileString += WavesCleared.ToString();
        AddMeasure(EnemiesKilled.ToString());
        AddMeasure(DamageTaken.ToString());
        AddMeasure(DamageTakenPerSecond.ToString());
        AddMeasure(DamageDealt.ToString());
        AddMeasure(DamageDealtPerSecond.ToString());

        AddMeasure(Response1);
        AddMeasure(Response2);
        fileString += "\n";
        EnemiesKilled = 0;
        DamageTaken = 0;
        IcestaffDam = 0;
        ScytheDam = 0;
        DaggerDam = 0;
        ForcefieldDam = 0;
        XPGained = 0;
    }

    public void CalculateMeasures()
    {

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
        Response1 = "Too Easy";
        StartSurvey2();
    }

    public void Button2()
    {
        Response1 = "Just Right";
        StartSurvey2();
    }

    public void Button3()
    {
        Response1 = "Too Hard";
        StartSurvey2();
    }

    public void Button4()
    {
        Response2 = "Frustrated";
        EndSurvey();
    }
    public void Button5()
    {
        Response2 = "Neutral/Flow";
        EndSurvey();
    }
    public void Button6()
    {
        Response2 = "Bored";
        EndSurvey();
    }
}
