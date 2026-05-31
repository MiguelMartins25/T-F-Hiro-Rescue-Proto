using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private int sparePartsAmount = 0;
    [SerializeField] private GameObject SPUIcounter;
    private SparePartsUI script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        script = SPUIcounter.GetComponent<SparePartsUI>();
    }

    // Update is called once per frame
    void Update()
    {
        script.UpdateSPAmount(sparePartsAmount);
    }

    public void IncreaseSpareParts()
    {
        sparePartsAmount += 1;
    }
}
