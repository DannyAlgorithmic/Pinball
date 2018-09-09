using UnityEngine;

public class PaddleScript : MonoBehaviour {

    public Rigidbody2D LeftPaddle, RightPaddle;
    public KeyCode LeftPaddleKey, RightPaddleKey;
    public bool IsAIControlled = false;

    [Range(0, 75)]
    public int MaxRotation = 53, ShotSpeed = 15, ReleaseSpeed = 15;
    [Range(0.0f, 0.25f)]
    public float MinReactionTime, MaxReactionTime;

    [HideInInspector]
    public bool leftActive = false, rightActive = false;


    private float LeftStart, RightStart;
    

    private void OnEnable()
    {
        LeftStart = LeftPaddle.rotation;
        RightStart = RightPaddle.rotation;
    }

    private void FixedUpdate()
    {
        // Top Paddles
        if (leftActive == true)
        { Flip(LeftPaddle, LeftStart + MaxRotation, ShotSpeed); }
        else
        { Flip(LeftPaddle, LeftStart, ReleaseSpeed); }

        if (rightActive == true)
        { Flip(RightPaddle, RightStart - MaxRotation, ShotSpeed); }
        else
        { Flip(RightPaddle, RightStart, ReleaseSpeed); }
    }

    private void Update()
    {
        if (IsAIControlled == false)
        {
            leftActive = Input.GetKey(LeftPaddleKey);
            rightActive = Input.GetKey(RightPaddleKey);
        }
    }

    private void Flip(Rigidbody2D _paddle, float _rot, float _speed)
    {
        if (Mathf.Approximately(_paddle.rotation, _rot) == false)
        {
            _paddle.MoveRotation(Mathf.MoveTowardsAngle(_paddle.rotation, _rot, _speed));
            // Debug.Log(4);
        }
    }

}
