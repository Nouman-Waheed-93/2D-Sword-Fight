using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCS : MonoBehaviour {

    public float LandedDistance = 0.2f;
    public float MvmntSpeed = 3;
    public enum PlayerNumber {
        Player1,
        Player2
    };
    public PlayerNumber thisPlayer = PlayerNumber.Player1;

    private Animator fighterAnim;
    private Rigidbody2D myRB;
    private int MvmntSide = 0;
    private bool BJump;
    private bool AttackOnGoing;
    private bool Dead;
    private bool OnLand = true;
    public bool GetOnLand {
        get {
            return OnLand;
        }
    }
    
    private int JumpAnimId;
    private int LandAnimId;
    private int WalkAnimId;
    private int RiseId;
    private int AttackId;
    private int BlockId;
    private int CrouchId;
    private int DieId;

    private string HorizontalP1 = "HorizontalP1";
    private string VerticalP1 = "VerticalP1";
    private string AttackP1 = "AttackP1";
    private string JumpP1 = "JumpP1";

    private string HorizontalP2 = "HorizontalP2";
    private string VerticalP2 = "VerticalP2";
    private string AttackP2 = "AttackP2";
    private string JumpP2 = "JumpP2";

    private float AttackRate = 0.4f;
    private float AttackTime = 0;
    private int myStance = 0;
    public int GetStance {
        get {
            return myStance;
        }
    }
        

    private MeleeWeapon myWep;
    private Ray2D landRay;
    // Use this for initialization
    void Start () {
        fighterAnim = GetComponent<Animator>();
        JumpAnimId = Animator.StringToHash("Jump");
        LandAnimId = Animator.StringToHash("Land");
        WalkAnimId = Animator.StringToHash("Walk");
        RiseId = Animator.StringToHash("Rise");
        CrouchId = Animator.StringToHash("Crouch");
        AttackId = Animator.StringToHash("Attack");
        BlockId = Animator.StringToHash("Block");
        DieId = Animator.StringToHash("Dead");
        myWep = GetComponentInChildren<MeleeWeapon>();
        myRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

        if (Dead)
            return;

        AttackTime -= Time.deltaTime;
        if (AttackTime < 0)
            StopAttack();

        CheckGrounded();
        
            MvmntSide = (thisPlayer == PlayerNumber.Player1) ? (int)Input.GetAxisRaw(HorizontalP1) : (int)Input.GetAxisRaw(HorizontalP2);
            fighterAnim.SetInteger(WalkAnimId, MvmntSide);
        
       
        if (((thisPlayer == PlayerNumber.Player1) ? Input.GetButtonDown(JumpP1) : Input.GetButtonDown(JumpP2)) && OnLand)
        {
            BJump = true;
            fighterAnim.SetTrigger(JumpAnimId);
        }


        //Handle Stance
        if (((thisPlayer == PlayerNumber.Player1) ? Input.GetAxisRaw(VerticalP1) : Input.GetAxisRaw(VerticalP2)) > 0)
        {
            fighterAnim.SetBool(RiseId, true);
            myStance = 1;
        }
        else if (((thisPlayer == PlayerNumber.Player1) ? Input.GetAxisRaw(VerticalP1) : Input.GetAxisRaw(VerticalP2)) < 0)
        {
            fighterAnim.SetBool(CrouchId, true);
            myStance = -1;
        }
        else
        {
            fighterAnim.SetBool(RiseId, false);
            fighterAnim.SetBool(CrouchId, false);
            myStance = 0;
        }

        if (MvmntSide == 0 && OnLand && AttackTime < 0 && ((thisPlayer == PlayerNumber.Player1) ? Input.GetButtonDown(AttackP1) : Input.GetButtonDown(AttackP2)))
        {
            AttackTime = AttackRate;
            fighterAnim.SetTrigger(AttackId);
            AttackOnGoing = true;
        }

        
    }

    void CheckGrounded() {

        for (int i = -1; i < 2; i++) {
            //landRay = new Ray2D(transform.position + transform.up * 0.1f + transform.forward * i * 0.2f, -transform.up);
            Debug.DrawRay(transform.position + transform.right * i * 0.2f, -transform.up * LandedDistance, Color.blue);
            OnLand = Physics2D.Raycast(transform.position + transform.right * i * 0.2f, -transform.up, LandedDistance);
            if (OnLand)
            {
                 break;
            }
        }
        fighterAnim.SetBool(LandAnimId, OnLand);

    }

    void FixedUpdate()
    {
        myRB.AddForce(new Vector2(MvmntSide * 20, 0));
        if (BJump) {
            BJump = false;
            myRB.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);
        }
        if(myRB.velocity.magnitude > MvmntSpeed)
           myRB.velocity = new Vector2(Mathf.Sign(myRB.velocity.x) * Mathf.Abs(MvmntSide) * MvmntSpeed, myRB.velocity.y);

    }

    void OnTriggerStay2D(Collider2D other) {

        if (!AttackOnGoing || other.isTrigger)
            return;
       
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            Referee.instance.ObserveAttack(myStance, other.transform.root.GetComponent<FighterCS>());
            AttackOnGoing = false;
            AttackTime = -1;
        }
        else if (other.gameObject.layer == 10)
        {
            other.GetComponent<Rigidbody2D>().AddForce(transform.right * 200 + Vector3.up * 40, ForceMode2D.Impulse);
            other.GetComponent<Stone>().Shoot(transform.root);
            AttackTime = -1;
            AttackOnGoing = false;
        }


    }

    public void Block() {
        fighterAnim.SetTrigger(BlockId);
    }

    public void Attack() {
        AttackOnGoing = true;
    }

    void StopAttack() {
        AttackOnGoing = false;
    }
    public void GetHit() {
        if (!Dead)
        {
            Dead = true;
            fighterAnim.SetTrigger(DieId);
            MvmntSide = 0;
        }
    }

}

