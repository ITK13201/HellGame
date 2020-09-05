﻿using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using HellGame.Model;

namespace HellGame.Wishlist
{
    public class WishlistUIController : MonoBehaviour
    {
        [SerializeField]
        List<WishlistItem> wishlists = new List<WishlistItem> { };

        GameController m_gc;

        void Start()
        {
            m_gc = GameController.EnsureGame;
            m_gc.Model.Player.UpdateCoinsEvent += OnCoinsUpdate;

            ApplyPriceStatus();
        }

        void OnDestroy()
        {
            m_gc.Model.Player.UpdateCoinsEvent -= OnCoinsUpdate;
        }

        public void EmitBuy(LeanButton sender)
        {
            // O(n)だけど無視
            foreach (var b in wishlists)
            {
                if (b.button != sender)
                {
                    continue;
                }

                // お金を消費してスパチャを投げる
                if (m_gc.Model.Player.Coins >= b.price)
                {
                    m_gc.Model.Player.Coins -= b.price;
                }
            }
        }

        void ApplyPriceStatus()
        {
            foreach (var b in wishlists)
            {
                b.button.interactable = m_gc.Model.Player.Coins >= b.price;
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
