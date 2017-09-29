using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageSelection : MonoBehaviour {

    public RectTransform Highlighter;

    public GameObject StageP;

    private Image[,] StagePhotos = new Image[4,3];

    private int currStgeXInd, currStgeYInd;

    private string HorizontalP1 = "HorizontalP1";
    private string VerticalP1 = "VerticalP1";
    private string AttackP1 = "AttackP1";
    
    // Use this for initialization
    void Start()
    {
        Image[] StagePhotos1D = StageP.GetComponentsInChildren<Image>();
        int stgIndCount = -1;
        for (int y = 0; y < 3; y++) {
            for (int x = 0; x < 4; x++) {
                stgIndCount++;
                StagePhotos[x, y] = StagePhotos1D[stgIndCount];
            }
        }

        Highlighter.anchoredPosition = StagePhotos[0, 0].rectTransform.anchoredPosition;
    }


    float MoveTime = 0;
    void Update()
    {
        MoveTime += Time.deltaTime;

        int p1x = (int)Input.GetAxisRaw(HorizontalP1);
        int p1y = (int)Input.GetAxisRaw(VerticalP1);
        if (p1x != 0 && MoveTime > 0.3f)
        {
            currStgeXInd = Mathf.Clamp(currStgeXInd + p1x, 0, 3);
            Highlighter.anchoredPosition = StagePhotos[currStgeXInd, currStgeYInd].rectTransform.anchoredPosition;
            MoveTime = 0;
        }
        if (p1y != 0 && MoveTime > 0.3f)
        {
            currStgeYInd = Mathf.Clamp(currStgeYInd - p1y, 0, 2);
            Highlighter.anchoredPosition = StagePhotos[currStgeXInd, currStgeYInd].rectTransform.anchoredPosition;
            MoveTime = 0;
        }
        if (Input.GetButtonDown(AttackP1))
        {
            GlobalVals.StageInd = currStgeXInd + currStgeYInd *4;
            SceneManager.LoadScene(1);
        }
    }

}
