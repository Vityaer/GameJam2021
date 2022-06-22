using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer;
public class GameOverMenu : MonoBehaviour{
	public Text textScore;
	public Canvas canvas;
	void Awake(){
		instance = this;
	}
	public void Open(){
		textScore.text = string.Concat("Score: ", ScoreScript.Instance.GetScore.ToString());
		canvas.enabled = true;
	}
	public void RestartLevel(){
        FadeInOut.Instance.EndScene("Level"); 
		RabbitSpawnerScript.Instance.Restart();
		HumanHPControllerScript.Instance.Restart();
		LevelControllerScript.Instance.Restart();
		PlayerScript.Instance.Restart();
		ScoreScript.Instance.Restart();
		canvas.enabled = false; 
	}
	public void ExitGame(){
        Application.Quit ();
    }
	private static GameOverMenu instance;
	public static GameOverMenu Instance{get => instance;}
}
