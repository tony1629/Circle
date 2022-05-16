using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyStats : MonoBehaviour
    {
        EnemyAnimatorManager enemyAnimatorManager;
        public UIBossHealthBar bossHealthBar;

        private void Awake()
        {
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        }
        void Start()
        {
            //maxHealth = SetMaxHealthFromHealthLevel();
            //currentHealth = maxHealth;
            
        }
    }
}

