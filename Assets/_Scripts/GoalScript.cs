using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    public PlayerEnum Player;

    public Slider HealthSlider;
    public DamageScript BallDamageScript;
    public Canvas ResultsCanvas;
    public Text ResultsText;
    private Respawn BallRespawn;

    private void OnEnable()
    {
        BallRespawn = BallDamageScript.gameObject.GetComponent<Respawn>();
    }


    private void CheckForDeath(float health)
    {
        if (health <= 0)
        {
            ResultsCanvas.enabled = true;
            ResultsText.text = Player.ToString() + " WON THE MATCH!";
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallDamageScript.UpdateDamageText(HealthSlider);

            CheckForDeath(HealthSlider.value);

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
