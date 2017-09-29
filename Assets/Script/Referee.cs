using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Referee : MonoBehaviour {

    private  float LastAttack1Time = 0;
    private  int Attack1Stance, Attack2Stance;
    private  bool bothAttacked;
    private  FighterCS attackedOne1, attackedOne2;
    private  bool WinnerDecided;

    public static Referee instance;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {

    //    if (Time.time - LastAttack1Time > 0.2f && !WinnerDecided && attackedOne1) {
      //      DecideWinner();
       // }

	}

    public void ObserveAttack(int stance, FighterCS attackedOne) {
        if (WinnerDecided)
            return;

        if (stance != attackedOne.GetStance || !attackedOne.GetOnLand)
        {
            print("Kalla Attack");
            LastAttack1Time = Time.time;
            Attack1Stance = stance;
            attackedOne1 = attackedOne;
            DecideWinner();
            WinnerDecided = true;
        }
        else {
            attackedOne.Block();
        }
    //    else {
      //      print("Dona da attack");
       //     LastAttack1Time = Time.time;
        //    Attack2Stance = stance;
          //  attackedOne2 = attackedOne;
           // bothAttacked = true;
            //DecideWinner();
        //}
           
    }

    private  void DecideWinner() {

        print("Trying to decide");
        if (bothAttacked)
        {
            print("Warr gaye byi");
            if (Attack1Stance != Attack2Stance)
            {
                attackedOne1.GetHit();
                WinnerDecided = true;
                GameMenu.instance.Invoke("ShowMenu", 1);
            }
        }
        else {
            print("Heya no");
            if (Attack1Stance != attackedOne1.GetStance)
            {
                attackedOne1.GetHit();
                WinnerDecided = true;
                GameMenu.instance.Invoke("ShowMenu", 1);
            }
            else {
          //      attackedOne1.Block();
           //     attackedOne1 = null;
            }
        }
  
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
