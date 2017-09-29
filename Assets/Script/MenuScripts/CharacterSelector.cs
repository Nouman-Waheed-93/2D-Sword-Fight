using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {

    public RectTransform[] Highlighter = new RectTransform[2];
    public GameObject CharacterP;
    public GameObject StgSlctMenuGo;

    private Image[,] CharacterPhotos = new Image[4,3];

    private int[] currCharXInd = new int[2];
    private int[] currCharYInd = new int[2];

    float[] MoveTime = new float[2];

    bool[] selected = new bool[2];

    private string[] Horizontal = { "HorizontalP1" , "HorizontalP2"};
    private string[] Vertical = { "VerticalP1" , "VerticalP2"};
    private string[] Attack = { "AttackP1" , "AttackP2"};
    
    // Use this for initialization
    void Start () {
        Image[] CharacterPhotos1D = CharacterP.GetComponentsInChildren<Image>();
        int currAssignInd = -1;
        for (int y = 0; y < 3; y++) {
            for (int x = 0; x < 4; x++) {
                currAssignInd++;
                CharacterPhotos[x, y] = CharacterPhotos1D[currAssignInd];
            }
        }
        for (int i = 0; i < 2; i++) {
            currCharXInd[i] = i;
            Highlighter[i].anchoredPosition = CharacterPhotos[currCharXInd[i], 0].rectTransform.anchoredPosition;
        }
	}

  
	void Update () {

        for (int i = 0; i < 2; i++)
        {
            if (selected[i])
                continue;
            MoveTime[i] += Time.deltaTime;

            int px = (int)Input.GetAxisRaw(Horizontal[i]);
            int py = (int)Input.GetAxisRaw(Vertical[i]);
            if (px != 0 && MoveTime[i] > 0.3f)
            {
                currCharXInd[i] = Mathf.Clamp(currCharXInd[i] + px, 0, 3);
                Highlighter[i].anchoredPosition = CharacterPhotos[currCharXInd[i], currCharYInd[i]].rectTransform.anchoredPosition;
                MoveTime[i] = 0;
            }
            if (py != 0 && MoveTime[i] > 0.3f)
            {
                currCharYInd[i] = Mathf.Clamp(currCharYInd[i] - py, 0, 2);
                Highlighter[i].anchoredPosition = CharacterPhotos[currCharXInd[i], currCharYInd[i]].rectTransform.anchoredPosition;
                MoveTime[i] = 0;
            }

            if (Input.GetButtonDown(Attack[i]))
            {
                GlobalVals.P1CharInd = currCharXInd[i] + currCharYInd[i] * 4 ;
                selected[i] = true;
                for (int z = 0; z < 2; z++) {
                    if (!selected[z]) {
                        break;
                    }
                    if (z == 1)
                    {
                        gameObject.SetActive(false);
                        StgSlctMenuGo.SetActive(true);
                    }
                }
            }
        }
	}
}
