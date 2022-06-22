using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour{
	[SerializeField] private Text scoreText;
	[SerializeField] private int score = 0;
	public int GetScore{get => score;}
	void Start(){
		instance = this;
	}
	void UpdateUI(){
		scoreText.text = string.Concat("x", score.ToString());
	}
	public void AddPoint(int count = 1){
		score += count;
		UpdateUI();
	}
	public void Restart(){
		score = 0;
		UpdateUI();
	}
	private static ScoreScript instance;
	public static ScoreScript Instance{get => instance;}
}
