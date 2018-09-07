using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    [Range(1, 100)]
    public int MaxDamage, BaseDamage, IncreasedDamage, MaxBounceCount;
    [HideInInspector]
    public int damage;
    public Text DamageText1, DamageText2;
    private int bounceCount, bounceDamageModifier;


	// Use this for initialization
	void Start () {
        damage = BaseDamage;
        DamageText1.text = BaseDamage.ToString();
        DamageText2.text = BaseDamage.ToString();
    }
	
    private void ManageBounces()
    {
        bounceCount++;

        // Debug.Log("Bounce Count: " + bounceCount);

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
        UpdateDamageUI();
        // Debug.Log("Damage: " + damage);
    }

    public void UpdateDamageUI()
    {
        DamageText1.text = damage.ToString();
        DamageText2.text = damage.ToString();
    }

    public void ResetModifiers(){
        damage = BaseDamage;
        bounceDamageModifier = 0;
        bounceCount = 0;
    }

    public void TakeDamage(Slider _slider)
    {
        _slider.value -= damage;
        // Debug.Log("Took " + damage + "pts of damage!");
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

}
