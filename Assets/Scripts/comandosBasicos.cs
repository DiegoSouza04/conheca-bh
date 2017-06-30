using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comandosBasicos : MonoBehaviour {


	public void carregarCena(string nomeCena){
		Application.LoadLevel (nomeCena);

	}

	public void resetarPontuacoes(){
		PlayerPrefs.DeleteAll ();
	}
}
