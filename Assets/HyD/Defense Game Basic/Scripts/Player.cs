using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HyD.Basic
{
    public class Player : MonoBehaviour, IcomponentChecking
    {
        public float atkRate;
        private float m_curAtkRate;
        private bool m_isAttacked;
        private bool m_isDead;

        private Animator m_anim;

        public bool IsComponentNull()
        {
            return m_anim == null;
        }

        private void Awake()
        {
            this.m_anim = GetComponent<Animator>();
            m_curAtkRate = atkRate;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(IsComponentNull()) return;
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                if (m_anim)
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_isAttacked = true;
            }
            if (m_isAttacked)
            {
                m_curAtkRate -= Time.deltaTime;

                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false;
                    m_curAtkRate = atkRate;
                }
            }
        }
        public void ResetAttackAnim()
        {
            if(IsComponentNull()) return;
            if (m_anim)
            {
                m_anim.SetBool(Const.ATTACK_ANIM, false);
            }
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(IsComponentNull()) return;
            Debug.Log(col.name);
            if (col.CompareTag(Const.ENEMY_WEAPON_TAG) && !m_isDead)
            {
                m_anim.SetTrigger(Const.DEAD_ANIM);
                m_isDead = true;
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
            }
        }

    }

}