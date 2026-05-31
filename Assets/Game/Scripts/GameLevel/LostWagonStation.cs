using UnityEngine;

public class LostWagonStation : MonoBehaviour
{
    private bool hasObjective = false;
    [SerializeField] private GameObject player;
    private LostWagon wagonScript;
    private GameObject ObjSign;
    private GameObject CompSign;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wagonScript = player.gameObject.GetComponent<LostWagon>();
        ObjSign = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        CompSign = gameObject.transform.GetChild(0).GetChild(1).gameObject;

        ObjSign.SetActive(true);
        CompSign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectiveVerefy(bool verefy)
    {
        hasObjective = verefy;
    }

    void OnTriggerEnter2D()
    {
        if (hasObjective == true)
        {
            ObjSign.SetActive(false);
            CompSign.SetActive(true);
            wagonScript.OnObjectivePickUp(false);
        }
    }
}
