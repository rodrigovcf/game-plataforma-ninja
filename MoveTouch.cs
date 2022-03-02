using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouch : MonoBehaviour {

	//Referencias ao player
	public GameObject player;
	public Rigidbody2D playerRigidbody;
	public Animator animator;

	//Velocidade (andando)
	float speed = 0.5f;

	public int forceJump;

	bool jumped;

	public bool isGrounded;

	public Transform GroundCheck;

	public LayerMask whatIsGround;




	void Start () {
		
	}
	

	void Update () {
		//Identifica o chão
		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);

		//Seta a transição no animator que vai do jumpAndFall para o idlePlayer
		animator.SetBool ("inGround", isGrounded);

		/* Caso a condição seja verdadeira (chão e jumped = verdadeiro)
		 * setar a animação idlePlayer por meio do gatilho ground e 
		 * atribuindo false ao jumped
		 */
		if (isGrounded && jumped) {
			animator.SetTrigger ("ground");
			jumped = false;
		}

		/* Método responsável por passar o parâmetro do evento e 
		 * tomar a decisão quanto a locomoção e animaçãi do ninja
		 */
		move (CompartilhaAtributos.paramCompartilhado);
	}

	//Lembrando que os parâmetros atribuídos aos botões são 1, -1 e 0
	public void move(int param){
		//Move personagem para direita
		if (param > 0) {
			animator.SetFloat ("walk", 0.2f);
			player.transform.Translate (Vector2.right * speed * Time.deltaTime);
			player.transform.eulerAngles = new Vector2 (0, 0);		
		}
		//Move personagem para esquerda
		if (param < 0) {
			animator.SetFloat ("walk", 0.2f);
			player.transform.Translate (Vector2.right * speed * Time.deltaTime);
			player.transform.eulerAngles = new Vector2 (0, 180);
		}			
		//Parado desativa animação
		if (param == 0) {
			animator.SetFloat ("walk", 0.0f);
		}
	}

	/* 
	 * Método chamado no Pointer Down e Up dos botões
	 * Ele recebe 1, -1 ou 0 e atribui ao parâmetro 
	 * CompartilhaAtributos.paramCompartilhado (estático)
	 * Inicializa o parâmertro necessário para move(param)
	 */
	public void startMove(int param){
		CompartilhaAtributos.paramCompartilhado = param;
	}

	public void jump(){
		if (isGrounded) {
			playerRigidbody.AddForce (new Vector2 (0, forceJump));
			jumped = true;
		}
	}
}
