using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public enum eColour
    {
        Black,
        White,
        Red,
        Blue,
        None
    }
    public eColour colour = eColour.None;

    List<Button> revertButtons = new List<Button>();

    public void OnClick()
    {
        int playerNum = Game.Instance.numPlayers;
        if (Game.Instance.turnCounter % playerNum == 1 && this.colour == eColour.None)
        {
            colour = eColour.Black;
            Game.Instance.turnCounter++;
        }
        else if (Game.Instance.turnCounter % playerNum == 2 && this.colour == eColour.None)
        {
            colour = eColour.Red;
            Game.Instance.turnCounter++;
        }
        else if (Game.Instance.turnCounter % playerNum == 3 && this.colour == eColour.None)
        {
            colour = eColour.Blue;
            Game.Instance.turnCounter++;
        }
        else if (this.colour == eColour.None)
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
        if (CheckNum(5)) { Game.Instance.winScreen.SetActive(true); } //Set Text Of Tria/Tessera/Win to value
        if (CheckNum(4)) {} //Set Text Of Tria/Tessera/Win to value
        if (CheckNum(3)) {} //Set Text Of Tria/Tessera/Win to value
    }

    private void Update()
    {
        switch (colour)
        {
            case eColour.Black:
                this.GetComponent<Image>().sprite = Game.Instance.imageK.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                this.GetComponentInParent<Button>().enabled = false;
                break;
            case eColour.White:
                this.GetComponent<Image>().sprite = Game.Instance.imageW.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                this.GetComponentInParent<Button>().enabled = false;
                break;
            case eColour.Red:
                this.GetComponent<Image>().sprite = Game.Instance.imageR.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                this.GetComponentInParent<Button>().enabled = false;
                break;
            case eColour.Blue:
                this.GetComponent<Image>().sprite = Game.Instance.imageB.sprite;
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
        CheckNCapture(x, y);
        CheckNECapture(x, y);
        CheckECapture(x, y);
        CheckSECapture(x, y);
        CheckSCapture(x, y);
        CheckSWCapture(x, y);
        CheckWCapture(x, y);
        CheckNWCapture(x, y);
    }
    public bool CheckNum(int lookingFor)
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
        int total = 1;
        total += CheckN(x, y);
        total += CheckS(x, y);
        if(total >= lookingFor) return true;
        total = 1;
        total += CheckE(x, y);
        total += CheckW(x, y);
        if(total >= lookingFor) return true;
        total = 1;
        total += CheckNE(x, y);
        total += CheckSW(x, y);
        if(total >= lookingFor) return true;
        total = 1;
        total += CheckSE(x, y);
        total += CheckNW(x, y);
        if (total >= lookingFor) return true;
        return false;
    }
    public int CheckN(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, -(numColor + 1), 0) == 1 && x - numColor >= 0)
        {
            numColor++;
        }
        return numColor;
    }
    public int CheckNE(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, -(numColor + 1), (numColor + 1) ) == 1 && x - 3 >= 0 && y + 3 <= 18)
        {
            numColor++;
        }
        return numColor;
    }
    public int CheckE(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, 0, (numColor + 1)) == 1 && y + 3 <= 18)
        {
            numColor++;
        }
        return numColor;
    }
    public int CheckSE(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, (numColor + 1), (numColor + 1)) == 1 && y + 3 <= 18 && x + 3 <= 18)
        {
            numColor++;
        }
        return numColor;
    }
    public int CheckS(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, (numColor + 1), 0) == 1 && x + 3 <= 18)
        {
            numColor++;
        }
        return numColor;
    }
    public int CheckSW(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, (numColor + 1), -(numColor + 1)) == 1 && x + 3 <= 18 && y - 3 >= 0)
        {
            numColor++;
        }
        return numColor;
    }
    public int CheckW(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, 0, -(numColor + 1)) == 1 && y - 3 >= 0)
        {
            numColor++;
        }
        return numColor;
    }
    public int CheckNW(int x, int y)
    {
        int numColor = 0;
        while (CheckColorSame(x, y, -(numColor + 1), -(numColor + 1)) == 1 && x - 3 >= 0 && y - 3 >= 0)
        {
            numColor++;
        }
        return numColor;
    }
    
    public void CheckNCapture(int x, int y)
    {
        if(x - 3 >= 0)
        {
            int num1 = CheckColorSame(x, y, -1, 0);
            int num2 = CheckColorSame(x, y, -2, 0);
            int num3 = CheckColorSame(x, y, -3, 0);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x - 1, y]);
                revertButtons.Add(Game.buttons[x - 2, y]);
            }
        }
    }
    public void CheckNECapture(int x, int y)
    {
        if (x - 3 >= 0 && y + 3 <= 18)
        {
            int num1 = CheckColorSame(x, y, -1, 1);
            int num2 = CheckColorSame(x, y, -2, 2);
            int num3 = CheckColorSame(x, y, -3, 3);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x + -1, y + 1]);
                revertButtons.Add(Game.buttons[x + -2, y + 2]);
            }
        }
    }
    public void CheckECapture(int x, int y)
    {
        if (y + 3 <= 18)
        {
            int num1 = CheckColorSame(x, y, 0, 1);
            int num2 = CheckColorSame(x, y, 0, 2);
            int num3 = CheckColorSame(x, y, 0, 3);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x, y + 1]);
                revertButtons.Add(Game.buttons[x, y + 2]);
            }
        }
    }
    public void CheckSECapture(int x, int y)
    {
        if (y + 3 <= 18 && x + 3 <= 18)
        {
            int num1 = CheckColorSame(x, y, 1, 1);
            int num2 = CheckColorSame(x, y, 2, 2);
            int num3 = CheckColorSame(x, y, 3, 3);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x + 1, y + 1]);
                revertButtons.Add(Game.buttons[x + 2, y + 2]);
            }
        }
    }
    public void CheckSCapture(int x, int y)
    {
        if (x + 3 <= 18)
        {
            int num1 = CheckColorSame(x, y, 1, 0);
            int num2 = CheckColorSame(x, y, 2, 0);
            int num3 = CheckColorSame(x, y, 3, 0);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x + 1, y]);
                revertButtons.Add(Game.buttons[x + 2, y]);
            }
        }
    }
    public void CheckSWCapture(int x, int y)
    {
        if (x + 3 <= 18 && y - 3 >= 0)
        {
            int num1 = CheckColorSame(x, y, 1, -1);
            int num2 = CheckColorSame(x, y, 2, -2);
            int num3 = CheckColorSame(x, y, 3, -3);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x + 1, y - 1]);
                revertButtons.Add(Game.buttons[x + 2, y - 2]);
            }
        }
    }
    public void CheckWCapture(int x, int y)
    {
        if (y - 3 >= 0)
        {
            int num1 = CheckColorSame(x, y, 0, -1);
            int num2 = CheckColorSame(x, y, 0, -2);
            int num3 = CheckColorSame(x, y, 0, -3);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x, y - 1]);
                revertButtons.Add(Game.buttons[x, y - 2]);
            }
        }
    }
    public void CheckNWCapture(int x, int y)
    {
        if (x - 3 >= 0 && y - 3 >= 0)
        {
            int num1 = CheckColorSame(x, y, -1, -1);
            int num2 = CheckColorSame(x, y, -2, -2);
            int num3 = CheckColorSame(x, y, -3, -3);
            if (num1 == -1 && num2 == -1 && num3 == 1)
            {
                revertButtons.Add(Game.buttons[x - 1, y - 1]);
                revertButtons.Add(Game.buttons[x - 2, y - 2]);
            }
        }
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
