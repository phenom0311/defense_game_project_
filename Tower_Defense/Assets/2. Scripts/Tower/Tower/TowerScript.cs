using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject spell;
    public GameObject towerTile;
    Spell spell_script;

    public Sprite[] levels;
    SpriteRenderer sr;

    DirScript dirScript_script;

    Animator anim;

    public float cur_cool_time;
    float[] cool_times;
    int[] upgrade_cost;

    public int level;
    int gold, cnt = 0;

    void Start()
    {
        dirScript_script = FindObjectOfType<DirScript>();
        anim = GetComponent<Animator>();

        sr = GetComponentInChildren<SpriteRenderer>();
        level = 0;
        sr.sprite = levels[level];
        //enemy = FindObjectOfType<RedEnemy>().gameObject;

        spell_script = spell.GetComponent<Spell>();
        cur_cool_time = 0.0f;

        cool_times = new float[3];
        cool_times[0] = 0.8f;
        cool_times[1] = 0.6f;
        cool_times[2] = 0.4f;

        upgrade_cost= new int[3];
        upgrade_cost[0] = 50;
        upgrade_cost[1] = 300;
        upgrade_cost[2] = 700;
    }

    // Update is called once per frame
    void Update()
    {
        cur_cool_time -= Time.deltaTime;
        if(cur_cool_time <= 0.0f) cur_cool_time = 0.0f;
        gold = dirScript_script.gold;

        
    }

    //private void OnMouseDown()
    //{
    //    if (cnt == 0)
    //    {
    //        cnt = 1;
    //        anim.SetBool("isUp", true);
    //    }
    //    else
    //    {
    //        cnt = 0;
    //        anim.SetBool("isUp", false);
    //    }
    //}

    public void IsClick()
    {
        if (cnt == 0)
        {
            cnt = 1;
            anim.SetBool("isUp", true);
        }
        else
        {
            cnt = 0;
            anim.SetBool("isUp", false);
        }
    }

    public void Attack(GameObject enemy)
    {
        if(cur_cool_time <= 0.0f)
        {
            spell_script.dir = enemy.transform.position;
            Instantiate(spell, new Vector3(transform.position.x - 0.12f, transform.position.y + 0.458f, transform.position.z), Quaternion.identity);
            cur_cool_time = cool_times[level];
        }
    }

    public void Upgrade()
    {
        if (level < 2)
        {
            if (gold >= upgrade_cost[level + 1])
            {
                sr.sprite = levels[level + 1];
                dirScript_script.gold -= upgrade_cost[level + 1];
                level++;
            }
            else
            {
                // ui: You don't have enough gold!
                print("You don't have enough gold!");
            }
        }
        else
        {
            print("Max Level!");
        }
    }

    public void Sell()
    {
        if (cnt == 1)
        {
            cnt = 0;
            anim.SetBool("isUp", false);
        }
        dirScript_script.gold += upgrade_cost[level] / 2;
        //towerTile.SetActive(true);
        towerTile.GetComponent<PolygonCollider2D>().enabled = true;
        Destroy(gameObject);
    }

    public void Cancle()
    {
        if (cnt == 1)
        {
            cnt = 0;
            anim.SetBool("isUp", false);
        }
    }
}
