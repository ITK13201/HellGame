using UnityEngine;
using HellGame.Model;

namespace HellGame.StreamingScene
{
    [System.Serializable]
    public class Comment
    {
        public UserIconPair userIconPair = new UserIconPair("Kiga Daisuke");
        public string comment = "僕のおうちに来るしん！";
    }

    [System.Serializable]
    public class UserIconPair
    {
        public string userName;

        public Sprite icon;

        public UserIconPair(string userName)
        {
            this.userName = userName;
            icon = null;
        }
    }
}
