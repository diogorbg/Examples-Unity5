using UnityEngine;
using System.Collections;

namespace topdown2d_01 {

public class Player : MonoBehaviour {

	public float velocity = 5f;

	private Rigidbody2D rigb;

	// Use Start para inicializações
	void Start () {
		// Obtem o componente de física
		rigb = GetComponent<Rigidbody2D>();
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
		if (mov.magnitude >= 0.01f) {
			transform.LookAt(transform.position + mov, Vector3.back);
		}
	}
}

}
