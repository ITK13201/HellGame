﻿using HellGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Tweet : MonoBehaviour
{
    public Button TweetButton;
    public string text = "HellGame";
    public string linkurl = "test.com";
    public string hashtags = "HellGame";

#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void OpenToBlankWindow(string _url);
#endif

    // open tweet window
    private void Tweeting()
    {
        var gc = GameController.Instance;

        var url = "https://twitter.com/intent/tweet?"
            + "text=" + text + $" ￥{(gc.WishlistTotal + gc.SuperChatTotal):#,0} ご支援ありがとうにゃ！\n"
            + "&url=" + linkurl+"\n"
            + "&hashtags=" + $"{hashtags},みすゲームジャム2020";

#if UNITY_EDITOR
        Application.OpenURL(url);
#elif UNITY_WEBGL
        OpenToBlankWindow(url);
#else
        Application.OpenURL(url);
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        TweetButton.onClick.AddListener(
            () =>
            {
                Tweeting();
            }
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Tweeting();
        }
    }
}
