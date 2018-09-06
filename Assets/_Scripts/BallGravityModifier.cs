using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravityModifier : MonoBehaviour {

    [Range(0f, 4f)]
    public float GravityModifierAmount = 1.0f;

    Rigidbody2D body;

    float startGravity;
    private bool PlayerOneSide = true;

    private void OnEnable()
    {
        body = GetComponent<Rigidbody2D>();

        startGravity = body.gravityScale;
    }

    private void FixedUpdate()
    {
        PlayerOneSide = body.position.y <= 0;
        GravityModifier();
        CheckForGravitySwitch();
    }

    private void GravityModifier(){
        if(PlayerOneSide == true){
            if(body.velocity.y < 0.0f)
                body.velocity += Vector2.up * Physics2D.gravity.y * (GravityModifierAmount - 1.0f) * Time.fixedDeltaTime;
        }else{
            if(body.velocity.y > 0.0f)
                body.velocity += Vector2.down * Physics2D.gravity.y * (GravityModifierAmount - 1.0f) * Time.fixedDeltaTime;
        }
    }



    private void CheckForGravitySwitch(){
        if (PlayerOneSide)
        {
            if (Mathf.Approximately(body.gravityScale, startGravity) == false)
            { GravitySwitch( startGravity ); }
        }
        else
        {
            if (Mathf.Approximately(body.gravityScale, -startGravity) == false)
            { GravitySwitch( -startGravity ); }
        }
    }

    public void GravitySwitch(float _g)
    { body.gravityScale = _g; }
}
