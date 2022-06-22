using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelpFuction;
namespace Platformer{
	public class RabbitScript : EnemyControllerScript{
		private TimerScript Timer;
		public Dissolve dissolve;
		void Start(){
			base.Start();
			Timer = HelpFuction.TimerScript.Timer;
			moveScript = GetComponent<RabbitMovementScript>();
			pathFinderTimer.Register(Safe);
		}
		public float timeForGoHome = 12f;
		private RabbitMovementScript moveScript;
		
		public override void Death(){
			pathFinderTimer?.UnRegister(PlayerChangePosition);
			pathFinderTimer.UnRegister(Safe);
			RabbitSpawnerScript.Instance.CreateRabbit();	
			dissolve.StartDissolve();
		}
		public override void WayDone(){
			if(movementScript.player == null){
				ChangeBehaviour(CurrentBehaviour.Safe);
			}
		} 
		bool isGame = true;
		void OnTriggerEnter2D(Collider2D other) {
			if(other.gameObject.CompareTag("Player")){
					if(isGame){
						isGame = false;
						ScoreScript.Instance.AddPoint(1);
						moveScript.Death();
						Death();
					}
				}
		}
	}
}
