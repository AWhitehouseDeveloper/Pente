using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public enum eColour
    {
        Black,
        White,
        None
    }
    public eColour colour = eColour.None;

    public void OnClick()
    {
        if(Game.Instance.turnCounter%2 == 1)
        {
            colour = eColour.Black;
        }
        else
        {
            colour = eColour.White;
        }

        Game.Instance.turnCounter++;
        this.enabled = false;
    }

    private void Update()
    {
        switch (colour)
        {
            case eColour.Black:
                this.GetComponent<Image>().sprite = Game.Instance.imageB.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                break;
            case eColour.White:
                this.GetComponent<Image>().sprite = Game.Instance.imageW.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                break;
            case eColour.None:
                this.GetComponent<Image>().sprite = null;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                this.enabled = true;
                break;
            default:
                break;
        }
    }

    public bool CheckAll(int numForCheck)
    {
        int x = 0;
        int y = 0;
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if (Game.buttons[i, j] == this)
                {
                    x = i;
                    y = j;
                }
            }
            if (x != 0 || y != 0) break;
        }
        if(CheckN(numForCheck, x, y)) return true;
        if(CheckNE(numForCheck, x, y)) return true;
        if(CheckE(numForCheck, x, y)) return true;
        if(CheckSE(numForCheck, x, y)) return true;
        if(CheckS(numForCheck, x, y)) return true;
        if(CheckSW(numForCheck, x, y)) return true;
        if(CheckW(numForCheck, x, y)) return true;
        if(CheckNW(numForCheck, x, y)) return true;
        return false;
    }

    public bool CheckN(int numForCheck, int x, int y)
    {
        bool output = false;
        for(int i = 1; i <= numForCheck; i++)
        {
            if(i == numForCheck)
            {
                if ((Game.buttons[x-i, y].GetComponent<Tile>().colour == this.colour))
                {
                    output = true;
                }
            }
            if(Game.buttons[x-i, y].GetComponent<Tile>().colour == this.colour || Game.buttons[x-i, y].GetComponent<Tile>().colour == eColour.None)
            {
                break;
            }
        }
        return output;
    }

    public bool CheckNE(int numForCheck, int x, int y)
    {
        return false;
    }

    public bool CheckE(int numForCheck, int x, int y)
    {
        return false;
    }

    public bool CheckSE(int numForCheck, int x, int y)
    {
        return false;
    }

    public bool CheckS(int numForCheck, int x, int y)
    {
        return false;
    }

    public bool CheckSW(int numForCheck, int x, int y)
    {
        return false;
    }

    public bool CheckW(int numForCheck, int x, int y)
    {
        return false;
    }

    public bool CheckNW(int numForCheck, int x, int y)
    {
        return false;
    }
}
