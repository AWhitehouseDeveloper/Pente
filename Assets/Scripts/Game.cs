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

    public Button[][] board = new Button[19][];

    private void Awake()
    {
        Instance = this;
    }

}
