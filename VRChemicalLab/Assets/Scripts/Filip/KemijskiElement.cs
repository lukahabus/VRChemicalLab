using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AgregatnoStanje
{
    KRUTO_TIJELO,
    TEKUCINA,
    PLIN
};

[CreateAssetMenu(fileName = "novi element", menuName = "Kemijski Element")]
public class KemijskiElement : ScriptableObject
{
    public string imeKemijskogElementa;

    public string kemijskiSimbol;

    public AgregatnoStanje agregatnoStanje;

    //u °C
    public float vreliste;
    public float taliste;

    public Color boja;

}

