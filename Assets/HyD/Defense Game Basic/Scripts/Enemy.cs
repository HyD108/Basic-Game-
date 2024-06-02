using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD.Basic
{
    public class Enemy : MonoBehaviour, IcomponentChecking
    {
        public float speed;
        public float atkDistance;
        private Animator m_anim;
        private Rigidbody2D m_rb;
        private Player m_player;
        private bool m_isDead;

        private GameManager m_gm;
       

        private void Awake()
        {
            this.m_anim = GetComponent<Animator>();
            this.m_rb = GetComponent<Rigidbody2D>();
            this.m_player = FindObjectOfType<Player>();
            this.m_gm = FindObjectOfType<GameManager>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(IsComponentNull()) return;

            float DisToPlayer = Vector2.Distance(m_player.transform.position, transform.position);

            if ( DisToPlayer <= atkDistance)
            {
                if(m_anim)
                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_rb.velocity = Vector2.zero;
            }
            else
            {
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
            }
        }
        public void Died()
        {
            if (IsComponentNull() || m_isDead) return;

            m_isDead = true;
            m_anim.SetTrigger(Const.DEAD_ANIM);
            m_rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
            if (m_gm)
                m_gm.Score++;
            Destroy(gameObject, 2f);
        }

        public bool IsComponentNull()
        {
            return m_anim == null || m_rb == null || m_player == null;
        }
    }
}
