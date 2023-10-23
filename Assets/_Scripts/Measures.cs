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
    private float DamageTakenPerSecond; //check
    private float DamageDealt; //check
    private float DamageDealtPerSecond; //check
    public int WavesCleared; //check
    public int XPGained; //checks
    private int TotalXPGained = 0; //check
    public int IcestaffDam; //check
    public int ScytheDam; //check
    public int DaggerDam; //check
    public int ForcefieldDam; //check
    private float IcestaffDPS; //check
    private float ScytheDPS; //check
    private float DaggerDPS; //check
    private float ForcefieldDPS; //check
    //stats;                    //check
    private string Response1; //check
    private string Response2; //check

    public string participantID = "0";
    public string trialNr = "0";
    private string fileString;

    public Image surveyscreen1;
    public Image surveyscreen2;
    public timerScript timerScript;
    public GameObject player;

    float lastTime = 0f;
    float timeDiff;

    public void Start()
    {
        if (!System.IO.File.Exists(path + $"/data_participant{participantID}-tn{trialNr}.txt"))
        {
            fileString += "WavesCleared, EnemiesKilled, DamageTaken, DamageTakenPerSecond, DamageDealt, DamageDealtPerSecond, XPGained, TotalXPGained, " +
            "IcestaffLevel, IcestaffDam, IcestaffDPS, ScytheLevel, ScytheDam, ScytheDPS, DaggerLevel, DaggerDam, DaggerDPS, ForcefieldLevel, ForcefieldDam, ForcefiledDPS, " +
            "maxHealth, currentHealth, attackPower, attackSpeed, defensePower, movementSpeed, Response1, Response2 \n";
        }
    }

    public void WriteFile()
    {
        if (System.IO.File.Exists(path + $"/data_participant{participantID}-tn{trialNr}.txt"))
        {
            System.IO.File.AppendAllText(path + $"/data_participant{participantID}-tn{trialNr}.txt", fileString);
            Debug.Log("Appended file at " + path);
        }
        else
        {
            System.IO.File.WriteAllText(path + $"/data_participant{participantID}-tn{trialNr}.txt", fileString);
            Debug.Log("Created file at " + path);
        }
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
        AddMeasure(XPGained.ToString());
        AddMeasure(TotalXPGained.ToString());

        AddMeasure(player.GetComponent<IceStaff>().level.ToString());
        AddMeasure(IcestaffDam.ToString());
        AddMeasure(IcestaffDPS.ToString());
        AddMeasure(player.GetComponent<Scythe>().level.ToString());
        AddMeasure(ScytheDam.ToString());
        AddMeasure(ScytheDPS.ToString());
        AddMeasure(player.GetComponent<ThrowingDagger>().level.ToString());
        AddMeasure(DaggerDam.ToString());
        AddMeasure(DaggerDPS.ToString());
        AddMeasure(player.GetComponent<Forcefield>().level.ToString());
        AddMeasure(ForcefieldDam.ToString());
        AddMeasure(ForcefieldDPS.ToString());

        AddMeasure(player.GetComponent<Player>().GetMaxHealth().ToString());
        AddMeasure(player.GetComponent<Player>().GetCurrentHealth().ToString());
        AddMeasure(player.GetComponent<Player>().GetAttackPower().ToString());
        AddMeasure(player.GetComponent<Player>().GetAttackSpeed().ToString());
        AddMeasure(player.GetComponent<Player>().GetDefencePower().ToString());
        AddMeasure(player.GetComponent<Player>().GetMovementSpeed().ToString());

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
        lastTime = timerScript.Timer;
    }

    public void CalculateMeasures()
    {
        timeDiff = timerScript.Timer - lastTime;
        DamageTakenPerSecond = DamageTaken / timeDiff;
        DamageDealt = IcestaffDam + ScytheDam + DaggerDam + ForcefieldDam;
        DamageDealtPerSecond = DamageDealt / timeDiff;
        IcestaffDPS = IcestaffDam / timeDiff;
        ScytheDPS = ScytheDam / timeDiff;
        DaggerDPS = DaggerDam / timeDiff;
        ForcefieldDPS = ForcefieldDam / timeDiff;
        TotalXPGained += XPGained;
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
        // if (Input.GetKeyDown(KeyCode.Comma))
        // {
        //     StartSurvey1();
        // }
    }

    public void AddAnswer(int question,string answer)
    {
        fileString += $"Question {question} answer: {answer}\n";
    }

    public void Button0()
    {
        Response1 = "1";
        StartSurvey2();
    }

    public void Button1()
    {
        Response1 = "2";
        StartSurvey2();
    }

    public void Button1_5()
    {
        Response1 = "3";
        StartSurvey2();
    }

    public void Button2()
    {
        Response1 = "4";
        StartSurvey2();
    }

    public void Button2_5()
    {
        Response1 = "5";
        StartSurvey2();
    }

    public void Button3()
    {
        Response1 = "6";
        StartSurvey2();
    }
    public void Button3_5()
    {
        Response1 = "7";
        StartSurvey2();
    }
    public void Button3_6()
    {
        Response2 = "1";
        EndSurvey();
    }
    public void Button4()
    {
        Response2 = "2";
        EndSurvey();
    }
    public void Button4_5()
    {
        Response2 = "3";
        EndSurvey();
    }
    public void Button5()
    {
        Response2 = "4";
        EndSurvey();
    }
    public void Button5_5()
    {
        Response2 = "5";
        EndSurvey();
    }
    public void Button6()
    {
        Response2 = "6";
        EndSurvey();
    }
    public void Button7()
    {
        Response2 = "7";
        EndSurvey();
    }
}
