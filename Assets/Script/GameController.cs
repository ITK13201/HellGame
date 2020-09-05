using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController _controller;

    /// <summary>
    /// ゲームコントローラのインスタンスを取得する．
    /// </summary>
    public static GameController Instance {
        get
        {
            if (_controller == null)
            {
                var i = FindObjectOfType<GameController>();
                if (i != null)
                {
                    _controller = i;
                    return i;
                }

                var obj = new GameObject("Game Controller");
                _controller = obj.AddComponent<GameController>();
                DontDestroyOnLoad(obj);
            }

            return _controller;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
