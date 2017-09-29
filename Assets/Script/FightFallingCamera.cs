using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFallingCamera : MonoBehaviour {

    public Transform target;
    Vector3 idealPos;
    Vector3 CurrPos;
    bool ChangePos;
	// Use this for initialization
	void Start () {
        idealPos = transform.position;
        CurrPos = idealPos;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (ChangePos) {
            CurrPos = idealPos + new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
            ChangePos = false;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.forward, target.position - transform.position), Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, CurrPos , Time.deltaTime);
        if (Vector3.Distance(transform.position, CurrPos) < 1)
            ChangePos = true;
	}
}
