using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour{
	public Transform target;
	private Transform tr;
	private Transform rope;
	public int length = 1;
	void Awake(){
		tr = GetComponent<Transform>();
		rope = transform.Find("Rope").GetComponent<Transform>();
	}
	Vector2 dir = new Vector2();
	Vector3 scale = new Vector3(1f, 1.1f,1f);
    void Update(){
        if(target != null){
        	dir = target.position - tr.position;
        	rope.position = (target.position + tr.position) * 0.5f;
        	rope.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(dir.y/dir.x) * Mathf.Rad2Deg);
        	scale.x = dir.magnitude * length;
        	rope.localScale = scale;
        }
    }
}
