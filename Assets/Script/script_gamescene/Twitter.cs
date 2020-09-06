using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HellGame;
using HellGame.State;
using HellGame.Model;

public class Twitter : MonoBehaviour
{
    int mes_num;
    public GameObject[] window = new GameObject[3];
    Twitter2[] sc = new Twitter2[3];
    GameController m_gc;



    // Start is called before the first frame update
    void Start()
    {
        for (int q = 0; q < 3; q++)
        {
            sc[q] = window[q].GetComponent<Twitter2>();
        }

        m_gc = GameController.EnsureGame;
        m_gc.Model.Bias.StateMachine.StateMachineTransition += OnBiasStateChanged;
    }

    void OnDestroy()
    {
        m_gc = null;
    }


    public void New_Message(string name, string mes)
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

    void OnBiasStateChanged(IStateMachine<BiasModel, BiasStateType> sender_, BiasStateType type)
    {
        var sender = sender_ as StateMachine<BiasModel, BiasState, BiasStateType>;

        // 配信中の場合
        switch (sender.State.Type)
        {
            case BiasStateType.Streaming:
                New_Message("Hogetter", $"白いメスケモが配信を開始しました");
                break;
            case BiasStateType.Inactive:
                New_Message("Hogetter", $"白いメスケモが配信を終了しました");
                break;
            case BiasStateType.Preparing:
                var s = sender.State as BiasPreparingState;
                New_Message("Hogetter", $"白いメスケモがあと{s.TimeToReady}秒で配信を開始します");
                break;
            default:
                // unreachable!()
                break;
        }
    }
}
