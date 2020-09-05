using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject p = null;

    Transform t=null;
    // Start is called before the first frame update
    void Start()
    {
        t = p.transform;
    }

    // Update is called once per frame
    void Update()


    {
        this.transform.position = new Vector3(t.position.x, t.position.y,-10);

    }
}
