using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	
	void Start ()
	{
		rigidbody.velocity = new Vector3(0, 0, -1) * speed;
	}
}