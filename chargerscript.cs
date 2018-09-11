using UnityEngine;
using System.Collections;

public class chargerscript : MonoBehaviour { 

	public float health = 5f; 
	public float speed = 5f;   
	public float dspeed = 10f;
	public float max = 20f; 
	public float min = 10f; 
	public bool right = false; 
	public bool left = false;
	public GameObject player;
	public bool charge = false; 
	public bool go = false; 
	public bool enemylosehealth = false; 
	public bool enemydeath = false; 
	public Color red; 
	public Color white; 
	public playerhealth playerhealth;



	// Use this for initialization
	void Start () { 


	
	}
	
	// Update is called once per frame
	void Update () {  
		 


		gameObject.tag = "charger";

		
		if (enemydeath){
			
			Destroy(gameObject);
			
		} 

		if (health <= 0) {
			enemydeath = true;
		}


		player = GameObject.FindGameObjectWithTag("player"); 

 

		if(transform.position.x <= min && charge == false){ 
			right = true;		} 
		
		
		
		
		
		if(right){
			transform.Translate(Vector2.right * speed * Time.deltaTime);  
			transform.eulerAngles = new Vector3(0,0,0);
			left = false;}  
		
		
		
		
		if(transform.position.x >=  max && charge == false){ 
			left = true;		
		} 
		
		
		if(left){
			transform.Translate(Vector2.right * speed * Time.deltaTime); 
			transform.eulerAngles = new Vector3(0,180,0);
			right = false;}  
 
		if(charge){ 
			left = false; 
			right = false;   
			go = true; 
		}
		 
		if(go){

			transform.Translate(Vector2.right * dspeed * Time.deltaTime); 
		}


		if (enemylosehealth) {
		
			health -= 5f; 
			enemylosehealth = false;
		
		}




		} 

	IEnumerator damage(){   


			GetComponent<SpriteRenderer> ().color = red; 	
			yield return new WaitForSeconds (0.5f); 
			

	}

	void OnTriggerEnter2D(Collider2D other){ 
		if (other.gameObject.tag == "player") { 
			charge = true;
		}
			




			
		} 


	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "fireball") {
			enemylosehealth = true;  
			StartCoroutine("damage");
		} else {
			enemylosehealth = false;
		}

	}


	} 



	



	


