using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupActivator : MonoBehaviour {

    public PickupGatherer PickupGatherer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            PickupGatherer.UpdateSubs();
        }
    }
}
