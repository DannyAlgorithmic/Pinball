using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public Rigidbody2D TopLeft, TopRight, BottomLeft, BottomRight;
    [Range(0, 100)]
    public float FlipSpeed, ReturnSpeed, MaxRotation;

    private float TopLeftStartRot, TopRightStartRot, BottomLeftStartRot, BottomRightStartRot;
    public bool IsPlayerOne;

    [HideInInspector]
    public bool TopLeftActive = false, TopRightActive = false, BottomLeftActive = false, BottomRightActive = false;

    private void OnEnable()
    {
        TopLeftStartRot = TopLeft.rotation;
        TopRightStartRot = TopRight.rotation;
        BottomLeftStartRot = BottomLeft.rotation;
        BottomRightStartRot = BottomRight.rotation;
    }

    private void FixedUpdate()
    {
        // Bottom Paddles
        if (BottomLeftActive == true)
        {
            Flip(BottomLeft, BottomLeftStartRot + MaxRotation, 20);
        }
        else
        {
            Flip(BottomLeft, BottomLeftStartRot, 20);
        }

        if (BottomRightActive == true)
        {
            Flip(BottomRight, BottomRightStartRot - MaxRotation, 15);
        }
        else
        {
            Flip(BottomRight, BottomRightStartRot, 15);
        }

        // Top Paddles
        if (TopLeftActive == true)
        {
            Flip(TopLeft, TopLeftStartRot - MaxRotation, 20);
        }
        else
        {
            Flip(TopLeft, TopLeftStartRot, 15);
        }

        if (TopRightActive == true)
        {
            Flip(TopRight, TopRightStartRot + MaxRotation, 15);
        }
        else
        {
            Flip(TopRight, TopRightStartRot, 15);
        }

    }

    private void Update()
    {
        // BottomLeftActive = Input.GetKey(KeyCode.A);
        // BottomRightActive = Input.GetKey(KeyCode.D);
        // TopLeftActive = Input.GetKey(KeyCode.RightArrow);
        // TopRightActive = Input.GetKey(KeyCode.LeftArrow);
    }


    private void Flip(Rigidbody2D _paddle, float _rot, float _speed)
    {
        if ( Mathf.Approximately(_paddle.rotation, _rot) == false)
        {
            _paddle.MoveRotation(Mathf.MoveTowardsAngle(_paddle.rotation, _rot, _speed));
            // Debug.Log(4);
        }
    }
}
