using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    GameObject parent;
    TowerScript towerScript;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        towerScript = parent.GetComponent<TowerScript>();
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            towerScript.Attack(coll.gameObject);
            //Attack(coll.gameObject);
        }
    }
}
