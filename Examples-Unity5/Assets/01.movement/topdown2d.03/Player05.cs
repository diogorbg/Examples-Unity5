using UnityEngine;
using System.Collections;

public class Player05 : MonoBehaviour {

	public float velocity = 5f;

	private Rigidbody2D rigb;
	private Animator anim;

	// Use Start para inicializações
	void Start () {
		// Obtem o componente de física
		rigb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update é executado um vez por frame
	void Update () {
		// Recebe o movimento do keyboard/joypad
		Vector3 mov = Vector3.zero;
		mov.x = Input.GetAxis("Horizontal");
		mov.y = Input.GetAxis("Vertical");
		mov.Normalize();

		// Não use transform.position para mover... use rigidbody.velocity
		rigb.velocity = mov * velocity;

		// Teste de Movimento
		anim.speed = mov.magnitude;
		if (mov.magnitude >= 0.01f) {
			float rot = Vector3.Angle(mov, Vector3.down);
			if (mov.x > 0f) rot = 360-rot;
			if (rot > 360f - 22.5f) rot = 0f;
			anim.SetFloat("rot", rot);
		}
	}
}
