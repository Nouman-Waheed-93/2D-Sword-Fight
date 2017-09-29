using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHndlr : MonoBehaviour {

    public RectTransform Highlighter;

    public GameObject MMBtnsP;
    public GameObject ChrctrScreen, OptionScreen, ExtraScreen;

    private Image[] MMBtns = new Image[3];

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
            currYInd = Mathf.Clamp(currYInd - p1y, 0, 2);
            Highlighter.anchoredPosition = MMBtns[currYInd].rectTransform.anchoredPosition;
            MoveTime = 0;
        }

        if (Input.GetButtonDown(AttackP1))
        {
            gameObject.SetActive(false);
            if (currYInd == 0)
            {
                ChrctrScreen.SetActive(true);
            }
            else if (currYInd == 1)
            {
                OptionScreen.SetActive(true);
            }
            else {
                ExtraScreen.SetActive(true);
            }
        }
    }
}
