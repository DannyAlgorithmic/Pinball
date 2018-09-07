using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    public Slider HealthSlider;
    public DamageScript BallDamageScript;
    private Respawn BallRespawn;

    private void OnEnable()
    {
        BallRespawn = BallDamageScript.gameObject.GetComponent<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallDamageScript.TakeDamage(HealthSlider);
            BallDamageScript.ResetModifiers();
            BallDamageScript.UpdateDamageUI();

            BallRespawn.OnGoalEnter();
        }
    }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                BallRespawn.OnGoalExit();
            }
        }

    }
