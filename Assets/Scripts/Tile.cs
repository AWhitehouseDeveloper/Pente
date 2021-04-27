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

    List<Button> revertButtons = new List<Button>();

    public void OnClick()
    {
        if(Game.Instance.turnCounter%2 == 1 && this.colour == eColour.None)
        {
            colour = eColour.Black;
            Game.Instance.turnCounter++;
        }
        else if(this.colour == eColour.None)
        {
            colour = eColour.White;
            Game.Instance.turnCounter++;
        }
        CheckCapture();
        foreach (Button b in revertButtons)
        {
            b.enabled = true;
            b.GetComponent<Tile>().colour = eColour.None;
        }
        revertButtons.Clear();
    }

    private void Update()
    {
        switch (colour)
        {
            case eColour.Black:
                this.GetComponent<Image>().sprite = Game.Instance.imageB.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                this.GetComponentInParent<Button>().enabled = false;
                break;
            case eColour.White:
                this.GetComponent<Image>().sprite = Game.Instance.imageW.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                this.GetComponentInParent<Button>().enabled = false;
                break;
            case eColour.None:
                this.GetComponent<Image>().sprite = null;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                this.GetComponentInParent<Button>().enabled = true;
                break;
            default:
                break;
        }
    }

    public void CheckCapture()
    {
        int x = 0;
        int y = 0;
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if (Game.buttons[i, j].GetComponent<Tile>() == this)
                {
                    x = i;
                    y = j;
                }
            }
            if (x != 0 || y != 0) break;
        }
        CheckN(x, y);
        //if(CheckNE(numForCheck, x, y)) return true;
        CheckE(x, y);
        //if(CheckSE(numForCheck, x, y)) return true;
        CheckS(x, y);
        //if(CheckSW(numForCheck, x, y)) return true;
        CheckW(x, y);
        //if(CheckNW(numForCheck, x, y)) return true;
    }

    public bool CheckN(int x, int y)
    {
        bool output = false;
        int num1 = CheckColorSame(x, y, -1, 0);
        int num2 = CheckColorSame(x, y, -2, 0);
        int num3 = CheckColorSame(x, y, -3, 0);
        if (num1 == -1 && num2 == -1 && num3 == 1)
        {
            revertButtons.Add(Game.buttons[x + -1, y]);
            revertButtons.Add(Game.buttons[x + -2, y]);
            output = true;
        }
        return output;
    }
    public bool CheckS(int x, int y)
    {
        bool output = false;
        int num1 = CheckColorSame(x, y, 1, 0);
        int num2 = CheckColorSame(x, y, 2, 0);
        int num3 = CheckColorSame(x, y, 3, 0);
        if (num1 == -1 && num2 == -1 && num3 == 1)
        {
            revertButtons.Add(Game.buttons[x + 1, y]);
            revertButtons.Add(Game.buttons[x + 2, y]);
            output = true;
        }
        return output;
    }

    public bool CheckE(int x, int y)
    {
        bool output = false;
        int num1 = CheckColorSame(x, y, 0, 1);
        int num2 = CheckColorSame(x, y, 0, 2);
        int num3 = CheckColorSame(x, y, 0, 3);
        if (num1 == -1 && num2 == -1 && num3 == 1)
        {
            revertButtons.Add(Game.buttons[x, y + 1]);
            revertButtons.Add(Game.buttons[x, y + 2]);
            output = true;
        }
        return output;
    }
    public bool CheckW(int x, int y)
    {
        bool output = false;
        int num1 = CheckColorSame(x, y, 0, -1);
        int num2 = CheckColorSame(x, y, 0, -2);
        int num3 = CheckColorSame(x, y, 0, -3);
        if (num1 == -1 && num2 == -1 && num3 == 1)
        {
            revertButtons.Add(Game.buttons[x, y - 1]);
            revertButtons.Add(Game.buttons[x, y - 2]);
            output = true;
        }
        return output;
    }
    public int CheckColorSame(int x, int y, int xMod, int yMod)
    {
        if (Game.buttons[x + xMod, y + yMod].GetComponent<Tile>().colour == this.colour)
        {
            return 1;
        }
        else if (Game.buttons[x + xMod, y + yMod].GetComponent<Tile>().colour == eColour.None)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
