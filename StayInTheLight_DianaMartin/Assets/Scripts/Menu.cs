using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void TutorialGame(){
	
		SceneManager.LoadScene (1);
	}

	public void NormalGame(){
	
		SceneManager.LoadScene (2);
	}

	
	public void Quit(){
	
		Application.Quit ();

	}

}
