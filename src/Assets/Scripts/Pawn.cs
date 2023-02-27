using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public bool pawn;
    public bool isWPawn;

    public void setPawn(bool x, bool y)
    {
        pawn = x;
        isWPawn = y;
    } 
}
