using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD.Basic
{
    public class ShopManager : MonoBehaviour
    {
        public ShopItem[] items;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Init()
        {
           if(items == null || items.Length <= 0) return;
           
           for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                string datakey = Const.PLAYER_PREFIX_PREF + i;

                if (item != null)
                {
                    if(i == 0)
                        Pref.SetBool(datakey, true);
                    else
                    {
                        if (!PlayerPrefs.HasKey(datakey))
                            Pref.SetBool(datakey, false);
                    }
                }
            }
        }
    }

}