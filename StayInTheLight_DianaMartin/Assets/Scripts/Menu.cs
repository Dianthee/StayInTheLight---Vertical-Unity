using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	private void Start() {
		Cursor.lockState = CursorLockMode.None;
	}

	private void Update() {
		Cursor.lockState = CursorLockMode.None;

	}

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
