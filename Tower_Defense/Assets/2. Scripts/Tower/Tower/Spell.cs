using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    TowerScript towerScript_script;
    GameObject enemy;
    
    public Vector2 dir;
    public float speed;
    int level;

    void Start()
    {
        towerScript_script = FindObjectOfType<TowerScript>();
        speed = (towerScript_script.level + 1) * 4.0f;
        //level = towerScript_script.level;

        //GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * speed);
        print("Speel is here!");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        if(transform.position.x == dir.x && transform.position.y == dir.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy")
        {
            EnemyHurt(coll.gameObject);
        }
    }

    public void EnemyHurt(GameObject enemy)
    {
        RedEnemy enemyCtrl_script = enemy.GetComponent<RedEnemy>();
        enemyCtrl_script.hp -= 4 * (level + 1);
        print("enemy hp: " + enemyCtrl_script.hp);
        Destroy(gameObject);
    }

}
