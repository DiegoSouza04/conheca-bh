using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class responder : MonoBehaviour {

	private int idDesafio;

	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;
	public Text infoResposta;

	public string[] perguntas;		//armazena todas as perguntas
	public string[] alternativaA;	//armazena todas as alternativas A
	public string[] alternativaB;	//armazena todas as alternativas B
	public string[] alternativaC;	//armazena todas as alternativas C
	public string[] alternativaD;	//armazena todas as alternativas D

	public string[] corretas;		//armazena todas as alternativas corretas

	private int idPergunta;			//código da pergunta

	private float acertos;			//quantidade de acertos
	private float questoes;			//quantidade de questões
	private float media;			//media
	private int notaFinal;			//nota final


	void Start () {

		idDesafio = PlayerPrefs.GetInt ("idDesafio");

		//inicializar perguntas e respostas
		idPergunta = 0;
		questoes = perguntas.Length;
		pergunta.text = perguntas [idPergunta];
		respostaA.text = alternativaA [idPergunta];
		respostaB.text = alternativaB [idPergunta];
		respostaC.text = alternativaC [idPergunta];
		respostaD.text = alternativaD [idPergunta];

		//inicializar texto contador de perguntas
		infoResposta.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";
	}
	
	public void resposta(string alternativa){

		//Ganhando pontos com as alternativas
		if (alternativa == "A") {

			if (alternativaA [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		}
			
		else if (alternativa == "B") {
			
			if (alternativaB [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		}

		else if (alternativa == "C") {
			if (alternativaC [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		}

		else if (alternativa == "D") {
			if (alternativaD [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		}

		proximaPergunta ();
	}

	void proximaPergunta(){
		
		//incremento para trocar de pergunta
		idPergunta += 1;

		if (idPergunta <= (questoes - 1)) {

			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];

			//inicializar texto contador de perguntas
			infoResposta.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
		} else {


			media = 10 * (acertos / questoes);		//calcula a media com base no percentual de acerto
			notaFinal = Mathf.RoundToInt (media);	//arredonda a nota para o próximo inteiro, segundo a regra da matemática

			if (notaFinal > PlayerPrefs.GetInt ("notaFinal" + idDesafio.ToString ())) {

				PlayerPrefs.SetInt ("notaFinal" + idDesafio.ToString (), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idDesafio.ToString (), (int) acertos);
			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idDesafio.ToString (), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idDesafio.ToString (), (int) acertos);

			Application.LoadLevel("Nota");

		}
	}
}
