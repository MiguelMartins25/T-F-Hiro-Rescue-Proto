using UnityEngine;

public class Whistle : MonoBehaviour
{
    private float cooldownTimer = 1.5f;
    [SerializeField] private float whistleCooldown = 1.5f;
    [SerializeField] private GameObject ScriptThatUsesWhistle1;
    [SerializeField] private GameObject ScriptThatUsesWhistle2;
    private bool space = false;
    private bool whistle = false;
    [SerializeField] private AudioClip whistleSound;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private GameObject FaceSystem;
    private ThomasFacesSystem systemScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        systemScript = FaceSystem.gameObject.GetComponent<ThomasFacesSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        space = Input.GetKeyDown("space");

        if (space == true)
        {
            if (cooldownTimer >= whistleCooldown)
            {
                whistle = true;
                cooldownTimer = 0.0f;
                animator.SetTrigger("Whistling");
                audioPlayer.PlayOneShot(whistleSound);
            }
        }
        else
        {
            whistle = false;
        }

        WhistleTracks controller = ScriptThatUsesWhistle1.GetComponent<WhistleTracks>();
        controller.ActiveWhistle(whistle);

        ObstacleParent controller2 = ScriptThatUsesWhistle2.GetComponent<ObstacleParent>();
        controller2.WhistleVerification(whistle);

        systemScript.IfWhistle(whistle);
    }

    void FixedUpdate()
    {

        if (cooldownTimer < whistleCooldown)
            cooldownTimer = cooldownTimer + Time.fixedDeltaTime;
    
    }

    
}
