using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    DirScript dirSciript;

    public Slider hpBar;
    public int max_hp;
    public int hp;
    void Start()
    {
        dirSciript = FindObjectOfType<DirScript>();
        max_hp = 500;
        hp = max_hp;
        hpBar.maxValue= max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        hp = dirSciript.player_hp;
        hpBar.maxValue = max_hp;
        hpBar.value = hp;
    }
}
