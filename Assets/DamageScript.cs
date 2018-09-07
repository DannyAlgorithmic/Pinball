using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    [Range(1, 100)]
    public int MaxDamage, BaseDamage, IncreasedDamage, MaxBounceCount;
    private int damage;
    private int bounceCount, bounceDamageModifier;

	// Use this for initialization
	void Start () {
        damage = BaseDamage;
	}
	

    private void ManageBounces()
    {
        bounceCount++;

        Debug.Log("Bounce Count: " + bounceCount);

        if (bounceCount >= MaxBounceCount)
        {
            bounceCount = 0;
            bounceDamageModifier++;
            IncreaseDamage();
        }
    }

    private void IncreaseDamage()
    {
        damage = IncreasedDamage * bounceDamageModifier;
        damage = Mathf.Clamp(damage, BaseDamage, MaxDamage);
        Debug.Log("Damage: " + damage);
    }

    private void ResetModifiers(){
        damage = BaseDamage;
        bounceDamageModifier = 0;
        bounceCount = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damage != MaxDamage)
        {
            if (collision.gameObject.CompareTag("Bumper"))
            {
                ManageBounces();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawner"))
        {
            ResetModifiers();
        }
    }

}
