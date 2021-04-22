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
    public Image button;
    public eColour colour = eColour.None;

    private void Awake()
    {
        button = GetComponent<Image>();
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
                button.sprite = Game.Instance.imageB.sprite;
                button.color = new Color(255, 255, 255, 255);
                this.enabled = false;
                break;
            case eColour.White:
                button.sprite = Game.Instance.imageW.sprite;
                button.color = new Color(255, 255, 255, 255);
                this.enabled = false;
                break;
            case eColour.None:
                button.sprite = null;
                this.enabled = true;
                button.color = new Color(255, 255, 255, 0);
                break;
            default:
                break;
        }
    }
}
