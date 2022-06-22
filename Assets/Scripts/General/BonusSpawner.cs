using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour{

	public Transform leftTopCorner, rightBottomCorner;
	public int count = 3;
	public GameObject bonus;
	void Start(){
		LevelControllerScript.Instance.Register(CreateArmor);
		CreateArmor();
	}
	public void CreateArmor(){
		Vector3 position = new Vector3();
		for(int i = 0; i < count; i++){
			position.x = Random.Range(leftTopCorner.position.x, rightBottomCorner.position.x);
			position.y = Random.Range(leftTopCorner.position.y, rightBottomCorner.position.y);
			Instantiate(bonus, position, transform.rotation);
		}
	}

}