using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelpFuction;
namespace Platformer{
	public class EnemyGunScript : MonoBehaviour{
		public Transform target;
		public AudioClip noiseShot;
        protected AudioSource audio;
		protected Transform tr;
		private TimerScript Timer;
		void Awake(){
			tr = GetComponent<Transform>();
		}
	
	    protected Vector3 dir;
	    private float tiltAroundZ;
	    private float atan;
	    protected Transform rayPoint;
		protected PoolBulletScript poolBullet;

	    public delegate void Del();
		public Del dels;
		public void Register(Del d, float radiusAttack){
			dels += d;
			this.radiusAttack = Mathf.Pow(radiusAttack, 2);
		}
		public void UnRegister(Del d){
			dels -= d;
		}
		private void RayCastOnPlayer(){
			if(dels != null)
				dels();	
		}
		[SerializeField] protected float radiusAttack;
	    void Start(){
	    	poolBullet = PoolBulletScript.Instance;
			Timer      = HelpFuction.TimerScript.Timer;
            audio      = GetComponent<AudioSource>();
	    	rayPoint   = transform.Find("Fire").GetComponent<Transform>();
	    	target     = GameObject.Find("Player").transform;
	    	Timer.StartTimer(0.5f, DropRayFindPlayer);
	    }
	    public void DropRayFindPlayer(){
	    	if(target && (tr != null)){
				dir = target.position - tr.position;
		        tr.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(dir.y/dir.x) * Mathf.Rad2Deg);
		        if(dir.sqrMagnitude < radiusAttack * 2){
	            	RayCastOnPlayer();
            	}
			}
        	Timer.StartTimer(0.5f, DropRayFindPlayer);
	    }
		
		public virtual void CreateBullet(GameObject master, GameObject prefabBullet, int damage){
			poolBullet.GetBullet(master, prefabBullet, rayPoint.position, tr.rotation, dir.normalized, damage);
            audio?.PlayOneShot(noiseShot);
		}
		void OnDestroy(){
		}
	}
}
