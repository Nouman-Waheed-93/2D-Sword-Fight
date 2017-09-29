using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.layer == 10)
        {
            StoneThrower.instance.StoneDestroyed();
            Destroy(other.gameObject, 1);
        }
        else if (other.gameObject.layer == 8 || other.gameObject.layer == 9) {
            GameMenu.instance.ShowMenu();
        }

    }

}
