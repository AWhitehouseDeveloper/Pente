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

    private void Awake()
    {
    }

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
    }

    public void CheckForTwo()
    {

    }

    public bool CheckForFive()
    {

        return false;
    }

    private void Update()
    {
        switch (colour)
        {
            case eColour.Black:
                this.GetComponent<Image>().sprite = Game.Instance.imageB.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                this.enabled = false;
                break;
            case eColour.White:
                this.GetComponent<Image>().sprite = Game.Instance.imageW.sprite;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                this.enabled = false;
                break;
            case eColour.None:
                this.GetComponent<Image>().sprite = null;
                this.enabled = true;
                this.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                break;
            default:
                break;
        }
    }
}
