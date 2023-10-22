using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text[] text_time;
    public float timer = 0.0f;
    public Text text;
    public int game_level;

    DirScript dirScript_script;

    void Start()
    {
        text.text = "Time: ";
        game_level = 1;
        dirScript_script = FindObjectOfType<DirScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        text_time[0].text = ((int)timer/3600)+"h".ToString();
        text_time[1].text = ((int)timer/60%60)+"m".ToString();
        text_time[2].text = ((int)timer%60)+"s".ToString();

        if(timer / 60 >= game_level)
        {
            game_level++;
            print("Game Level: "+ game_level);
            if (game_level == 10)
            {
                dirScript_script.GameWin();
            }
        }
    }
}
