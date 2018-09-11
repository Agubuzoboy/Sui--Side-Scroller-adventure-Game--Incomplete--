using UnityEngine;
using System.Collections;

public class destroyonhit : MonoBehaviour {

	public float health = 5f;
	public bool enemylosehealth = false; 
	public bool enemydeath = false; 
	public Color red; 
	public Color white;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if (enemydeath){
			
			Destroy(gameObject);
			
		} 
		
		if (health <= 0) {
			enemydeath = true;
		} 

		if (enemylosehealth) {
			
			health -= 5f; 
			enemylosehealth = false;
		}





	
}
	IEnumerator damage(){   
		
		
		GetComponent<SpriteRenderer> ().color = red; 	
		yield return new WaitForSeconds (0.5f);  
		GetComponent<SpriteRenderer> ().color = white; 	

		
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