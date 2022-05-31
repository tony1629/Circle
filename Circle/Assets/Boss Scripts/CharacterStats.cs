using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EL
{
    public class CharacterStats : MonoBehaviour
    {
        public int healthLevel=10;
        public int maxHealth;
        public int currentHealth;

        public bool isDead;

        public virtual void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            if (isDead)
                return;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
            }
        }
    }
}

