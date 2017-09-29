using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    Transform Shooter;
    bool launched = true;

	// Update is called once per frame
	public void Shoot (Transform Shooter) {
        launched = true;
        this.Shooter = Shooter;
	}

    void OnCollisionEnter2D(Collision2D other) {

        if (other.transform.root == Shooter)
            return;

        if (launched && (other.gameObject.layer == 8 || other.gameObject.layer == 9))
        {
            other.transform.root.GetComponent<FighterCS>().GetHit();
            StoneThrower.instance.StoneDestroyed();
            GameMenu.instance.Invoke("ShowMenu", 1);
          //  Referee.instance.Invoke("RestartLevel", 1);
            Destroy(gameObject);
        }
        else if (launched && other.gameObject.layer == 10) {
            StoneThrower.instance.StoneDestroyed();
            Destroy(other.gameObject);
        }
        launched = false;
    }
    
}
