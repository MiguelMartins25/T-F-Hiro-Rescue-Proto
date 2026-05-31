using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    [SerializeField] private string sceneChange;
    private bool escape;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        escape = Input.GetKey("escape");

        if (escape == true)
            SceneManager.LoadScene(sceneChange);
    }
}
