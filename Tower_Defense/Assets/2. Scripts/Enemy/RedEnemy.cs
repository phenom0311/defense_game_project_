using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public Sprite[] levels;
    public int level = 4;
    public int hp;

    SpriteRenderer sr;

    EnemyCtrl enemyCtrl_script;
    DirScript dirScript_script;


    public GameObject firstMove, turnLeft, turnRight;
    public GameObject[] goals;
    Vector3 move, goal;

    public float[] speeds;
    float speed;
    int rand_turn; // 0=left, 1=center, 2=right
    int isFirstMove = 0, isTurnLeft = 0, isTurnRight = 0, isNoTurn = 0;
    bool isUpdate = false;

    void Start()
    {
        enemyCtrl_script = FindObjectOfType<EnemyCtrl>();
        dirScript_script = FindObjectOfType<DirScript>();

        speeds = new float[7];
        speeds[0] = 1.0f;
        speeds[1] = 1.1f;
        speeds[2] = 1.3f;
        speeds[3] = 1.5f;
        speeds[4] = 1.7f;
        speeds[5] = 1.9f;
        speeds[6] = 2.0f;

        sr = GetComponentInChildren<SpriteRenderer>();
        level = Random.Range(0, 7);
        sr.sprite = levels[level];
        speed = speeds[level]; 

        rand_turn = Random.Range(0, 3);
        if (rand_turn == 0) isTurnLeft++;
        else if (rand_turn == 2) isTurnRight++;
        else if (rand_turn == 1) isNoTurn++;

        hp = (level + 1) * 12;
        print("rand turn: " + rand_turn);

        move = firstMove.transform.position;
    }

    private void Update()
    {   
        if(transform.position == firstMove.transform.position || isUpdate)
        {
            MoveUpdate();
            isUpdate = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, move, speed*Time.deltaTime);
        if(transform.position == goals[rand_turn].transform.position)
        {
            ArriveGoal();
        }

        if (hp <= 0)
        {
            dirScript_script.gold += 10;
            dirScript_script.score += (level + 1) * 10;
            Destroy(gameObject);
            print("Die");

        }
    }

    private void MoveUpdate()
    {
        if (isTurnLeft == 1)
        {
            move = turnLeft.transform.position;
            isTurnLeft++;
        }
        else if (isTurnRight == 1)
        {
            move = turnRight.transform.position;
            isTurnRight++;
        }
        else if (isNoTurn == 1)
        {
            move = goals[1].transform.position;
            isNoTurn++;
        }
        else if (transform.position == turnLeft.transform.position)
        {
            move = goals[0].transform.position;
        }
        else if (transform.position == turnRight.transform.position)
        {
            move = goals[2].transform.position;
        }
    }

    public void ArriveGoal()
    {
        Destroy(gameObject);
        enemyCtrl_script.GetHurt(level);
        dirScript_script.gold += 10 * (level + 1) * 2;
    }
}