using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class SteamCheck : MonoBehaviour
{
	// The thing that plays the sound
	[SerializeField] private AudioSource puffingSource;

	// Updates every frame
	public void Update()
	{
		// Basically if moving, these are the inputs the game has (at least so far)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
		| Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			// Steam trigger
			GetComponent<ParticleSystem>().Play();

			// Puffing sound loop
			if(!puffingSource.isPlaying) // Avoids overlapping
			{
				puffingSource.Play();
			}
		}
		else // Stops everything
		{
			GetComponent<ParticleSystem>().Stop();
			puffingSource.Stop();
		}
	}
}
