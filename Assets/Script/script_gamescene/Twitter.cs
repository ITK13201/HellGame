using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Twitter : MonoBehaviour
{
    int mes_num;
    public GameObject[] window = new GameObject[3];
    Twitter2[] sc = new Twitter2[3];



    // Start is called before the first frame update
    void Start()
    {
        for(int q = 0; q < 3; q++)
        {
            sc[q] = window[q].GetComponent<Twitter2>();
        }
    }


    void New_Message(string name ,string mes)
    {
        for (int q = 0; q < 3; q++)
        {
            if (!sc[q].awake)
            {
                sc[q].START(name, mes);
                break;
            }

        }
    }


}
