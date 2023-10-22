using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    Animator anim;
    public int score;
    public float time;

    public Text score_text;
    public Text[] text_time;

    DirScript dirScript_script;
    TimeManager timeManager;
    GameObject[] redEnemy;
    EnemyCtrl enemyCtrl;

    void Start()
    {
        anim = GetComponent<Animator>();
        dirScript_script = FindObjectOfType<DirScript>();
        timeManager = FindObjectOfType<TimeManager>();
        time = 0;
        score = 0;
    }

    public void GameEnd()
    {
        score = dirScript_script.score;
        score_text.text = score.ToString();
        time = timeManager.timer;
        text_time[0].text = ((int)time / 60 % 60) + "m".ToString();
        text_time[1].text = ((int)time % 60) + "s".ToString();

        redEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0;i < redEnemy.Length;i++)
        {
            Destroy(redEnemy[i]);
        }
        enemyCtrl = FindObjectOfType<EnemyCtrl>();
        enemyCtrl.gameObject.SetActive(false);


        anim.SetBool("isEnd", true);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
