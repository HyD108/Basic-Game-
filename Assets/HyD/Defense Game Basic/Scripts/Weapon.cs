using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD.Basic
{
    public class Weapon : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Const.ENEMY_TAG))
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                if (enemy)
                    enemy.Died();
            }
                
        }
    }
}
