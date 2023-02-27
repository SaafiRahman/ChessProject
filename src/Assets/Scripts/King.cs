using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public bool isWKing;
    public bool king;

    public void setKing(bool x, bool y)
    {
        king = x;
        isWKing = y;
    }
}
