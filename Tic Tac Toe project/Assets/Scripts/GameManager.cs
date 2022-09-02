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
    }


    public void WichButtonSeleced(int buttonNumber)
    {
        
        gridButtoms[buttonNumber].image.sprite = playerIcon[whoseTurn];
        gridButtoms[buttonNumber].interactable = false;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
