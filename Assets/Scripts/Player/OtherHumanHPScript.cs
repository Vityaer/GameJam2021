using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherHumanHPScript : MonoBehaviour{
	private int HP = 100;
	public bool IsHPFull{get => (HP == 100);}
	public  int startHP = 100;
	private int shield = 0;
	public bool IsShieldFull{get => (shield == 100);}
	public  int startShiled = 0;
	public GameObject prefabBlood;
//API 		
	public void GetDamage(int damage){
		if(shield >= damage){
			shield -= damage;
			damage = 0;
		}else{
			damage -= shield;
			shield = 0;
		}
		HP = (HP > damage) ? HP - damage : 0;
		if(damage > 0) Destroy(Instantiate(prefabBlood, transform.position, transform.rotation), 0.5f);
		soundScript.PlaySound();	
	}
	public void AddHP(int bonus){
		HP     = (  (HP + bonus)   < 100) ? HP + bonus : 100;
	}
	public void AddShield(int bonus){
		shield = ((shield + bonus) < 100) ? shield + bonus : 100;
	}

	private PlaySoundScript soundScript;
	void Start(){
		soundScript = GetComponent<PlaySoundScript>();
	}
	
}	
