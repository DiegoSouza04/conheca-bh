using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour {


	public void carregarCena(string nomeCena){
        SceneManager.LoadScene (nomeCena);
    }

	public void resetarPontuacoes(){
		PlayerPrefs.DeleteAll ();
	}
}
