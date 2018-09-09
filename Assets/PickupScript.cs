using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : Subscriber
{
    public override void UpdateSelf()
    {
        gameObject.SetActive(false);
    }
}
