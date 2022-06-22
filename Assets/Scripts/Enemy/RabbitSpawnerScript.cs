using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;
public class RabbitSpawnerScript : MonoBehaviour{
	public GameObject rabbitPrefab;
	public List<Transform> rabbitHoles = new List<Transform>();
	[Header("Bonuses")]
	public float bonusRabbitSpeed = 0f;
	public void CreateRabbit(){
		GameObject rabbit = Instantiate(rabbitPrefab, rabbitHoles[Random.Range(0, rabbitHoles.Count)].position, transform.rotation);
		rabbit.GetComponent<EnemyMovementScript>().speed += bonusRabbitSpeed; 
	}
	void Awake(){
		instance = this;
	}
	void Start(){
		rabbitHoles.Clear();
		foreach(Transform child in transform){
			rabbitHoles.Add(child);
		}
		LevelControllerScript.Instance.Register(levelUP);
	}
	void levelUP(){
		bonusRabbitSpeed += 0.5f;
	}
	public void Restart(){
		bonusRabbitSpeed = 0f;
	}
	private static RabbitSpawnerScript instance;
	public static RabbitSpawnerScript Instance{get => instance;}
}