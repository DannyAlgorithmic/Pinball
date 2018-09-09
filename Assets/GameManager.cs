using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PaddleScript LeftPaddleController, RightPaddleController;



    private void Awake()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
