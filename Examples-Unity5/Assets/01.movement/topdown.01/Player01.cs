using UnityEngine;
using System.Collections;

public class Player01 : MonoBehaviour {

	public float velocity = 5f;

	private Rigidbody rigb;

	// Use Start para inicializações
	void Start () {
		// Obtem o componente de física
		rigb = GetComponent<Rigidbody>();
	}
	
	// Update é executado um vez por frame
	void Update () {
		// Recebe o movimento do keyboard/joypad
		Vector3 mov = Vector2.zero;
		mov.x = Input.GetAxis("Horizontal");
		mov.z = Input.GetAxis("Vertical");
		mov.Normalize();

		// Não use transform.position para mover... use rigidbody.velocity
		rigb.velocity = mov * velocity;

		// Teste de Movimento
		if (mov.magnitude >= 0.01f) {
			transform.LookAt(transform.position + mov);
		}
	}
}
