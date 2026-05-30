using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    private bool gameWin = false;
    [SerializeField] private float gameTime = 0.0f;
    [SerializeField] private GameObject WinMessage;
    [SerializeField] private string MainMenu;
    [SerializeField] private GameObject LevelManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime >= 5.0f)
        {
            SceneManager.LoadScene(MainMenu);
        }

        if (gameWin == true)
        {
            WinMessage.SetActive(true);
            LevelManager.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (gameWin == true)
            gameTime = gameTime + Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D()
    {
        gameWin = true;
    }
}
