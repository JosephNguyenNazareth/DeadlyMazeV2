using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace Monster
{
    
    public class Monster:MonoBehaviour
    {
        float Damage; //ability to damage player
        float HP; //its health point
        void Start()
        {
            HP = 120f;
            Damage = 10f;
        }
        public void TakeDamage(float amount)
        {
            HP -= amount;
            if (HP <= 0)
                Die();
        }
        public void Die()
        {
            Destroy(gameObject);
        }


    }
}
