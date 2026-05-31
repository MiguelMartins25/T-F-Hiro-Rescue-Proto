using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndT : MonoBehaviour
{
    [SerializeField] private float endTime;
    [SerializeField] private string sceneChange;
    [SerializeField] private GameObject AudioSource;
    public AudioClip endTheme;
    private AudioSource audioPlayer;
    private float      timePassed = 0.0f;
    private bool       endLevel = false;
    private bool       themeIsPlaying = false;
   [SerializeField] private GameObject FaceSystem;
    private ThomasFacesSystem systemScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = AudioSource.GetComponent<AudioSource>();
        systemScript = FaceSystem.GetComponent<ThomasFacesSystem>();
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

            if(timePassed >= endTime - 2.0f)
                systemScript.LevelEndSmile(true);
        

            if(timePassed >= endTime)
            {
                SceneManager.LoadScene(sceneChange);
            }
        }
    }

    void OnTriggerEnter2D()
    {
        endLevel = true;
    }

    void DeltatimePassed()
    {
        timePassed = timePassed + Time.deltaTime;
    }

    void FixedUpdate()
    {
        
    }

    void EndTheme()
    {
        audioPlayer.PlayOneShot(endTheme);
    }
}
