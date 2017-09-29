using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        print("warr gaye bi");
       
        if(other.gameObject.layer == 8 || other.gameObject.layer == 9){
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.root.forward * 5, ForceMode.Impulse);
        }
    }

}
