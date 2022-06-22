using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControllerScript : MonoBehaviour{

	public void StartGame(){
	    FadeInOut.Instance.EndScene("Level"); 
	}
	public void ExitGame(){
        Application.Quit ();
    }
}
