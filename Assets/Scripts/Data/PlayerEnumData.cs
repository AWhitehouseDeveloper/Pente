using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerEnum", menuName = "Data/Enum/Player")]
public class PlayerEnumData : EnumData
{
    public enum eType
    {
        Dyo,
        Tria,
        Tessera,
    }

    public eType value = eType.Dyo;

    public override int index { get => (int)value; set => this.value = (eType)value; }

    public override string[] names => Enum.GetNames(typeof(eType));
}
