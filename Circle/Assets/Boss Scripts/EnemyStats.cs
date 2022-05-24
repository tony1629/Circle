using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyStats : MonoBehaviour
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
            else
            {
                enemyBossManager.
            }
            
            enemyAnimatorManager.PlayTargetAnimation(damageAnimation, true);

            if(currentHealth <= 0)
            {
                HandleDeath();
            }
        }
    }
}

