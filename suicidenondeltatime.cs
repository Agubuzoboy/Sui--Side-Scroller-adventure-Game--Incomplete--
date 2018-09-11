using UnityEngine;
using System.Collections;

public class suicidenondeltatime : MonoBehaviour {

	// Use
	public float timer = 5; 
	public float sub = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		
		timer -= sub; 
		
		if (timer <= 0) {
			Destroy(gameObject);
		}
		
	} 

}
