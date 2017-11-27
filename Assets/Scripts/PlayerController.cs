using UnityEngine;

[System.Serializable]
public class Boundaries
{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    public float speed;
	public float tilt;
	public Boundaries boudndaries;


	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	private float nextFire;
	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			foreach (var shotSpawn in shotSpawns)
			{
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
			GetComponent<AudioSource>().Play();
		}
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		GetComponent<Rigidbody>().velocity=new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
		GetComponent<Rigidbody>().position = new Vector3(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boudndaries.xMin, boudndaries.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boudndaries.zMin, boudndaries.zMax)
		);
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
