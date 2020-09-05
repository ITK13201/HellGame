using UnityEngine;
using System.Collections.Generic;

namespace HellGame.StreamingScene
{
    public class CommentFactory : MonoBehaviour
    {
        [SerializeField]
        List<UserIconPair> UserIconPairs;

        [SerializeField]
        List<string> CommentTemplates;
        
        void Start()
        {

        }
    }
}
