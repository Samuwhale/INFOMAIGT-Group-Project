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
    const int slots = 4;

    // UI elements
    [SerializeField] Button[] button = new Button[slots];
    [SerializeField] TextMeshProUGUI[] nameText = new TextMeshProUGUI[slots];
    [SerializeField] TextMeshProUGUI[] description = new TextMeshProUGUI[slots];
    [SerializeField] TextMeshProUGUI[] levelText = new TextMeshProUGUI[slots];
    [SerializeField] Image[] image = new Image[slots];

    private Player _player;
    private int WEAPONCOUNT = 3;
    private int ITEMCOUNT = 0;
    private int WEAPONMAXLEVEL = 7;
    private int ITEMMAXLEVEL = 5;

    private void Awake()
    {
        level = 0;
        levelUpMenuOpen = false;
        _player = GetComponent<Player>();
        GetExp(1);
    }

    public void GetExp(int amount)
    {
        currExp += amount;
        if (currExp >= levelUpExpNeeded)
        {
            currExp -= levelUpExpNeeded;
            LevelUp();
        }
        // update UI exp slider
    }

    private void LevelUp()
    {
        StartCoroutine(ChooseUpgrade());
        level++;
        levelUpExpNeeded = Mathf.RoundToInt(levelUpExpNeeded * 1.5f);
        // update UI level
    }

    IEnumerator ChooseUpgrade()
    {
        Time.timeScale = 0f;
        levelUpMenuOpen = true;
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
            if (Random.Range(0, 10) <= 4) // 6/10 chance for a weapon, 4/10 for a item
            {
                int weaponID = 0;
                int weaponLevel = 0;
                while (true)
                {
                    weaponID = Random.Range(0, WEAPONCOUNT);
                    weaponLevel = _player.GetWeaponLevel(weaponID);
                    if (weaponLevel != WEAPONMAXLEVEL)
                        break;
                }

                WeaponData data = _player.GetWeaponData(weaponID);
                image[i].sprite = data.icon;
                nameText[i].text = data.weaponName;
                levelText[i].text = "Level " + weaponLevel;
                description[i].text = data.description[weaponLevel];

                button[i].onClick.AddListener(delegate {
                    _player.LevelUpWeapon(weaponID);
                    levelUpMenuOpen = false;
                    });
                continue;
            }
            int itemID = 0;
            while (true)
            {
                itemID = Random.Range(0, ITEMCOUNT);
                if (_player.GetItemLevel(itemID) != ITEMMAXLEVEL)
                    break;
            }
            
            button[i].onClick.AddListener(delegate {
                    _player.LevelUpItem(itemID);
                    levelUpMenuOpen = false;
                    });
        }
    }
}
