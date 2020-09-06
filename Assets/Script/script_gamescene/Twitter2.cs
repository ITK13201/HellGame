using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Twitter2 : MonoBehaviour
{

    float timer =0.0f;
    public bool awake = false;

    public Text text1;
    public Text text2;
    public CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (awake)
        {
            timer += Time.deltaTime;
        }
        else timer = 0;


        if (timer > 3.0f)
        {
            awake = false;
            cg.alpha = 0;


        }
        else if (timer > 2.5f)
        {
            cg.alpha = 1.0f - (timer - 2.5f)*2.0f;
        }
        else if (timer > 0.5f)
        {
            cg.alpha = 1.0f;

        }      
        else if (timer >= 0)
        {
            cg.alpha = 2.0f * timer;

        }


    }

    public void START(string name,string mes)
    {
        text1.text = name;
        text2.text = mes;

        awake = true;

    }
}
