using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace HyD.Basic
{
    [System.Serializable]
    public class ShopItem
    {
        public Player playerPrefabs;
        public int price;
        public Sprite previewImg;
    }
}