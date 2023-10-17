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
    private int WEAPONMAXLEVEL = 7;
    private int ITEMMAXLEVEL = 5;
    private List<int> possible_ids;

    public Measures measures;

    private void Awake()
    {
        level = 0;
        levelUpMenuOpen = false;
        _player = GetComponent<Player>();
        possible_ids = new List<int> { 0, 1, 2, 3, 100, 101, 102 }; // 0-100 for weapons, 100+ for items
        //GetExp(1); // for testing
    }

    public void GetExp(int amount)
    {
        currExp += amount;
        if (currExp >= levelUpExpNeeded)
        {
            currExp -= levelUpExpNeeded;
            LevelUp();
        }
        measures.XPGained += amount;
        // update UI exp slider
    }

    private void LevelUp()
    {
        StartCoroutine(ChooseUpgrade());
        level++;
        levelUpExpNeeded = Mathf.RoundToInt(levelUpExpNeeded * 1.2f);
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
        List<int> possible_ids_copy = new List<int>(possible_ids);
        int slotsOpen = 3; // optional upgrade for 4 slots
        // TODO: add cases for if less than 3 options are available

        for (int i = 0; i < slotsOpen; i++)
        {
            int id = possible_ids_copy[Random.Range(0, possible_ids_copy.Count)];
            if (id < 100) // weapon ids < 100
            {
                int weaponID = id;
                int weaponLevel = _player.GetWeaponLevel(weaponID);
                if (weaponLevel + 1 == WEAPONMAXLEVEL)
                    possible_ids.Remove(id);
                possible_ids_copy.Remove(id);

                WeaponData weaponData = _player.GetWeaponData(weaponID);
                image[i].sprite = weaponData.icon;
                nameText[i].text = weaponData.weaponName;
                levelText[i].text = "Level " + weaponLevel;
                if (weaponLevel == 0) levelText[i].text = "New";
                description[i].text = weaponData.description[weaponLevel];

                button[i].onClick.RemoveAllListeners();
                button[i].onClick.AddListener(delegate {
                    _player.LevelUpWeapon(weaponID);
                    levelUpMenuOpen = false;
                    });
                continue;
            }
            // else branch (id > 100)
            int itemID = id - 100;
            int itemLevel = 0;
            if (itemLevel + 1 == ITEMMAXLEVEL)
                possible_ids.Remove(id);
            possible_ids_copy.Remove(id);

            ItemData itemData = _player.GetItemData(itemID);
            image[i].sprite = itemData.icon;
            nameText[i].text = itemData.itemName;
            levelText[i].text = "Level " + itemLevel;
            if (itemLevel == 0) levelText[i].text = "New";
            description[i].text = itemData.description[itemLevel];

            button[i].onClick.RemoveAllListeners();
            button[i].onClick.AddListener(delegate {
                    _player.LevelUpItem(itemID);
                    levelUpMenuOpen = false;
                    });
        }
    }
}
