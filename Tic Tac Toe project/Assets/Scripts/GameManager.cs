using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int whoseTurn; // 0 = x, 1 = O
    [SerializeField] private int turnsCounter;
    [SerializeField] private GameObject[] turnsIcon;
    [SerializeField] private Sprite[] playerIcon;
    [SerializeField] private Button[] gridButtoms;
    [SerializeField] private int[] markedSpaces = new int[9];
    private int[] check = new int[8]; // Array of chacked positions 

    // Start is called before the first frame update
    void Start()
    {
        GameAwake();
    }

    void GameAwake()
    {
        whoseTurn = 0;
        turnsCounter = 0;
        turnsIcon[0].SetActive(true);
        turnsIcon[1].SetActive(false);
        for (int i = 0; i < gridButtoms.Length; i++)
        {
            gridButtoms[i].interactable = true;
            gridButtoms[i].GetComponent<Image>().sprite = null;
        }

        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = 100;
        }
    }

    

    public void WichButtonSeleced(int buttonNumber)
    {
        
        gridButtoms[buttonNumber].image.sprite = playerIcon[whoseTurn];
        gridButtoms[buttonNumber].interactable = false;
        markedSpaces[buttonNumber] = whoseTurn+1;

        turnsCounter++;
        if (turnsCounter > 4)
        {
            WinnerChecking();
        }

        if (whoseTurn == 0)
        {
            whoseTurn = 1;
            turnsIcon[0].SetActive(false);
            turnsIcon[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnsIcon[0].SetActive(true);
            turnsIcon[1].SetActive(false);
        }

    }

    void WinnerChecking()
    {
        check[0] = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        check[1] = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        check[2] = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        check[3] = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        check[4] = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        check[5] = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        check[6] = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        check[7] = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];

        
        for (int i = 0; i < check.Length; i++)
        {
            if (check[i] == 0 | check[i] == 3)
            {
                Debug.Log("Player" + whoseTurn + "won!");
                //return;
            }
        }
    }


}
