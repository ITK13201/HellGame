using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer2 : MonoBehaviour
{
    SpriteRenderer s = null;

    public float y;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        s.sortingOrder = 100 - (int)(y * 10);
    }
}
