using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClick : MonoBehaviour
{
    GameObject tower;
    TowerScript towerScript;
    void Start()
    {
        tower = transform.parent.gameObject;
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        //    if (!hit) return;
        //    if (hit.collider.gameObject == gameObject)
        //    {
        //        towerScript = tower.GetComponent<TowerScript>();
        //        towerScript.IsClick();
        //    }
        //}
    }
}
