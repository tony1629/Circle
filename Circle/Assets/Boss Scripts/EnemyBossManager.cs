using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AL
{
    public class EnemyBossManager : MonoBehaviour
    {
        //handle switching phase
        //Handle switching attack patterns
        public string bossName;
        UIBossHealthBar bossHealthBar;
        EnemyStats enemyStats;

        private void Awake()
        {
            bossHealthBar = FindObjectOfType<UIBossHealthBar>();
            enemyStats = GetComponent<EnemyStats>();
        }
        private void Start()
        {
            bossHealthBar.SetBossName(bossName);
            bossHealthBar.SetBossMaxHealth(enemyStats.maxHealth);
        }

        public void UpdateBossHealthBar(int currentHealth) 
        {
            bossHealthBar.SetBossCurrentHealth(currentHealth);
        }
    }
}

