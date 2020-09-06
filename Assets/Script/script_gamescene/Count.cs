using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Count : MonoBehaviour
{
    float timer = 4.0f;
    int f = 0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite spritego;
    public Sprite spritefinish;
    public CanvasGroup cg;

    public GameObject bgm;
    Music music;

    Image image;
    RectTransform r;

    // Start is called before the first frame update
    void Start()
    {
        music = bgm.GetComponent<Music>();
        image = GetComponent<Image>();
        r = GetComponent<RectTransform>();
        music.BGM(3);
        DateTime awakeDateTime = DateTime.Now;
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.unscaledDeltaTime;

        if (timer > 2.0f)
        {
            Time.timeScale = 0;
            image.sprite = sprite3;
        }
        else if (timer > 1.0f)
        {
            image.sprite = sprite2;
            Time.timeScale = 0;

        }
        else if (timer > 0.0f)
        {
            image.sprite = sprite1;
            Time.timeScale = 0;

        }
        else if (timer > -1.0f)
        {
            image.sprite = spritego;
            r.localScale = new Vector2(16, 4);
            Time.timeScale = 1;

        }
        else
        {
            if (music.num2 ==3)
            {
                music.BGM(0);
            }
            cg.alpha = 0;

        }



    }
}
