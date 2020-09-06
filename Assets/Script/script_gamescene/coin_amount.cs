using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HellGame;

public class coin_amount : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gc = GameController.Instance;
        text.text = gc.Model.Player.Coins.ToString("D7");
    }
}
