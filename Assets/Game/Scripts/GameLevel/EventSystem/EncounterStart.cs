using UnityEngine;
using System.Collections;

public class EncounterStart : MonoBehaviour
{
    [SerializeField] private BoxCollider2D encounterCameraLimits;
    [SerializeField] private GameObject CameraObject;
    [SerializeField] private GameObject encounterComponents;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dangerTheme;
    [SerializeField] private AudioClip spencerWhistle;
    [SerializeField] private GameObject happyPlayer;
    [SerializeField] private GameObject scaredPlayer;
    [SerializeField] private GameObject happyFacesPlayer;
    [SerializeField] private GameObject scaredFacesPlayer;
    [SerializeField] private BoxCollider2D ownCollider;
    private CameraT cameraScript;
    private bool encounterActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraScript = CameraObject.GetComponent<CameraT>();
        encounterComponents.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (encounterActive)
            return;

        audioSource.Stop();
        encounterActive = true;
        ownCollider.enabled = false;

        StartEncounter();
    }

    private void StartEncounter()
    {
        cameraScript.SetCameraBounds(encounterCameraLimits);

        encounterComponents.SetActive(true);

        happyPlayer.SetActive(false);
        scaredPlayer.SetActive(true);
        happyFacesPlayer.SetActive(false);
        scaredFacesPlayer.SetActive(true);

        StartCoroutine(PlayEncounterAudio());
    }

    private IEnumerator PlayEncounterAudio()
    {
        audioSource.PlayOneShot(spencerWhistle);
        yield return new WaitForSeconds(spencerWhistle.length);

        audioSource.clip = dangerTheme;
        audioSource.loop = true;
        audioSource.Play();
    }
}

