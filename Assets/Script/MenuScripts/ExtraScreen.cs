using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExtraScreen : MonoBehaviour {



    public RectTransform Highlighter;

    public GameObject MMBtnsP;
    public GameObject MainScreen;

    private Image[] MMBtns = new Image[1];

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
            currYInd = Mathf.Clamp(currYInd - p1y, 0, 0);
            Highlighter.anchoredPosition = MMBtns[currYInd].rectTransform.anchoredPosition;
            MoveTime = 0;
        }

        if (Input.GetButtonDown(AttackP1))
        {
            if (currYInd == 0)
            {
                gameObject.SetActive(false);
                MainScreen.SetActive(true);
            }
        }
    }


}
