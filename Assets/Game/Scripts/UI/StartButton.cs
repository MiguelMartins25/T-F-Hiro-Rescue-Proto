using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButton : MonoBehaviour
{
    [SerializeField] private string sceneChange;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hiroWhistle;
    [SerializeField] private AudioClip wheeshSound;
    [SerializeField] private Animator buttonsLeave;
    [SerializeField] private GameObject startLoading;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(hiroWhistle);
        audioSource.PlayOneShot(wheeshSound);

        buttonsLeave.enabled = true;

        yield return new WaitForSeconds(1f);

        startLoading.SetActive(true);

        yield return new WaitForSeconds(4f); // 1 + 4 = 5 seconds total

        SceneManager.LoadScene(sceneChange);
    }
}
