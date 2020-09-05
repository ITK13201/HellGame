using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Message : MonoBehaviour
{
    float speed = 1.0f;
    float moveDis = 70.0f;
    float moveTime = 0.5f;

    string m;
    RectTransform r;

    int posy;

    private Vector3 defaltPos;
    private float timer = 0.0f;
    Canvas canvas;

    private void Start()
    {
        //初期化
       
            r.alpha = 0.0f;

            cg.transform.position = defaltPos - Vector3.up * moveDis;
            canvas = this.transform.Find("Canvas").GetComponent<Canvas>();
        }
    }
    public void Init(int y,string message) 
    {
        posy = y;
        m = message;
        defaltPos = new Vector3(640, posy, 0);

    }

    private void Update()
    {
        //プレイヤーが範囲内に入った
        
            canvas.enabled = true;
            //上昇しながらフェードインする
            if (cg.transform.position.y < defaltPos.y || cg.alpha < 1.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position += Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer += speed * Time.deltaTime;
            }
            //フェードイン完了
            else
            {
                cg.alpha = 1.0f;
                cg.transform.position = defaltPos;
            }
        
            //下降しながらフェードアウトする
            if (cg.transform.position.y > defaltPos.y - moveDis || cg.alpha > 0.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position -= Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer -= speed * Time.deltaTime;
            }
            //フェードアウト完了
            else
            {
                timer = 0.0f;
                cg.alpha = 0.0f;
                cg.transform.position = defaltPos - Vector3.up * moveDis;
            Destroy(this.gameObject);

            
        
    }

}*/