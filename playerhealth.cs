using UnityEngine;
using System.Collections;

public class playerhealth : MonoBehaviour { 

	public bool lvlthreehearts; 

	public float threehearts = 15; 

	public float health; 

	public bool heart3ishalf = false; 
	public bool heart3isempty = false;
	public bool heart2ishalf = false;
	public bool heart2isempty = false;
	public bool heart1ishalf = false; 
	public bool heart1isempty = false; 

	public bool damagebreak = false;
	public float damagebreaktimer = 5f; 
	public float damagebreaktimertotal = 5f;  
	public bool colorchange = false; 
	public float colorchangetimer = 1f;
	public Color red; 
	public Color white; 
	public Animator anim;  
	public bool playhurt = false; 
	public bool pushback = false; 
	public float pushbackforcex = -5; 
	public float pushbackforcey = 5;  
	public bool ghostmode = false;   
	public GameObject enemy; 
	public bool ignorecoll = false;


	public chargerscript chargerscript;



	// Use this for initialization
	void Start () { 

		lvlthreehearts = true;
		damagebreaktimer = damagebreaktimertotal;
	
	}
	
	// Update is called once per frame
	void Update () {  



		anim = GetComponent<Animator>();

		if (lvlthreehearts) {
			health = threehearts; 
			lvlthreehearts = false; 
		} 

	










		if (health == 12.5) {
			heart3ishalf = true;
		}
		if (health == 10) {
			heart3isempty = true;
		}

		if (health == 7.5) {
			heart2ishalf = true;
		}

		if (health == 5) {
			heart2isempty = true;
		}

		if (health == 2.5) {
			heart1ishalf = true;
		}
		if (health == 0) {
			heart1isempty = true;
		}

		if (damagebreaktimer <= 0) { 
			damagebreak = false;   
			colorchange = false; 
			ghostmode = false;
			damagebreaktimer = damagebreaktimertotal;
		}

		if (damagebreak) {
			damagebreaktimer -= 1 * Time.deltaTime; 
		
		} 


	



	} 

	IEnumerator color(){   
		 {
			while (damagebreak) { 
			GetComponent<SpriteRenderer> ().color = red; 	
			yield return new WaitForSeconds(0.3f); 
			GetComponent<SpriteRenderer> ().color = white; 	
				yield return new WaitForSeconds(0.3f);}  


		}

	}



	
	void OnCollisionEnter2D (Collision2D coll) {

		if (coll.gameObject.tag == "charger" && damagebreak == false) { 
	
			damagebreak = true;
			health -= 2.5f; 
			StartCoroutine ("color");   
			anim.SetTrigger ("hurt"); 
			pushback = true;   



	
		} 

		

	}


	void FixedUpdate(){

		if (pushback) { 
			GetComponent<Rigidbody2D>().AddRelativeForce( new Vector2(pushbackforcex,pushbackforcey),ForceMode2D.Impulse); 
			pushback = false;
		}


	}


}