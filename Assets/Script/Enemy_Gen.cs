using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gen : MonoBehaviour
{

    public GameObject enemy;

    int c = 0;

    public int x;
    public int y;

    float gen_timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy= (GameObject)Resources.Load("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        gen_timer += Time.deltaTime;

        if(gen_timer>2.0){
            Generate(3);
            gen_timer = 0f;
        }
    }

    void Generate(int num) {

        for(int f = 0; f < num; f++)
        {
            Instantiate(enemy, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        }

    }

}
