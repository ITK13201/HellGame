using UnityEngine;
using System.Collections.Generic;

namespace HellGame.StreamingScene
{
    public class UIController : MonoBehaviour
    {
        GameController m_gameController;

        void Start()
        {
            m_gameController = GetComponent<GameController>();
        }

        void OnDestroy()
        {

        }
    }
}
