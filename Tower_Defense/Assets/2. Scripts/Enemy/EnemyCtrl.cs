using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCtrl : MonoBehaviour
{
    DirScript dirScript_script;
    TimeManager timeManager_script;

    public GameObject spawnPoint;
    public GameObject enemy;
    int game_level = 1;

    public float[] spawnCoolTimes;

    [Range(0, 20)]
    public float spawnCoolTime;

    bool isSpawn = false;

    void Start()
    {
        dirScript_script = FindObjectOfType<DirScript>();
        timeManager_script = FindObjectOfType<TimeManager>();
        enemy.SetActive(true);

        spawnCoolTimes = new float[10];
        for(int i = 0; i < 10; i++)
        {
            spawnCoolTimes[i] = 5.0f - (0.5f * i);
        }
        spawnCoolTime = spawnCoolTimes[game_level - 1];
    }

    // Update is called once per frame
    void Update()
    {
        game_level = timeManager_script.game_level;

        spawnCoolTime -= Time.deltaTime;
        if (spawnCoolTime < 0.0f)
        {
            spawnCoolTime = spawnCoolTimes[game_level - 1];
            Spawn();
        }
    }

    public void Spawn()
    {
        Instantiate(enemy,spawnPoint.transform.position, Quaternion.identity);
    }

    public void GetHurt(int level)
    {
        dirScript_script.EnemyGoal(level);
    }
}
