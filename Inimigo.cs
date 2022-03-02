using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {
	//Determina a velocidade da locomoção
	public float speed = 5f;
	public float mxDelay;
	private bool isLeft = true;
	public float timeMove = 0f;

	//Definimos o player para auxiliar a pegar o Animator
	public Transform enemy;

	void Start () {


	}

	// Update is called once per frame
	void Update () {
		moveEnemy ();
	}

	void moveEnemy(){
		timeMove += Time.deltaTime;


		if (timeMove <= mxDelay) {

			if (isLeft) {

				transform.Translate (Vector2.left * speed * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,0);

			} else {

				transform.Translate (Vector2.left * speed * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 180);

			}

		} else {
			isLeft = !isLeft;
			timeMove = 0;
		}
	}
		
}
