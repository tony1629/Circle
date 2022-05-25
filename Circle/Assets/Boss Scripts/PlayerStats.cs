using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerStats : CharacterStats
    {
        PlayerManager playerManager;
        HealthBar healthBar;
        PlayerAnimatorManager animatorHandler;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();

            healthBar = FindObjectOfType<HealthBar>();
           // animatorHandler = GetComponentInChildren<PlayerANimatorManager>();
        }
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(currentHealth);

        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        public override void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            if (playerManager.isInvulnerable)
                return;
            base.TakeDamage(damage, damageAnimation = "Damage_01");
            healthBar.SetCurrentHealth(currentHealth);
            animatorHandler.PlayTargetAnimation(damageAnimation, true);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
                animatorHandler.PlayTargetAnimation("Dead_01", true);
            }
        }
    }

}
