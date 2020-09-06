using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    int rotate = 90;
    float speed;
    float time;
    Rigidbody2D r = null;
    Transform t = null;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4.0f, 6.0f);
        rotate += Random.Range(-25, 25);
        r = GetComponent<Rigidbody2D>();
        r.velocity = new Vector2(speed * Mathf.Cos(rotate), speed * Mathf.Sin(rotate));
        time = Random.Range(0.5f, 0.75f);
        Destroy(gameObject, time);
    }

    // Update is called once per frame

}
