﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPartBodyHuman : MonoBehaviour{
	public OtherHumanScript script;
	public bool ignorePain = false;
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Home")){
        	if(ignorePain == false){
        		script.GetDamage();
        		ignorePain = true; 
        	}
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Home")){
    		ignorePain = false;
    	}
    }
}
