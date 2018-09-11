using UnityEngine;
using System.Collections;

public class suicideontouch : MonoBehaviour {

	public bool destroy = false;
	public Transform prefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (destroy) {
			Instantiate(prefab,transform.position, Quaternion.identity);
			Destroy (gameObject); 
			destroy = false;
		}

	} 


	void OnCollisionEnter2D(Collision2D coll){

		destroy = true;

	}

}
