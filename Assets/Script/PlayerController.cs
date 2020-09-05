using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb = null;



    public Sprite sp1;//バ美肉の画像
    public Sprite sp2;//普通の画像


    public bool babiniku = true;//バ美肉状態かどうかのフラグ




    public GameObject grid = null;

    SpriteRenderer s = null;
    Transform t = null;


    private float rotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rotate = grid.transform.rotation.eulerAngles.z;
        s = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
    }

    bool right = false;

    // Update is called once per frame
    void Update()
    {
        s.sortingOrder = 100 - (int)(t.position.y * 10);

        if (babiniku)
        {
            s.sprite = sp1;

        }
        else s.sprite = sp2;


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float vx;
        float vy;


        float speed =4.0f;
        
            vy = y*Mathf.Cos(rotate*3.1415f/180.0f) + x*Mathf.Sin(rotate * 3.1415f / 180.0f);
            vx = -y*Mathf.Sin(rotate * 3.1415f / 180.0f) +x*Mathf.Cos(rotate * 3.1415f / 180.0f);

            rb.velocity = new Vector2(vx*speed,vy*speed);


        if (right && vx < -0.1f)
        {
            s.flipX = false;
            right = false;
        }
        if (!right && vx > 0.1f)
        {
            s.flipX = true;
            right = true;
        }
       
    }




}
