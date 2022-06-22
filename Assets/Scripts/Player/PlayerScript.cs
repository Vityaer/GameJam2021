using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Platformer{
    public class PlayerScript : MonoBehaviour{

        private bool isAlive = true;

    	private Rigidbody2D rb;
        private bool isFacingRight = false;
        public float runSpeed = 2f;
        private Transform tr;
        [SerializeField] private Animator anim;
        [SerializeField] private float timerGameOver = 3f;
        [Header("UI")]
        public Text textTimer;
    	void Awake(){
            instance = this;
            tr = GetComponent<Transform>();
    		rb = GetComponent<Rigidbody2D>();
    	}
    	Vector2 move = new Vector2(0f, 0f);
        Vector2 direction = new Vector2();
        public float debuffSpeed = 0f;
        void Start(){
        }
        GameObject objectUnderLegs;
        void Update(){
                if(Input.GetKeyUp( KeyCode.A ) || Input.GetKeyUp( KeyCode.D )){
                    move.x = 0f;
                }
                if(Input.GetKey( KeyCode.A )){
                    if(isFacingRight) Flip(false);
                    move.x = -1f;
                }
                if(Input.GetKey( KeyCode.D )){
                    if(!isFacingRight) Flip(true);
                    move.x = 1f;
                }
                
                if(Input.GetKeyUp( KeyCode.S ) || Input.GetKeyUp( KeyCode.W )){
                    move.y = 0f;
                    result = true;
                }
                if(Input.GetKeyDown(KeyCode.S)){
                    move.y = -1f;
                }
                if(Input.GetKeyDown( KeyCode.W )){
                	move.y = 1f;
                }
            if(CanMoving()){
                if(direction.magnitude < 1f) {
                    timerGameOver -= Time.deltaTime;
                    if(timerGameOver >= 0f){
                        textTimer.text = string.Concat(Math.Round(timerGameOver, 1).ToString(), "s.");
                    }
                } else{
                    timerGameOver = 3f;
                    textTimer.text = "";
                }
                if(timerGameOver <= 0f){
                    LevelControllerScript.Instance.StopLevel();
                }
            }
        }
        void FixedUpdate(){
            anim.SetBool("Run", move.magnitude > 0.1f);
            direction = move.normalized * ((runSpeed > debuffSpeed) ? runSpeed - debuffSpeed: 0f);
            rb.velocity = direction;
        }
        public void Flip(bool isFacingRight){
            this.isFacingRight = isFacingRight; 
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        bool result = false;
        bool CanMoving(){
            return result;
        }


        public void Restart(){
            result = false;
            this.enabled = true;
            textTimer.gameObject.SetActive(true);
        }
        public void GetSlowly(){
            debuffSpeed += 1.5f;
        }
       public void GameOver(){
        this.enabled = false; 
        rb.velocity = new Vector2();
        textTimer.gameObject.SetActive(false);
       }
        private static PlayerScript instance;
        public static PlayerScript Instance{get => instance;}
    }
    

}
