using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour { 

	public float speed = 5f; 
	public float jumpheight = 5f;  
	Animator anim; 
	public bool jump = false; 
	public bool rm = false; 
	public bool lm = false; 
	public float jumpnum = 1f; 
	public float jumpmax = 1f; 
	public bool move = false;
	public bool airborne = false; 
	public bool norm = false; 
	public bool nolm = false; 
	public rightwalldetectorscript rightwalldetectorscript; 
	public leftwalldetctorscript leftwalldetctorscript; 
	public bool facingleft; 
	public bool facingright;
	public bool walkingani = false; 
	public suifire suifire; 
	public bool halfshootani = false;
	public bool tellothertoshoot = false;
	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>(); 

	}
	public void shootfire (float shoot) { 
		tellothertoshoot = true;
	}
	// Update is called once per frame
	void Update () {






		if (suifire.shootani) {
			anim.SetTrigger("fire"); 
			suifire.shootani = false;
		}
	


		//try using rigidbody to get jump nd move effect
		gameObject.tag = "player";
		    
		if (walkingani) { 
			anim.SetBool ("walking", true);
		} else {
			anim.SetBool ("walking", false);
		
		}

		if (rm && norm == false || lm && nolm == false) { 
			walkingani = true;
		} else {
			walkingani = false;
		}



		if (transform.localScale == new Vector3 (2.935887f, 2.935888f, 2.935888f)) { 
			facingright = true;
		} else {
			facingright = false;
		}
		if (transform.localScale == new Vector3 (-2.935887f, 2.935888f, 2.935888f)) { 
			facingleft = true;
		} else {
			facingleft = false;
		}

		if (rightwalldetectorscript.rightwalldetected && facingright) { 
			norm = true;
		} else {
			norm = false;
		}

		if (rightwalldetectorscript.rightwalldetected && facingleft) { 
			nolm = true; 
		} else { 
			nolm = false;
		}

		if (rm && norm == false) {  
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y); 
			transform.localScale = new Vector3 (2.935887f, 2.935888f, 2.935888f); 
		}





		if (lm && nolm == false) {  
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y); 
			transform.localScale = new Vector3 (-2.935887f, 2.935888f, 2.935888f);
		}
	

	if(rm || lm || airborne){ 
			move = true;} 
		else{move = false;}


		if(jump){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpheight); 
			jumpnum -=1; } 


	
	    



		if(Input.GetKeyDown(KeyCode.UpArrow)){ 
			jump=true;
		}  
		else{jump=false;} 


		if(Input.GetKey(KeyCode.RightArrow)){  
			rm = true;}  
		else{rm=false; 
			}

		if(Input.GetKey(KeyCode.LeftArrow)){  
			lm = true; 
			} 
		else{lm=false; 
			}
 
		if(jumpnum <= 0){ 
			jump = false;} 

		if(move == false) 
		{GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y );}  

		if(airborne){ 
			GetComponent<Rigidbody2D>().velocity = new Vector2( GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y); 
			move = true;}
		

} 

	void OnTriggerEnter2D(Collider2D other){ 
		jumpnum = jumpmax;
		

		
		
	} 


	void OnTriggerStay2D (Collider2D other){ 
		airborne = false;} 


	void OnTriggerExit2D (Collider2D other){  
		airborne = true;
	}




}
