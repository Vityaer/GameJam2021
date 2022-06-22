using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorScript : MonoBehaviour{
	public int bonusArmor = 10;
	private bool isGame = true;
	private PlaySoundScript soundScript;
	
	void Start(){
		soundScript = GetComponent<PlaySoundScript>();
	}
    void OnTriggerEnter2D(Collider2D other){
			if(other.gameObject.CompareTag("Human")){
				if(!HumanHPControllerScript.Instance.IsShieldFull && isGame){
					isGame = false;
					soundScript.PlaySound();	
					HumanHPControllerScript.Instance.AddShield(bonusArmor);
					GetComponent<Dissolve>().StartDissolve();
				}
			}
		}
}
