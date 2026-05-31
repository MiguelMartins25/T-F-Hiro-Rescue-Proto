using Unity.VisualScripting;
using UnityEngine;

public class SpareParts : MonoBehaviour
{
    [SerializeField] private GameObject managerObject;
    private CollectableManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = managerObject.GetComponent<CollectableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        manager.IncreaseSpareParts();
        this.gameObject.SetActive(false);
    }
}
