namespace Agent
{
    //System
    using System.Collections;
    using System.Collections.Generic;

    //UnityEngine
    using UnityEngine;

    public class Character : MonoBehaviour
    {
        protected float hp = default;

        public virtual void TakeDamage(float damage)
        {
            hp -= damage;

            if(hp <= 0 )
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Debug.Log("»ç¸Á");
        }
    }
}