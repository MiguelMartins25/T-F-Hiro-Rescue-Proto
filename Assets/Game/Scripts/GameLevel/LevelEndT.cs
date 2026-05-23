using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEndT : MonoBehaviour
{
    [SerializeField] private float endTime;
    [SerializeField] private string sceneChange;
    public AudioClip endTheme;
    private float      timePassed = 0.0f;
    private bool       endLevel = false;
    private bool       themeIsPlaying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endLevel == true)
        {
            DeltatimePassed();
            if (themeIsPlaying == false)
            {
                EndTheme();
                themeIsPlaying = true;
            }
        

            if(timePassed >= endTime)
            {
                SceneManager.LoadScene(sceneChange);
            }
        }
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Collision");
        endLevel = true;
    }

    void DeltatimePassed()
    {
        timePassed = timePassed + Time.deltaTime;
        Debug.Log(timePassed);
    }

    void FixedUpdate()
    {
        
    }

    void EndTheme()
    {
        SoundManager.PlaySound(endTheme);
    }
}
