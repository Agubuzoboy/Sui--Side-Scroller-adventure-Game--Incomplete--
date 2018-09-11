using UnityEngine;
using System.Collections;

public class fixitup : MonoBehaviour {


	public Transform shooter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 


		if(Input.GetKey(KeyCode.LeftArrow)){ 
			transform.eulerAngles = new Vector3 (0f, 180f, 0f); 

		}  


		if(Input.GetKey(KeyCode.RightArrow)){
			transform.eulerAngles = new Vector3(0f, 0f, 0f); 
			
		}  


	
	}
}
