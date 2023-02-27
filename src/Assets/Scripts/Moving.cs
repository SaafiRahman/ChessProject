using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    RaycastHit2D hit;
    private Boolean isDragging;
    private ChessBoard chessboard = new ChessBoard();
    Camera Cam;
    Vector3 dragoffset;
    private float initposX;
    private float initposY;

    private void Start()
    {   
        Cam = Camera.main;
    }
    private void OnMouseDown()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            // hit.collider.gameObject.GetComponent<Pawn>.setPawn(true);
        }
        initposX = transform.position.x;
        initposY = transform.position.y;
        dragoffset = transform.position - getMousePos();
    }
    
    private void OnMouseDrag()
    {
        transform.position = getMousePos() + dragoffset;
        
    }

    private void OnMouseUp()
    {
        PlacePiece(transform.position.x, transform.position.y);
    }

    private Vector3 getMousePos()
    {
        var mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void PlacePiece(double posX, double posY)
    {
        posX = Math.Round(posX);
        posY = Math.Round(posY);
        // Debug.Log((int)posX + "," + (int)posY);
        if ((posX < 8) && (posY < 8) && (posX >= 0) && (posY >= 0) && (chessboard.getOccupied((int) posX, (int) posY) == 0)) 
        {
            transform.position = new Vector3((float)posX, (float)posY, 0);
            chessboard.setOccupiedTrue((int) posX, (int) posY);
            chessboard.setOccupiedFalse((int) initposX, (int)initposY);
        } 
            else
        {
            transform.position = new Vector3(initposX, initposY, 0);
        }
    }

    
}
