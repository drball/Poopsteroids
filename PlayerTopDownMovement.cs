using UnityEngine;
using System.Collections;

public class PlayerTopDownMovement : MonoBehaviour {
	
	
	private float speed = 4;
	
	public GameObject shot;
	
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	void Start()
	{
		nextFire = Time.time + fireRate + 1;
	}
	
	
	void Update()
	{
		//Debug.Log ("nextfire = "+nextFire);

		if (/*Input.GetButton("Fire1") &&*/ Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Rigidbody clone;
			clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
		}
		
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = 1; //Input.GetAxis("Vertical");
		
		
		Vector3 a = transform.eulerAngles;
		
		if(horizontalInput > 0.1)
			transform.eulerAngles = new Vector3(a.x, a.y + (speed * Time.deltaTime * 30), a.z);
	

		else if(horizontalInput < 0)
			transform.eulerAngles = new Vector3(a.x, a.y - (speed * Time.deltaTime * 30), a.z);
	

			
			Vector3 moveDirection = new Vector3(0,0,verticalInput*speed);
		
		if(verticalInput > 0.1)
			rigidbody.AddRelativeForce(moveDirection,ForceMode.Acceleration);
		
	}

	void FixedUpdate()
	{


	}
}
