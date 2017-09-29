using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour {

    public static GameMenu instance;

    public RectTransform Highlighter;

    public GameObject MMBtnsP;

    private Image[] MMBtns = new Image[2];

    private int currYInd;

    private string VerticalP1 = "VerticalP1";
    private string AttackP1 = "AttackP1";

    // Use this for initialization
    void Start()
    {
        instance = this;
        MMBtns = MMBtnsP.GetComponentsInChildren<Image>();
        Highlighter.anchoredPosition = MMBtns[0].rectTransform.anchoredPosition;
        gameObject.SetActive(false);
    }


    float MoveTime = 0;
    void Update()
    {
        MoveTime += Time.unscaledDeltaTime;

        int p1y = (int)Input.GetAxisRaw(VerticalP1);
        if (p1y != 0 && MoveTime > 0.3f)
        {
            currYInd = Mathf.Clamp(currYInd - p1y, 0, 2);
            Highlighter.anchoredPosition = MMBtns[currYInd].rectTransform.anchoredPosition;
            MoveTime = 0;
        }

        if (Input.GetButtonDown(AttackP1))
        {
            if (currYInd == 0)
            {
                Time.timeScale = 1;
                Referee.instance.RestartLevel();
            }
            else if (currYInd == 1)
            {
                Time.timeScale = 1;
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
         
        }
    }

    public void ShowMenu() {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
