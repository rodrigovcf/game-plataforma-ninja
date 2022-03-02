using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public Transform player;
	public Animator animator;
	public Rigidbody2D playerRigidbody;
	private bool jumped;
	public bool isGrounded;
	public Transform GroundCheck;
	public LayerMask whatIsGround;
	public int force;
	public GameObject prefab;
	public Transform arma;
	public float forceTiro;

	void Start () {
		animator = player.GetComponent<Animator> ();
	}
	

	void Update () {
		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);

		animator.SetBool ("inGround", isGrounded);

		//print (playerRigidbody.velocity.y);

		animator.SetFloat ("velocitY", playerRigidbody.velocity.y);

		animator.SetFloat ("walk", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if (Input.GetAxis ("Horizontal") > 0) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);

			transform.eulerAngles = new Vector2 (0,0);

			if (forceTiro < 0) 
				forceTiro *= -1;
		}

		if (Input.GetAxis ("Horizontal") < 0) {
			transform.Translate (-Vector2.left * speed * Time.deltaTime);

			transform.eulerAngles = new Vector2 (0,180);


			if (forceTiro > 0) 
				forceTiro *= -1;
		}


		if (Input.GetButtonDown ("Jump") && isGrounded) {
			playerRigidbody.AddForce (new Vector2 (0, force));	
			animator.SetTrigger ("jump");
			jumped = true;
		}

		if (isGrounded && jumped) {
			animator.SetTrigger ("ground");
			jumped = false;
		}


		if (Input.GetButtonDown("Fire1")) { 
			atirar ();
		}



	}

	void atirar(){

		GameObject tempPrefab = Instantiate (prefab) as GameObject;

		tempPrefab.transform.position = arma.position;

		tempPrefab.GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceTiro, 0));

	}

	void OnCollisionEnter2D(Collision2D colisor){

		switch (colisor.gameObject.tag) {
		case "plataformaMovel":
			transform.parent = colisor.gameObject.transform;
		break;
		}
	}

	void OnCollisionExit2D(Collision2D colisor){
		switch (colisor.gameObject.tag) {
		case "plataformaMovel":
			transform.parent = null;
			break;
		}
	}
}
