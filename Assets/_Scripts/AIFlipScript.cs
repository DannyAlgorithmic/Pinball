using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlipScript : MonoBehaviour {

    public PaddleScript PaddleController;
    public PaddleEnum PaddleEnum;

    private Collider2D col;

    private void OnEnable()
    {
        col = GetComponent<BoxCollider2D>();
        if (PaddleController.IsAIControlled == false)
        {
            col.enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && PaddleController.IsAIControlled == true)
        {
            StopCoroutine("FlipTimer");
            StartCoroutine("FlipTimer", new FlipData(Random.Range(PaddleController.MinReactionTime, PaddleController.MaxReactionTime), true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && PaddleController.IsAIControlled == true)
        {
            StopCoroutine("FlipTimer");
            StartCoroutine("FlipTimer", new FlipData(Random.Range(PaddleController.MinReactionTime - 0.015f, PaddleController.MaxReactionTime - 0.01f), false));
        }
    }

    public IEnumerator FlipTimer(FlipData flipData)
    {
        yield return new WaitForSecondsRealtime(flipData.ReactionTime);
        if (PaddleEnum == PaddleEnum.LEFT_PADDLE)
        {
            PaddleController.leftActive = flipData.IsFlipped;
        }
        else
        {
            PaddleController.rightActive = flipData.IsFlipped;
        }
    }
}
