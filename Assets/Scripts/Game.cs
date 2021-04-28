using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game Instance { get; set; }
    //black
    public Image imageK;
    public BoolData Blacklost;
    public StringData blackName;
    public int blackCaptured = 0;
    //white
    public Image imageW;
    public BoolData Whitelost;
    public StringData whiteName;
    public int whiteCaptured = 0; 
    //red
    public Image imageR;
    public BoolData Redlost;
    public StringData redName;
    public int redCaptured = 0; 
    //blue
    public Image imageB;
    public BoolData Bluelost;
    public StringData blueName;
    public int blueCaptured = 0; 

    public GameObject winScreen; 
    public TMP_Text playerWinName;

    public GameObject titleScreen; 
    public GameObject nameScreen;
    public TMP_InputField BlackNameFeild;
    public TMP_InputField WhiteNameFeild;
    public TMP_InputField RedNameFeild;
    public TMP_InputField BlueNameFeild;

    //pop up stuff
    public GameObject popUpScreen;
    public Image PopUpScreenImage;
    public TMP_Text CallOutText;

    public int numPlayers = 2;
    public int turnCounter { get; set; } = 1;


    public static Button[,] buttons = new Button[19, 19];

    private void Awake()
    {
        Instance = this;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Row");
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                Button[] tempArr = objects[i].GetComponentsInChildren<Button>();
                buttons[i, j] = tempArr[j];
            }
        }
    }
    private void Update()
    {
        if (blackCaptured >= 10)
        {
            Blacklost.value = true;
        }
        if (whiteCaptured >= 10)
        {
            Whitelost.value = true;
        }
        if (blueCaptured >= 10)
        {
            Bluelost.value = true;
        }
        if (redCaptured >= 10)
        {
            Redlost.value = true;
        }
        switch (turnCounter%numPlayers)
        {
            case 0:
                if(Blacklost.value)
                {
                    turnCounter++;
                }
                break;
            case 1:
                if (Whitelost.value)
                {
                    turnCounter++;
                }
                break;
            case 2:
                if (Redlost.value)
                {
                    turnCounter++;
                }
                break;
            case 3:
                if (Bluelost.value)
                {
                    turnCounter++;
                }
                break;
            default:
                break;
        }
    }

    public void OnExit()
    {
        Game.Instance = null;
        titleScreen.SetActive(true);
    }
    public void OnExitApp()
    {
        Application.Quit();
    }
    public void OnStart()
    {
        titleScreen.SetActive(false);
        nameScreen.SetActive(true);
    }
    public void OnEnterNames()
    {
        blackName.value = BlackNameFeild.text;
        whiteName.value = WhiteNameFeild.text;
        redName.value = RedNameFeild.text;
        blueName.value = BlueNameFeild.text;
        nameScreen.SetActive(false);
        OnPlay();
    }
    public void OnPlay()
    {
        Instance = this;
        Game.Instance.turnCounter = 1;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Row");
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                Button[] tempArr = objects[i].GetComponentsInChildren<Button>();
                buttons[i, j] = tempArr[j];
                buttons[i, j].GetComponent<Tile>().colour = Tile.eColour.None;
            }
        }
        buttons[9, 9].GetComponent<Tile>().colour = Tile.eColour.White;
    }
    public void OnPlayAgain()
    {
        winScreen.SetActive(false);
        OnPlay();
    }
    public void OnClosePopUp()
    {
        popUpScreen.SetActive(false);
    }
}
