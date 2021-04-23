using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance { get; set; }
    public Image imageB;
    public Image imageW;
    public int turnCounter { get; set; } = 1;

    public static Button[,] buttons = new Button[19, 19];

    private void Awake()
    {
        Instance = this;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Row");
        for(int i = 0; i < 19; i++)
        {
            for(int j = 0; j < 19; j++)
            {
                Button[] tempArr = objects[i].GetComponentsInChildren<Button>();
                buttons[i, j] = tempArr[j];
            }
        }
    }

    private void Update()
    {
        
    }
}
