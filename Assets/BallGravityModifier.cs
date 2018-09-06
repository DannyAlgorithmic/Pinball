using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravityModifier : MonoBehaviour {

    Rigidbody2D body;

    float startGravity;

    private void OnEnable()
    {
        body = GetComponent<Rigidbody2D>();

        startGravity = body.gravityScale;
    }

    private void FixedUpdate()
    {
        if (body.position.y <= 0)
        {
            if (Mathf.Approximately(body.gravityScale, startGravity) == false)
            {
                body.gravityScale = startGravity;
                Debug.Log("Reset Gravity To: " + body.gravityScale);
            }
        }else
        {
            if (Mathf.Approximately(body.gravityScale, -startGravity) == false)
            {
                body.gravityScale = -startGravity;
                Debug.Log("Switched Gravity To: " + body.gravityScale);
            }
        }
    }

    private void GravitySwitch(float _g)
    {
        body.gravityScale = _g;
    }
}
