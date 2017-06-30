using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//compomentes de UI para o sistema

public class desafioJogo : MonoBehaviour {


	public Button 		btnPlayQuiz;
	public Text 		txtNomeDesafio;

	public GameObject 	infoResultado;
	public Text 		txtInfoResultado;

	public GameObject	estrela1;
	public GameObject	estrela2;
	public GameObject	estrela3;

	public string[] 	nomeDesafio;
	public int 			numeroQuestoes;

	private int 		idDesafio;



	// Use this for initialization
	void Start () {
		idDesafio = 0;
		txtNomeDesafio.text = nomeDesafio[idDesafio];

		//texto do resultado
		txtInfoResultado.text = "Você acertou X de X questões";
		infoResultado.SetActive (false);
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		btnPlayQuiz.interactable = false;
	}

	public void selecioneDesafio (int indice) {

		idDesafio = indice;
		PlayerPrefs.SetInt ("idDesafio", idDesafio);
		txtNomeDesafio.text = nomeDesafio [idDesafio];
			
		int notaFinal = PlayerPrefs.GetInt ("notaFinal" + idDesafio.ToString ());
		int acertos = PlayerPrefs.GetInt ("acertos" + idDesafio.ToString ());

		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);

		if (notaFinal == 10) {

			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);
		} else if (notaFinal >= 7) {

			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);
		} else if (notaFinal >= 5) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);
		}
		
		txtInfoResultado.text = "Você acertou " + acertos.ToString () + " de 5 questões!";
		infoResultado.SetActive (true);
		btnPlayQuiz.interactable = true;
	}

	//carregar desafios
	public void jogar(){
		
		Application.LoadLevel ("D" + idDesafio.ToString());

	}
}
