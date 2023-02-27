using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public bool isWKnight;
    public bool knight;

    public void setKnight(bool x, bool y)
    {
        knight = x;
        isWKnight = y;
    }
}
