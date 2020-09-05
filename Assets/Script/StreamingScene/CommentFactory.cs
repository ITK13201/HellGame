using UnityEngine;
using System.Collections.Generic;

namespace HellGame.StreamingScene
{
    public class CommentFactory : MonoBehaviour
    {
        // なんかEditorのほうから設定できたほうが楽そうだから...（Spriteとか）
        [SerializeField]
        List<UserIconPair> UserIconPairs;

        [SerializeField]
        List<string> CommentTemplates;

        void Start()
        {

        }

        Comment NextComment()
        {
            var userIconPair =
                UserIconPairs[Mathf.FloorToInt(Random.Range(0, UserIconPairs.Count))];

            var comment =
                CommentTemplates[Mathf.FloorToInt(Random.Range(0, CommentTemplates.Count))];

            return new Comment
            {
                userIconPair = userIconPair,
                comment = comment,
            };
        }
    }
}
