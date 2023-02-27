using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    public bool isWBishop;
    public bool bishop;
    
    public void setBishop(bool x, bool y)
    {
        bishop = x;
        isWBishop = y;
    }
}
