using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject ExpOrbDrop;
    public GameObject HeartDrop;
    public GameObject[] ItemDropList;
    public GameObject tracker;
    public GameObject Chicken;
    public GameObject Cow;
    public int NumEnemies = 0;
    private bool WavesEnded = false;

    [System.Serializable] public class Wave
    {
        public int waveID;
        public int initialTime;
        public int spawnBuffer;
        public int waveSize;
        public float spawnChance;
    }


    [SerializeField] public List<Wave> waveList;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("MeasureTracker");
        SetupWaves();
    }

    private void Update()
    {
        if (WavesEnded)
            if (NumEnemies <= 0)
            {
                // VICTORY!!!
                tracker.GetComponent<Measures>().StartSurvey1();
            }

    }

    void SetupWaves()
    {
        for (int i = 0; i < waveList.Count; i++)
        {
            StartCoroutine(StartWave(waveList[i]));
        }
    }

    private IEnumerator StartWave(Wave wave)
    {
        yield return new WaitForSeconds(wave.initialTime);

        // Do survey
        if (wave.waveID != 0)
        {
            tracker.GetComponent<Measures>().WavesCleared++;
            tracker.GetComponent<Measures>().StartSurvey1();
        }

        Debug.Log("Starting wave " + wave.waveID);

        float timer = 0;

        while (timer < 60)
        {
            while (NumEnemies < wave.waveSize) SpawnRandomEnemy(wave.spawnChance);
            timer += wave.spawnBuffer;
            yield return new WaitForSeconds(wave.spawnBuffer);
        }

        if (wave.waveID == 4) tracker.GetComponent<Measures>().StartSurvey1(); // Finish Game
    }

    private void SpawnRandomEnemy(float spawnChance)
    {
        // Choose a random enemy
        GameObject newEnemy;

        float enemyChance = Random.value;
        if (enemyChance < spawnChance) newEnemy = Cow;
        else newEnemy = Chicken;

        // Choose a random position
        float posChance = Random.value;
        float x, y;

        if (posChance < 0.25f) { x = Random.Range(-0.1f, 1.1f); y = -0.1f; }
        else if (posChance < 0.5f) { x = Random.Range(-0.1f, 1.1f); y = 1.1f; }
        else if (posChance < 0.75f) { x = -0.1f; y = Random.Range(-0.1f, 1.1f); }
        else { x = 1.1f; y = Random.Range(-0.1f, 1.1f); }

        Vector3 pos = new Vector3(x, y, 10);

        pos = Camera.main.ViewportToWorldPoint(pos);

        pos.x = Mathf.Clamp(pos.x, -38f, 36f);
        pos.y = Mathf.Clamp(pos.y, -21f, 19f);

        Debug.Log("Spawning Enemy at " + pos);

        Instantiate(newEnemy, pos, Quaternion.identity);

        NumEnemies += 1;

        return;
    }
}
