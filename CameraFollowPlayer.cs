using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
	
	public GameObject target = null;
	private Vector3 positionOffset = Vector3.zero;
	
	private void Start() 
	{
		positionOffset = transform.position - target.transform.position;
		//Debug.Log ("offset=" + positionOffset);
	}
	
	
	
	// Update is called once per frame
	private void Update () 
	{
		if (target != null) 
		{
			transform.position = target.transform.position + positionOffset;
			transform.LookAt (target.transform.position);
		}
	}
}
