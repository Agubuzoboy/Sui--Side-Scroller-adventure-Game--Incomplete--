using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	
	public float speed = 5f; 
	public GameObject fire; 
	public bool fright = false; 
	public bool fleft = false; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {  

		gameObject.tag = "fireball";

		if (transform.eulerAngles == new Vector3 (0f, 0f, 0f)) {
			fright = true;
		} else {
			fleft = true;
		}

		if (transform.eulerAngles == new Vector3 (0f, 180f, 0f)) {
			fleft = true; 

		} else {
			fright = true;
		}


		if (fright) { 
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
					}

	if (fleft){ 
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	
	
	
	
	}
}