using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetter : MonoBehaviour {

    public Transform EnvPos, P1Pos, P2Pos;

    public GameObject[] EnvironmentsFabs;
    public GameObject[] Player1Fabs;
    public GameObject[] Player2Fabs;

	void Start () {
        Instantiate(EnvironmentsFabs[GlobalVals.StageInd]);
        Instantiate(Player1Fabs[GlobalVals.P1CharInd]);
        Instantiate(Player2Fabs[GlobalVals.P2CharInd]);
	}
	
}
