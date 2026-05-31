using UnityEngine;

public class IntroTimer : MonoBehaviour
{
    [SerializeField] private float enableMainMenuOnTime;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private Animator Luso;
    [SerializeField] private Animator eightyth;
    private float timePassed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = timePassed + Time.deltaTime;
        if(timePassed >= enableMainMenuOnTime - 6.0f)
        {
            Luso.enabled = true;
        }
        if(timePassed >= enableMainMenuOnTime - 4.0f)
        {
            eightyth.enabled = true;
        }

        if(timePassed >= enableMainMenuOnTime)
        {
            MainMenu.SetActive(true);
        }
    }
}
