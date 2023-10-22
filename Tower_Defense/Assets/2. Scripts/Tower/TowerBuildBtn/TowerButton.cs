using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject tower;
    GameObject tower_clone;

    DirScript dirScript_script;

    Animator anim;

    int cnt = 0;
    void Start()
    {
        transform.gameObject.SetActive(true);
        anim = GetComponentInChildren<Animator>();
        dirScript_script = FindObjectOfType<DirScript>();
    }

    void Update()
    {
        //if (Input.GetMouseButtonUp(0) && cnt == 1)
        //{
        //    cnt = 0;
        //    anim.SetBool("isUp", false);
        //}
    }

    private void OnMouseDown()
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

    public void Build()
    {
        if(dirScript_script.gold >= 50)
        {
            tower_clone = Instantiate(tower, transform.position, Quaternion.identity);
            tower_clone.transform.parent = transform.parent.transform;
            TowerScript towerScript = tower_clone.transform.GetComponent<TowerScript>();
            towerScript.towerTile = transform.gameObject;
            transform.gameObject.SetActive(false);
            dirScript_script.gold -= 50;
            print("bulid");
        }
        else
        {
            // ui: You don't have enough gold!
            print("You don't have enough gold!");
        }
    }

    public void Cancle()
    {
        if(cnt == 1)
        {
            cnt = 0;
            anim.SetBool("isUp", false);
        }
    }


}
