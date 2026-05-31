using UnityEngine;

public class IntroTimer : MonoBehaviour
{
    [SerializeField] private float enableMainMenuOnTime;
    [SerializeField] private GameObject MainMenu;
    private float timePassed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = timePassed + Time.deltaTime;
        if(timePassed >= enableMainMenuOnTime)
        {
            MainMenu.SetActive(true);
        }
    }
}
