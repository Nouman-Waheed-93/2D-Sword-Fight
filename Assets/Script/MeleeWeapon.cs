using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool attacked;

    public void Attack() {
        attacked = true;
        Invoke("StopAttack", 1f);
    }

    void StopAttack() {
        attacked = false;
    }

    void OnTriggerEnter(Collider other) {
        print("heoaolad");
        if ((!other.gameObject.CompareTag("Weapon")) && attacked && (other.gameObject.layer == 8 || other.gameObject.layer == 9))
        {
            FighterCS hitFighter = other.transform.root.GetComponent<FighterCS>();
            if (hitFighter)
                hitFighter.GetHit();
        }
        else if (other.gameObject.layer == 10 && attacked) {
            other.GetComponent<Rigidbody>().AddForce(transform.root.forward * 30 + Vector3.up * 30, ForceMode.Impulse); ;
        }
    }

}
