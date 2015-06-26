using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
	public float tumble;
	
	void Start ()
	{
		transform.rotation = Random.rotation;
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble; 

	}
}