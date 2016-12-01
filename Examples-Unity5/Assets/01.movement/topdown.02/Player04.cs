using UnityEngine;
using System.Collections;

public class Player04 : MonoBehaviour {

	public float velocity = 5f;

	private Rigidbody rigb;

	// Use this for initialization
	void Start () {
		// Obtains the physics component
		rigb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// Receive keyboard/joypad movement
		Vector3 mov = Vector3.zero;
		mov.x = Input.GetAxis("Horizontal");
		mov.z = Input.GetAxis("Vertical");
		mov.Normalize();

		// Do not use transform.position to move... use rigidbody.velocity
		rigb.velocity = mov * velocity;

		// Motion test
		if (mov.magnitude >= 0.01f) {
			transform.LookAt(transform.position + mov);
		}
	}
}
