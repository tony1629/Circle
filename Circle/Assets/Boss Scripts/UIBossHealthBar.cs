using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class UIBossHealthBar : MonoBehaviour
    {
        public Text bossName;
        Slider slider;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
        }
        private void Start()
        {
            SetHealthBarToInactive();
        }
        public void SetBossName(string name)
        {
            bossName.text = name;
        }
        public void SetUIHealthBarToActivate()
        {
            slider.gameObject.SetActive(true);
        }
        public void SetHealthBarToInactive()
        {

        }
        public void SetBossMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }
        public void SetBossCurrentHealth(int currentHealth)
        {
            slider.value = currentHealth;   
        }
    }
}

