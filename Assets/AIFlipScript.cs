using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlipScript : MonoBehaviour {

    public PaddleController PaddleController;
    public bool IsAIControlled = false;
    public PaddleEnum PaddleEnum;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && IsAIControlled == true)
        {
            StopCoroutine("FlipTimer");
            StartCoroutine("FlipTimer", new FlipData(Random.Range(0.035f, 0.055f), true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && IsAIControlled == true)
        {
            StopCoroutine("FlipTimer");
            StartCoroutine("FlipTimer", new FlipData(Random.Range(0.025f, 0.045f), false));
        }
    }

    public IEnumerator FlipTimer(FlipData flipData)
    {
        yield return new WaitForSecondsRealtime(flipData.ReactionTime);
        switch (PaddleEnum)
        {
            case PaddleEnum.TOP_LEFT:
                PaddleController.TopLeftActive = flipData.IsFlipped;
                break;
            case PaddleEnum.TOP_RIGHT:
                PaddleController.TopRightActive = flipData.IsFlipped;
                break;
            case PaddleEnum.BOTTOM_LEFT:
                PaddleController.BottomLeftActive = flipData.IsFlipped;
                break;
            case PaddleEnum.BOTTOM_RIGHT:
                PaddleController.BottomRightActive = flipData.IsFlipped;
                break;
        }
    }
}
