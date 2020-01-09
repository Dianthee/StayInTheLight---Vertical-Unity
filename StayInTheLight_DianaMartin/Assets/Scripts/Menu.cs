using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void NewGame(){
	
		SceneManager.LoadScene (2);
	}

	 public void OpenURL()
      {
          //Application.OpenURL("https://twitter.com/weasel_games_st");
      }

	public void Quit(){
	
		Application.Quit ();

	}

}
