using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HellGame;

public class clock : MonoBehaviour
{

    public float time;//この変数で残り時間の表示を管理する。1.0fが開始で0が終了
    private GameController m_gc;

    public GameObject hand = null;
    RectTransform a = null;

    // Start is called before the first frame update
    void Start()
    {
        a = hand.GetComponent<RectTransform>();
        m_gc = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        time = m_gc.Active ? m_gc.Now / m_gc.timeLimit : 0.0f;
        a.rotation = Quaternion.Euler(new Vector3(0,0,-time * 360.0f));
    }
}
