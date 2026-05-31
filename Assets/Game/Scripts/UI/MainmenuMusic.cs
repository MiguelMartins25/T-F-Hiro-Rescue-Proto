using System;
using UnityEngine;

public class MainmenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip IntroTheme;
    [SerializeField] private AudioClip MenuTheme;
    [SerializeField] private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(MenuTheme);
        }
    }
}
