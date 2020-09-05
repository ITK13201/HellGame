using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gen : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player;



    Vector3[] pos= new Vector3[10];

    int c = 0;

    float gen_timer = 0;

    Vector3 pos1;


    // Start is called before the first frame update
    void Start()
    {
        enemy= (GameObject)Resources.Load("Enemy");
        for(int i=0; i < 10; i++)
        {
            pos[i]=transform.GetChild(i).gameObject.transform.position;

        }

        pos1 = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        


        gen_timer += Time.deltaTime;

        if(gen_timer>4.0){
            Generate(6);
            gen_timer = 0f;
        }
    }
    void Generate(int num) {

        for(int f = 0; f < num; f++)
        {

            int w = Random.Range(0, 9);

            if((pos[w].x - pos1.x) * (pos[w].x - pos1.x) + (pos[w].y-pos1.y)* (pos[w].y - pos1.y) > 4.0f)
            {

                Instantiate(enemy, pos[w], Quaternion.identity);

            }


        }

    }




}
