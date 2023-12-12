//using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DirScript : MonoBehaviour
{
    public int gold = 100, score = 0;
    public Text gold_text, score_text;
    Result result_script;

    public int player_hp = 250;
    float timer;

    GameObject clickedObject;
    GameObject prevObject;
    string nextTag = "";
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        gold = 5000;
        score  = 0;
        result_script = FindObjectOfType<Result>();
        player_hp = 10050;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        gold_text.text = gold+"G".ToString();
        score_text.text = score.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (!hit) return;
            clickedObject = hit.collider.gameObject;

            if(nextTag == "")
            {
                if (clickedObject.tag == "Tower")
                {
                    // isClick();
                    prevObject = clickedObject;
                    nextTag = "TowerButton";
                }
                else if (hit.collider.gameObject.tag == "Button")
                {

                }
            }
            else
            {
                if (clickedObject.tag != nextTag)
                {
                    TowerScript towerScript = clickedObject.transform.parent.GetComponent<TowerScript>();
                    towerScript.IsClick();
                }
            }
        }
    }

    public void clickTowerButton()
    {

    }

    public void EnemyGoal(int level) // level: 0~3
    {
        int power = (level + 1) * 10;
        player_hp -= power;
        print("hp: " + player_hp);
        if (player_hp < 0) // 0까진 플레이 할 수 있음
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        result_script.GameEnd();
    }

    public void GameWin()
    {
        result_script.GameEnd();
    }
}
