using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tweet : MonoBehaviour
{
    public Button TweetButton;
    public string text = "HellGame";
    public string linkurl = "test.com";
    public string hashtags = "HellGame";

    // open tweet window
    private void Tweeting()
    {
        var url = "https://twitter.com/intent/tweet?"
            + "text=" + text
            + "&url=" + linkurl
            + "&hashtags=" + hashtags;

#if UNITY_EDITOR
        Application.OpenURL(url);
#elif UNITY_WEBGL
        Application.ExternalEval(string.Format("window.open('{0}','_blank')", url));
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
