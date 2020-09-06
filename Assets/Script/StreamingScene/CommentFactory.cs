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

        List<GameObject> m_comments = new List<GameObject> { };

        const int kMaxComments = 10;
        const int kChatSectionHeight = 315;

        void Start()
        {
            //
        }

        void RelayoutChat()
        {
            // コメントを下から積み上げていく
            float totalHeight = 0;

            for (int i = m_comments.Count - 1; i >= 0; --i)
            {
                var c = m_comments[i];
                var tr = c.transform as RectTransform;
                var pos = tr.anchoredPosition;

                totalHeight += tr.sizeDelta.y;
                pos.y = -kChatSectionHeight + totalHeight;
                tr.anchoredPosition = pos;
            }

            if (totalHeight <= kChatSectionHeight)
            {
                // 上に詰める
                for (int i = 0; i < m_comments.Count; ++i)
                {
                    var c = m_comments[i];
                    var tr = c.transform as RectTransform;
                    var pos = tr.anchoredPosition;

                    pos.y += kChatSectionHeight - totalHeight;
                    tr.anchoredPosition = pos;
                }
            }
        }

        public void EmitComment()
        {
            AppendCommentView(ConstructNormalComment(NextComment()));
        }

        public void EmitSuperchat(int budget)
        {
            var c = NextComment();
            c.price = budget;
            AppendCommentView(ConstructSuperChatComment(c));
        }

        public void AppendCommentView(GameObject view)
        {
            m_comments.Add(view);

            while (m_comments.Count >= kMaxComments)
            {
                var g = m_comments[0];
                m_comments.RemoveAt(0);
                Destroy(g);
            }

            // コメントの再配置
            RelayoutChat();
        }

        public void ClearComment()
        {
            foreach (var c in m_comments)
            {
                Destroy(c);
            }
            
            m_comments.Clear();
        }

        GameObject ConstructNormalComment(Comment data)
        {
            Debug.Assert(!data.IsSuperChat, "CommentFactory：　通常コメントである必要があります．");

            var view = Instantiate(commentPrefab, chatContainer.transform);

            var image = view.GetComponentInChildren<Image>();
            var text = view.GetComponentInChildren<Text>();

            image.sprite = data.userIconPair.icon;
            text.text = $"<color=#666>{data.userIconPair.userName}</color>  {data.comment}";

            return view;
        }

        GameObject ConstructSuperChatComment(Comment data)
        {
            Debug.Assert(data.IsSuperChat, "CommentFactory：　スーパーチャットである必要があります．");

            var view = Instantiate(superChatPrefab, chatContainer.transform);
            view.SetActive(true);

            // TODO: 

            return view;
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
