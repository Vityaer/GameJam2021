using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelpFuction;
using Platformer;
public class LevelControllerScript : MonoBehaviour{
    private TimerScript Timer;
	[SerializeField] private float timeForUpLevel = 12f;
	private GameTimer timerLevelUp;
	public HumanHPControllerScript HumanHP;
	void Awake(){
    	instance = this;
	}
    void Start(){
    	Timer    = HelpFuction.TimerScript.Timer;
		timerLevelUp = Timer.StartTimer(timeForUpLevel, UpLevel);  
    	HumanHP.RegisterOnDeath(StopLevel);
    }
    private void UpLevel(){

		timerLevelUp = Timer.StartTimer(timeForUpLevel, UpLevel);   
    }
    public void StopLevel(){
    	PlayerScript.Instance.enabled = false;
    	GameOverMenu.Instance.Open();
    	Timer.StopTimer(timerLevelUp);
    }
    void OnDestroy(){
    	Timer.StopTimer(timerLevelUp);
    }
    public delegate void Del();
    private Del dels;
    public void Register(Del d){
		dels += d;
	}
	public void UnRegister(Del d){
		dels -= d;
	}
	private void OnLevelUp(){
		if(dels != null)
			dels();
	}
	public void Restart(){
		timerLevelUp = Timer.StartTimer(timeForUpLevel, UpLevel);  
	}
	private static LevelControllerScript instance;
	public static LevelControllerScript Instance{get => instance;}
}
