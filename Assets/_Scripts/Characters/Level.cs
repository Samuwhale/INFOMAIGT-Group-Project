using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpMenu;
    public bool levelUpMenuOpen;
    [SerializeField] public int currExp = 0;
    [SerializeField] public int levelUpExpNeeded = 1;
    int level;
    const int slots = 3;

    // UI elements
    [SerializeField] TextMeshProUGUI[] nameText = new TextMeshProUGUI[slots];
    [SerializeField] TextMeshProUGUI[] description = new TextMeshProUGUI[slots];
    [SerializeField] TextMeshProUGUI[] levelText = new TextMeshProUGUI[slots];
    [SerializeField] Image[] image = new Image[slots];


    private void Awake()
    {
        level = 0;
        levelUpMenuOpen = false;
    }

    public void GetExp(int amount)
    {
        currExp += amount;
        if (currExp > levelUpExpNeeded)
        {
            currExp -= levelUpExpNeeded;
            LevelUp();
        }
        // update UI exp slider
    }

    private void LevelUp()
    {
        levelUpMenuOpen = true;
        StartCoroutine(ChooseUpgrade());
        level++;
        levelUpExpNeeded = Mathf.RoundToInt(levelUpExpNeeded * 1.5f);
        // update UI level
    }

    IEnumerator ChooseUpgrade()
    {
        Time.timeScale = 0f;
        OpenLevelUpMenu();

        while (true)
        {
            if (!levelUpMenuOpen) break;
            yield return null;
        }

        _levelUpMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OpenLevelUpMenu()
    {
        _levelUpMenu.SetActive(true);

        for (int i = 0; i < slots; i++)
        {

        }
    }
}
