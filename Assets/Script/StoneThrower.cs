using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneThrower : MonoBehaviour {

    public static StoneThrower instance;
    public GameObject stonP;
    public int NoOfStonesToThrow;
    public float ThrowInterval = 1f;
    public float ThrowRange = 5;
    int ActiveStoneNum;
    float TimeToThrow;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GlobalVals.ThrowStones)
            return;
        TimeToThrow += Time.deltaTime;
        if (ActiveStoneNum < NoOfStonesToThrow && TimeToThrow > ThrowInterval) {
            Instantiate(stonP, transform.position + new Vector3(Random.Range(-ThrowRange, ThrowRange), 0, 0), Quaternion.identity);
            TimeToThrow = 0;
            ActiveStoneNum++;
        }

	}

    public void StoneDestroyed() {
        ActiveStoneNum = Mathf.Clamp(--ActiveStoneNum, 0, NoOfStonesToThrow);
        TimeToThrow = 0;
    }
}
