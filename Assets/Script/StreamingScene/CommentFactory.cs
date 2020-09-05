using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace HellGame.StreamingScene
{
    public class CommentFactory : MonoBehaviour
    {
        // なんかEditorのほうから設定できたほうが楽そうだから...（Spriteとか）
        [SerializeField]
        List<UserIconPair> UserIconPairs = new List<UserIconPair> { };

        [SerializeField]
        List<string> CommentTemplates = new List<string> { };

        [SerializeField]
        GameObject commentPrefab = null;

        [SerializeField]
        GameObject superChatPrefab = null;

        [SerializeField]
        GameObject chatContainer = null;

        Queue<GameObject> m_comments = new Queue<GameObject> { };

        const int kMaxComments = 6;

        void Start()
        {

        }

        public void EmitComment()
        {
            var view = Instantiate(commentPrefab, chatContainer.transform);
            var data = NextComment();

            var image = view.GetComponentInChildren<Image>();
            var text = view.GetComponentInChildren<Text>();

            image.sprite = data.userIconPair.icon;
            text.text = $"<color=#666>{data.userIconPair.userName}</color>  {data.comment}";

            // すべてのコメントを下にずらす
            foreach (var c in m_comments)
            {
                var tr = c.transform as RectTransform;
                var pos = tr.anchoredPosition;
                pos.y -= (view.transform as RectTransform).sizeDelta.y;
                tr.anchoredPosition = pos;
            }

            m_comments.Enqueue(view);

            while (m_comments.Count >= kMaxComments)
            {
                var g = m_comments.Dequeue();
                Destroy(g);
            }
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
