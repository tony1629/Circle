using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int BossMaxHealth = 1000;
    public int BossCurrentHealth;
    public HealthBar BossHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        BossCurrentHealth = BossMaxHealth;
        BossHealthBar.SetMaxHealth(BossMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            BossTakeDamage(25);
        }
    }
    public void BossTakeDamage(int damage)
    {
        BossCurrentHealth -= damage;
        BossHealthBar.SetHealth(BossCurrentHealth);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BossTakeDamage(25);

        }
    }
}
