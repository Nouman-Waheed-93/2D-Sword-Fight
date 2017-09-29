using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRotationHandler : MonoBehaviour {

    FighterCS[] fighters;

	void Start () {
        fighters = FindObjectsOfType<FighterCS>();
    }

    void Update() {

        for (int i = 0; i < fighters.Length * 0.5f; i+=2) {
            
            float F1ToF2 = (float)(fighters[i + 1].transform.position.x - fighters[i].transform.position.x);
            Vector3 F2ToF1 = (fighters[i].transform.position - fighters[i + 1].transform.position).normalized;
            if (F1ToF2 * fighters[i].transform.right.x < 0) {
                fighters[i].transform.Rotate(0, 180, 0);
                fighters[i + 1].transform.Rotate(0, 180, 0);
            }
           
        }

    }
	
}
