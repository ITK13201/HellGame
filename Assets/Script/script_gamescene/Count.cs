using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using HellGame;

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

    Image image;
    RectTransform r;

    bool once = true;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        r = GetComponent<RectTransform>();

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
            cg.alpha = 0;
            if (once)
            {
                GameController.Instance.InitGame();
                once = false;
            }
        }



    }
}
