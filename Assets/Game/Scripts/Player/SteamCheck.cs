using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class SteamCheck : MonoBehaviour
{
    [SerializeField] private Movement movement;

	public void Update()
	{
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.A))
		{
			GetComponent<ParticleSystem>().Play();
		}
        else
        {
			GetComponent<ParticleSystem>().Stop();
        }
	}
}
