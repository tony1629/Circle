using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int BossMaxhealth = 500;
	public int BossCurrentHealth;
	public HealthBar BossHealthBar;

	public GameObject deathEffect;

	public bool isInvulnerable = false;
	private void Start()
	{
		BossCurrentHealth = BossMaxhealth;
        BossHealthBar.SetMaxHealth(BossMaxhealth);
	}
    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		BossCurrentHealth -= damage;
		BossHealthBar.SetHealth(BossCurrentHealth);

		if (BossCurrentHealth <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
			BossCurrentHealth-=(damage/2);
		}

		if (BossCurrentHealth <= 0)
		{
			Die();
		}
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			TakeDamage(25);
			
        }
    }
	public void DoDamage(int damage)
    {
		
    }
	
    void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
