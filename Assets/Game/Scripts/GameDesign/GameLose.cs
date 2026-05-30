using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLose : MonoBehaviour
{
    private bool gameOver = false;
    [SerializeField] private float gameOverTimer;
    [SerializeField] private float gameTime = 0.0f;
    [SerializeField] private GameObject LoseMessage;
    [SerializeField] private string MainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoseMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime >= gameOverTimer)
        {
            gameOver = true;
        }

        if (gameTime >= gameOverTimer + 5.0f)
        {
            SceneManager.LoadScene(MainMenu);
        }

        if (gameOver == true)
        {
            LoseMessage.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        gameTime = gameTime + Time.fixedDeltaTime;
    }
}
