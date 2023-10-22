using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIDir : MonoBehaviour
{
    Animator anime_setting, anim_info;
    
    // Start is called before the first frame update
    void Start()
    {
        anime_setting = GetComponentInChildren<Animator>();
        anim_info = transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Animator>();
    }

    public void Setting()
    {
        anime_setting.SetBool("isUp", true);
    }
    public void Continue()
    {
        anime_setting.SetBool("isUp", false);
    }

    public void GameInfo()
    {
        anim_info.SetBool("isInfo", true);
    }

    public void GameInfoCancle()
    {
        anim_info.SetBool("isInfo", false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
