using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private float endTime;
    public float       timePassed = 0.0f;
    private bool        endLevel = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Collision");
        endLevel = true;
    }

    void DeltatimePassed()
    {
        timePassed = timePassed + Time.deltaTime;
        Debug.Log(timePassed);
    }
}
