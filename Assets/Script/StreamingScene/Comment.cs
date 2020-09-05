using UnityEngine;
using HellGame.Model;

namespace HellGame.StreamingScene
{
    [System.Serializable]
    public class Comment
    {
        public UserIconPair userIconPair = new UserIconPair("Kiga Daisuke");
        public string comment = "僕のおうちに来るしん！";
        public float timestamp = 0;
        public int price = 0;
        public bool IsSuperChat => price > 0;
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
