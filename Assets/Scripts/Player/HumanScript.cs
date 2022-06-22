using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;
public class HumanScript : MonoBehaviour{
	[SerializeField] private HumanHPControllerScript playerHP;
	[SerializeField] private Rigidbody2D rb;
	
	void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	public void GetDamage(){
    	Vector2 speed = rb.velocity;
    	if(speed.magnitude > 2){
        	playerHP.GetDamage( (int)(speed.magnitude) );
    	}
	}
}
