using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelpFuction;
namespace Platformer{
	public class OtherDogScript : EnemyControllerScript{
		private TimerScript Timer;
		public Dissolve dissolve;
		void Start(){
			base.Start();
			Timer = HelpFuction.TimerScript.Timer;

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
						Debug.Log("play");
						isGame = false;
							GetComponent<RabbitMovementScript>().enabled = true;
							moveScript = GetComponent<RabbitMovementScript>();
							pathFinderTimer.Register(Safe);
					}
				}
		}
	}
}