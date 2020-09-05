using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer_m : MonoBehaviour
{
    SpriteRenderer s = null;
    Transform t = null;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        t= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        s.sortingOrder = 100 - (int)(t.position.y*10);
    }
}
