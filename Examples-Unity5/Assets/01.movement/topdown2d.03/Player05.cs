using UnityEngine;
using System.Collections;

public class Player05 : MonoBehaviour {

	public float velocity = 5f;

	private Rigidbody2D rigb;
	private Animator anim;

	// Use this for initialization
	void Start () {
		// Obtains the physics component
		rigb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Receive keyboard/joypad movement
		Vector3 mov = Vector3.zero;
		mov.x = Input.GetAxis("Horizontal");
		mov.y = Input.GetAxis("Vertical");
		mov.Normalize();

		// Do not use transform.position to move ... use rigidbody.velocity
		rigb.velocity = mov * velocity;

		// Motion test
		anim.speed = mov.magnitude;
		if (mov.magnitude >= 0.01f) {
			float rot = Vector3.Angle(mov, Vector3.down);
			if (mov.x > 0f) rot = 360-rot;
			if (rot > 360f - 22.5f) rot = 0f;
			anim.SetFloat("rot", rot);
		}
	}
}
