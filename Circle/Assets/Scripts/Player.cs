using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerMaxHealth = 1000;
    public int PlayerCurrentHealth;
    public HealthBar PlayerHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        PlayerHealthBar.SetMaxHealth(PlayerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerTakeDamage(25);
        }
    }
    void PlayerTakeDamage(int damage)
    {
        PlayerCurrentHealth -= damage;
        PlayerHealthBar.SetHealth(PlayerCurrentHealth);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            

        }
    }
}    
