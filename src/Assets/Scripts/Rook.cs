using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
    public bool isWRook;
    public bool rook;

    public void setRook(bool x, bool y)
    {
        rook = x;
        isWRook = y;
    }

}
