using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
	
	//Target/Alvo -> Alvo a ser seguido (personagem)
	public Transform player;

	//Somooth/Suave -> Suavisar no ato da translação
	private float smooth = 0.5f;

	//Velocidade que atua no eixo x e no eixo y 
	private Vector2 speed;

	//Inicializa o Vector2.zero => Vector2(0,0)
	//private Vector2 newPosition2DCam = Vector2.zero; 
	private Vector2 newPosition2DCam;

	void Start () {
	
		speed = new Vector2 (0.5f, 05f);
	}

	void Update () {
	
		/* Recebendo uma posição da Câmera no eixo x
		 * O Mathf.SmoothDamp Aos poucos, muda um valor para um objetivo desejado ao longo do tempo. O valor 
		 * é suavizada por alguma mola-amortecedor como função, que nunca vai ultrapassar. A função pode ser
		 * usada para suavizar qualquer tipo de valor, as posições, cores escalares. 
		 * Parâmetros - Posição atual (da Câmera), Posição do alvo (Personagem), Velocidade atual (modificado 
		 * a cada chamada), Tempo aproximado que levará para atingir a meta (valor menor atinge o alvo mais rápido). */
		newPosition2DCam.x = Mathf.SmoothDamp (transform.position.x, player.position.x, ref speed.x, smooth);



		/* Recebendo uma posição da Câmera no eixo y
		 * O Mathf.SmoothDamp Aos poucos, muda um valor para um objetivo desejado ao longo do tempo. O valor 
		 * é suavizada por alguma mola-amortecedor como função, que nunca vai ultrapassar. A função pode ser
		 * usada para suavizar qualquer tipo de valor, as posições, cores escalares. 
		 * Parâmetros - Posição atual (da Câmera), Posição do alvo (Personagem), Velocidade atual (modificado 
		 * a cada chamada), Tempo aproximado que levará para atingir a meta (valor menor atinge o alvo mais rápido). 
		 * Repare o eixo y - Estamos aumentando a altura da câmera*/
		newPosition2DCam.y = Mathf.SmoothDamp (transform.position.y, player.position.y +1.1f, ref speed.y, smooth);

		//Câmera possui os 3 eixos / Se faz necessário para evitar da câmera ficar atrás do cenário (profundidade)
		Vector3 newPositionCam = new Vector3 (newPosition2DCam.x, newPosition2DCam.y, transform.position.z);

		/* Interpola esfericamente dois vetores (linha curva). Interpola entre os v1 e v2 com base no tempo contado t. 
		 * Os vectores são tratados como direções. A direção do vector devolvido é interpolado pelo ângulo e a sua
		 * magnitude é interpolada entre as grandezas de from (origem) e to (alvo)*/ 
		transform.position = Vector3.Slerp (transform.position, newPositionCam, Time.time);

	}
}
