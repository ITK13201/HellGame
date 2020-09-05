using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Count2 : MonoBehaviour
{
    float timer = 0.0f;

    public CanvasGroup cg;

    public bool finish= false;

    Image image;
    RectTransform r;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        r = GetComponent<RectTransform>();

        DateTime awakeDateTime = DateTime.Now;
    }


    //FINISHを呼ぶと画面にFINISHとでて、動作停止する。2.5秒後にリザルトに移行する
    public void FINISH()
    {
        finish = true;
        timer = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {
        cg.alpha = 0;
        
        if (finish)
        {
            Time.timeScale = 0;



            timer += Time.unscaledDeltaTime;
            if (timer < 0.5f) {
                cg.alpha = 2 * timer;

            }
            else if(timer < 2.5f)
            {
                cg.alpha = 1.0f;

            }
            else
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
