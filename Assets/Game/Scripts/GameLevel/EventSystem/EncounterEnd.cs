using UnityEngine;
using System.Collections;

public class EncounterEnd : MonoBehaviour
{
    [SerializeField] private BoxCollider2D normalCameraLimits;
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private GameObject encounterComponents;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SpencerTheme;
    [SerializeField] private AudioClip normalTheme;
    [SerializeField] private GameObject happyPlayer;
    [SerializeField] private GameObject scaredPlayer;
    [SerializeField] private GameObject happyFacesPlayer;
    [SerializeField] private GameObject scaredFacesPlayer;
    [SerializeField] private BoxCollider2D ownCollider;
    [SerializeField] private GameObject Signal1;
    [SerializeField] private GameObject Signal2;
    [SerializeField] private GameObject Spencer;
    [SerializeField] private GameObject Walls;

    private CameraT cameraScript;
    private bool encounterEnded;

    [SerializeField] private Cameramanager cameraManager;
    [SerializeField] private float focusDuration = 17.0f;

    private void Start()
    {
        cameraScript = cameraObject.GetComponent<CameraT>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (encounterEnded)
            return;

        encounterEnded = true;
        ownCollider.enabled = false;
        Walls.SetActive(true);

        EndEncounter();
    }

    private void EndEncounter()
    {
        encounterComponents.SetActive(false);

        scaredPlayer.SetActive(false);
        happyPlayer.SetActive(true);
        scaredFacesPlayer.SetActive(false);
        happyFacesPlayer.SetActive(true);

        audioSource.Stop();
        audioSource.clip = SpencerTheme;
        audioSource.Play();

        StartCoroutine(FocusOnTarget2());
    }

    private IEnumerator FocusOnTarget2()
    {
        Spencer.SetActive(true);
        cameraManager.CameraTarget(true);
        Signal1.SetActive(false);
        Signal2.SetActive(true);

        yield return new WaitForSeconds(focusDuration);

        Spencer.SetActive(false);
        cameraManager.CameraTarget(false);
        cameraScript.SetCameraBounds(normalCameraLimits);
        audioSource.Stop();
        audioSource.clip = normalTheme;
        audioSource.loop = true;
        audioSource.Play();
        Walls.SetActive(false);
    }
}