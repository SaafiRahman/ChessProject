using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    public bool isWQueen;
    public bool queen;

    public void setQueen(bool x, bool y)
    {
        queen = x;
        isWQueen = y;
    }
}
