using UnityEngine;

public class LostWagon : MonoBehaviour
{
    [SerializeField] private GameObject lostWagon;
    private bool hasObjective;
    [SerializeField] private GameObject Station;
    private LostWagonStation stationScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stationScript = Station.gameObject.GetComponent<LostWagonStation>();
    }

    // Update is called once per frame
    void Update()
    {

        if(hasObjective == true)
        {
            lostWagon.SetActive(true);
            stationScript.ObjectiveVerefy(true);
        }
        else
        {
            lostWagon.SetActive(false);
        }
    }

    public void OnObjectivePickUp(bool state)
    {
        hasObjective = state;
    }
}
