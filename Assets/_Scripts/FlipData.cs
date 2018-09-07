using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipData
{
    public float ReactionTime = 0.5f;
    public bool IsFlipped = false;

    public FlipData(float t, bool flipped)
    {
        ReactionTime = t;
        IsFlipped = flipped;
    }
}
