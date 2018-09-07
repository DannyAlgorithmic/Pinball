using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour {

    [Range(5, 100)]
    public int Healing = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Healed by: " + Healing);
            gameObject.SetActive(false);
        }
    }
}
