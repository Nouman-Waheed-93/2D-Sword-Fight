using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour {


    public RectTransform Highlighter;

    public GameObject MMBtnsP;
    public GameObject MainScreen;
    public Text StoneThrowTgl;

    private Image[] MMBtns = new Image[2];

    private int currYInd;

    private string VerticalP1 = "VerticalP1";
    private string AttackP1 = "AttackP1";

    // Use this for initialization
    void Start()
    {
        MMBtns = MMBtnsP.GetComponentsInChildren<Image>();
        Highlighter.anchoredPosition = MMBtns[0].rectTransform.anchoredPosition;
    }


    float MoveTime = 0;
    void Update()
    {
        MoveTime += Time.deltaTime;

        int p1y = (int)Input.GetAxisRaw(VerticalP1);
        if (p1y != 0 && MoveTime > 0.3f)
        {
            currYInd = Mathf.Clamp(currYInd - p1y, 0, 1);
            Highlighter.anchoredPosition = MMBtns[currYInd].rectTransform.anchoredPosition;
            MoveTime = 0;
        }

        if (Input.GetButtonDown(AttackP1))
        {
            
            if (currYInd == 0)
            {
                GlobalVals.ThrowStones = !GlobalVals.ThrowStones;
                StoneThrowTgl.text = GlobalVals.ThrowStones ? "Stone Fall : On" : "Stone Fall : Off";
            }
            else if (currYInd == 1)
            {
                gameObject.SetActive(false);
                MainScreen.SetActive(true);
            }
        }
    }

}
