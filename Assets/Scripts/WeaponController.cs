using UnityEngine;

public class WeaponController : MonoBehaviour
{

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRateMax;
	public float fireRateMin;
	public float delay;
	private AudioSource audioSource;
	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("Fire", delay, Random.Range(fireRateMin, fireRateMax));
	}
	
	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play();
	}
}
