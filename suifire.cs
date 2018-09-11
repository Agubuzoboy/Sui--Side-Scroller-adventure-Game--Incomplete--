using UnityEngine;
using System.Collections;

public class suifire : MonoBehaviour {
	public Transform prefab; 
	public Rigidbody2D clone; 
	public float force = 5f;  
	public bool shootani; 
	public Animation fireanim; 
	public playermovement playermovement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 


		if(Input.GetKeyDown(KeyCode.Z)){
		//Rigidbody2D projectile = (Instantiate(prefab,transform.position,transform.rotation)as Rigidbody2D); 
			shootani = true;
		}
		if (playermovement.tellothertoshoot) {
			Rigidbody2D projectile = (Instantiate (prefab, transform.position, transform.rotation)as Rigidbody2D); 
			playermovement.tellothertoshoot = false;
		}
	}


}
