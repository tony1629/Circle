using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyStats : CharacterStats
    {
        EnemyAnimatorManager enemyAnimatorManager;
        EnemyBossManager enemyBossManager;
        public UIBossHealthBar bossHealthBar;
        public bool isBoss;


        private void Awake()
        {
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
            enemyBossManager = GetComponent<EnemyBossManager>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }
        void Start()
        {
           if (!isBoss)
            {
                bossHealthBar.SetBossMaxHealth(maxHealth);
            }
            
        }
        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        public void TakeDamageNoAnimation(int damage)
        {

        }
        public override void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            base.TakeDamage(damage, damageAnimation = "Damage_01");
            if (!isBoss)
            {
                bossHealthBar.SetHealth(currentHealth);
            }
            else if (isBoss && enemyBossManager != null)
            {
                enemyBossManager.UpdateBossHealthBar(currentHealth);
            }
            
            enemyAnimatorManager.PlayTargetAnimation(damageAnimation, true);

            if(currentHealth <= 0)
            {
                HandleDeath();
            }
        }
    }
}

