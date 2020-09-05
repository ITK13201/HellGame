using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gen : MonoBehaviour
{

    public GameObject enemy;

    public GameObject player;

    public GameObject niku;

    public GameObject god;

    public int num = 0;

    int nikunum = 0;//VRゴーグルの出現場所



    Vector3[] pos = new Vector3[10];

    int c = 0;

    float gen_timer = 0;
    float nikutimer = 0;
    float nikutimer2 = 0;

    Vector3 pos1;


    // Start is called before the first frame update
    void Start()
    {
        enemy = (GameObject)Resources.Load("Enemy");
        for (int i = 0; i < 10; i++)
        {
            pos[i] = transform.GetChild(i).gameObject.transform.position;

        }

        pos1 = player.transform.position;
        Generate(30);

        NIKU();


    }

    // Update is called once per frame
    void Update()
    {
        nikutimer += Time.deltaTime;
        gen_timer += Time.deltaTime;

        if (gen_timer > 4.0)
        {
            Generate(3);
            gen_timer = 0f;
        }

    }
    void Generate(int num2)
    {

        for (int f = 0; f < num2; f++)
        {

            int w = Random.Range(0, 9);

            if ((pos[w].x - pos1.x) * (pos[w].x - pos1.x) + (pos[w].y - pos1.y) * (pos[w].y - pos1.y) > 9.0f && num < 60)
            {

                Instantiate(enemy, pos[w], Quaternion.identity);
                num++;

            }


        }

    }

    public void NIKU()//バ美肉するアイテムをランダムに出す関数
    {
        nikunum = Random.Range(0, 9);
        niku.transform.position = pos[nikunum];
    }

    public void KAMI_PAINTER()//神絵師を街の中央に出す関数
    {
        god.transform.position = new Vector2(1, 0);
    }

    public void KAMI_PAINTER2()//神絵師を消す関数(遠くに飛ばしているだけ)
    {
        god.transform.position = new Vector2(33, 8);
    }

}
