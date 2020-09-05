using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using HellGame.Model;

namespace HellGame.Wishlist
{
    public class WishlistUIController : MonoBehaviour
    {
        [SerializeField]
        List<WishlistItem> wishlists = new List<WishlistItem> {};

        void Start()
        {
            var gc = GameController.EnsureGame;
            gc.Model.Player.UpdateCoinsEvent += OnCoinsUpdate;

            ApplyPriceStatus();
        }

        void OnDestroy()
        {
            var gc = GameController.Instance;
            gc.Model.Player.UpdateCoinsEvent -= OnCoinsUpdate;
        }

        public void EmitBuy(LeanButton sender)
        {
            var gc = GameController.Instance;
            // O(n)だけど無視
            foreach (var b in wishlists)
            {
                if (b.button != sender)
                {
                    continue;
                }

                // お金を消費してスパチャを投げる
                if (gc.Model.Player.Coins >= b.price)
                {
                    gc.Model.Player.Coins -= b.price;
                }
            }
        }

        void ApplyPriceStatus()
        {
            var gc = GameController.Instance;

            foreach (var b in wishlists)
            {
                b.button.interactable = gc.Model.Player.Coins >= b.price;
            }
        }

        void OnCoinsUpdate(PlayerModel _sender, int _coins)
        {
            ApplyPriceStatus();
        }
    }

    [System.Serializable]
    public class WishlistItem
    {
        public LeanButton button = null;
        public int price = 0;
    }
}
