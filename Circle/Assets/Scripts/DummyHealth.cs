using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour
{
    public int DummyMaxHealth = 100;
    public int DummyCurrentHealth;
    public HealthBar DummyHealthBar;
    // Start is called before the first frame update
    
void Start()
    {
        DummyCurrentHealth = DummyMaxHealth;
        DummyHealthBar.SetMaxHealth(DummyMaxHealth);
    }

    public void DummyTakeDamage(int damage)
    {
        DummyCurrentHealth -= damage;
        DummyHealthBar.SetHealth(DummyCurrentHealth);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "john")
        {
            DummyTakeDamage(25);
        }
    }
}
