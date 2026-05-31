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
    [SerializeField] private GameObject EndFade;
    [SerializeField] private GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioPlayer = AudioSource.GetComponent<AudioSource>();
        systemScript = FaceSystem.GetComponent<ThomasFacesSystem>();
        EndFade.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(endLevel == true)
        {
            EndFade.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
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
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(endTheme);
    }
}
