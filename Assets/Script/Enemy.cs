using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private CircleCollider2D cl = null;
    private PlayerController p = null;

    public GameObject grid = null;
    public GameObject heart= null;
    private SpriteRenderer heart2 = null;

    private float rotate;


    bool right = false;

    int maindirection = 0;//進行方向 0→ 1↑ 2← 3↓ 

    int yuragi=0;

    float speed=3.0f;
    float yuragidelta = 0.78f;

    float yuragitimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cl= GetComponent<CircleCollider2D>();
        grid= GameObject.FindWithTag("terrain");
        heart2 = heart.GetComponent<SpriteRenderer>();
        p= GameObject.Find("Player").GetComponent<PlayerController>(); ;

        rotate = grid.transform.rotation.eulerAngles.z;

        maindirection = (int)Random.Range(0, 3.999f);

        yuragitimer = yuragidelta;
    }


    bool find = false;


    // Update is called once per frame
    void Update()
    {
        float go_ahead;

        RaycastHit2D[] d1 = new RaycastHit2D[4];
        RaycastHit2D[] d2 = new RaycastHit2D[4];
        RaycastHit2D d3;




        go_ahead = rotate + maindirection * 90 + yuragi;



        find =false;
        for (int i = -70; i <= 70; i++)
        {
            d3 = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos((rotate + maindirection * 90 + yuragi + 2 * i) * 3.1415f / 180.0f), Mathf.Sin((rotate + maindirection * 90 + yuragi + 2 * i) * 3.1415f / 180.0f)), 9.0f, 256 + 512);
            if (d3.collider)
            {
                if (d3.collider.gameObject.name == "Player"&&p.babiniku)
                {
                    go_ahead = rotate + maindirection * 90 + yuragi + 2 * i;
                        find = true;
                }
                else if(d3.collider.gameObject.name == "GOD")
                {
                    go_ahead = rotate + maindirection * 90 + yuragi + 2 * i;
                    find = true;
                }
            }
        }


        if (find)
        {
            speed = 6.0f;
            heart2.enabled = true;


        }else
        {
            speed = 3.0f;
            heart2.enabled = false;
        }



        rb.velocity = new Vector2(Mathf.Cos(go_ahead * 3.1415f / 180.0f) * speed, Mathf.Sin(go_ahead * 3.1415f / 180.0f) * speed);



         if (right && Mathf.Cos(go_ahead * 3.1415f / 180.0f) < -0.1f)
         {
             sr.flipX = false;
             right = false;
         }
         if (!right && Mathf.Cos(go_ahead * 3.1415f / 180.0f) > 0.1f)
         {
             sr.flipX = true;
             right = true;
         }


        d1[0] = Physics2D.Raycast(new Vector2(this.transform.position.x+cl.offset.x, this.transform.position.y + cl.offset.y),new Vector2(Mathf.Cos(rotate * 3.1415f / 180.0f), Mathf.Sin(rotate * 3.1415f / 180.0f)), 0.6f,256);
        d1[1] = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos((rotate+90) * 3.1415f / 180.0f), Mathf.Sin((rotate+90) * 3.1415f / 180.0f)), 0.6f, 256);
        d1[2] = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos((rotate + 180) * 3.1415f / 180.0f), Mathf.Sin((rotate + 180) * 3.1415f / 180.0f)), 0.6f, 256);
        d1[3] = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos((rotate + 270) * 3.1415f / 180.0f), Mathf.Sin((rotate + 270) * 3.1415f / 180.0f)), 0.6f, 256);


        d2[0] = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos(rotate * 3.1415f / 180.0f), Mathf.Sin(rotate * 3.1415f / 180.0f)), 3.0f, 256);
        d2[1] = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos((rotate + 90) * 3.1415f / 180.0f), Mathf.Sin((rotate + 90) * 3.1415f / 180.0f)), 3.0f, 256);
        d2[2] = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos((rotate + 180) * 3.1415f / 180.0f), Mathf.Sin((rotate + 180) * 3.1415f / 180.0f)), 3.0f, 256);
        d2[3] = Physics2D.Raycast(new Vector2(this.transform.position.x + cl.offset.x, this.transform.position.y + cl.offset.y), new Vector2(Mathf.Cos((rotate + 270) * 3.1415f / 180.0f), Mathf.Sin((rotate + 270) * 3.1415f / 180.0f)), 3.0f, 256);

        if (yuragitimer < 0.0f)
        {
            Yuragi_Update();
            yuragitimer = yuragidelta;
        }
        if (d1[(maindirection+1)%4].collider)
        {
            if (yuragi > 0)
            {
                yuragi = -yuragi;
            }
        }
        else if (d1[(maindirection + 3) % 4].collider)
        {
            if (yuragi < 0)
            {
                yuragi = -yuragi;
            }
        }
        if (d1[maindirection].collider)
        {
            Yuragi_Update();

             while (true)
             {
                 int v = (int)Random.Range(0, 3.999f);

                 if (v != maindirection &&!d2[v])
                 {
                     maindirection = v;
                     break;
                 }
             }           

        }

        


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "terrain")
        {
            maindirection = (maindirection + 2) % 4;
            Yuragi_Update();
        }
        else if (collision.collider.tag == "enemy")
        {
            yuragi = -yuragi;

        }
        else if(collision.collider.tag == "Player"&&find)
        {
            Destroy(this.gameObject);
        }

        

    }


    private void FixedUpdate()
    {
        yuragitimer -= Time.fixedDeltaTime;
    }

    void Yuragi_Update()
    {
        yuragi= Random.Range(0, 30)* (1-2*Random.Range(0, 1));
    }


}
