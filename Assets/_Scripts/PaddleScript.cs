using UnityEngine;

public class PaddleScript : MonoBehaviour {

    public Camera cam;
    public Rigidbody2D LeftPaddle, RightPaddle;
    public KeyCode LeftPaddleKey, RightPaddleKey;
    public bool IsAIControlled = false, isTouchControlled = false;

    [Range(0, 75)]
    public int MaxRotation = 53, ShotSpeed = 15, ReleaseSpeed = 15;
    [Range(0.0f, 0.25f)]
    public float MinReactionTime, MaxReactionTime;

    [HideInInspector]
    public bool leftActive = false, rightActive = false;


    private float LeftStart, RightStart;

    
    enum ScreenTapSide { LEFT, RIGHT }
    int screenWidth = 0;
    

    private void OnEnable()
    {
        LeftStart = LeftPaddle.rotation;
        RightStart = RightPaddle.rotation;

        screenWidth = Screen.width;
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
            if (isTouchControlled == false)
            {
                KeyboardControls();
            }
            else
            {
                TouchControls();
            }
        }
    }


    private void KeyboardControls()
    {
        leftActive = Input.GetKey(LeftPaddleKey);
        rightActive = Input.GetKey(RightPaddleKey);
    }

    private void MouseTestControls()
    {
        bool isPressed = Input.GetMouseButton(0);
        ScreenTapSide tapSide = CheckTapSide(Input.mousePosition);
        if (isPressed)
        {
            
            if (tapSide == ScreenTapSide.LEFT)
            {
                leftActive = true;
            }
            else
            {
                leftActive = false;
            }

            if (tapSide == ScreenTapSide.RIGHT)
            {
                rightActive = true;
            }
            else
            {
                rightActive = false;
            }
        }
    }

    private void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {

                if (touch.fingerId == 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                    {
                        TapPaddles(touch.position, true);
                        // Debug.Log("First finger entered!");
                    }

                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        TapPaddles(touch.position, false);
                        // Debug.Log("First finger left.");
                    }
                }

                if (touch.fingerId == 1)
                {
                    if (Input.GetTouch(1).phase == TouchPhase.Stationary)
                    {
                        TapPaddles(touch.position, true);
                        // Debug.Log("Second finger entered!");
                    }

                    if (Input.GetTouch(1).phase == TouchPhase.Ended)
                    {
                        TapPaddles(touch.position, false);
                        // Debug.Log("Second finger left.");
                    }
                }
            }
        }
        else
        {
            if (leftActive == true)
            {
                leftActive = false;
            }
            if (rightActive == true)
            {
                rightActive = false;
            }
        }
    }


    private void TapPaddles(Vector2 _pos, bool _paddleState)
    {
        ScreenTapSide tapSide = CheckTapSide(_pos);
        if (tapSide == ScreenTapSide.LEFT)
        {
            leftActive = _paddleState;
        }

        if(tapSide == ScreenTapSide.RIGHT)
        {
            rightActive = _paddleState;
        }
    }

    private ScreenTapSide CheckTapSide(Vector2 _pos)
    {
        ScreenTapSide tapSide = (_pos.x <= (screenWidth / 2)) ? ScreenTapSide.LEFT : ScreenTapSide.RIGHT;
        return tapSide;
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
