using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public static int[,] isOccupied = new int[8, 8];
    private float initposX, initposY;
    Pawn pawn = new Pawn();
    Queen queen = new Queen();
    Rook rook = new Rook();
    Bishop bishop = new Bishop();  
    Knight knight = new Knight();
    King king = new King();
    [SerializeField] private ContactFilter2D mask;
    [SerializeField] private Material baseColour, offsetColour, altColour;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] private GameObject WPawn, WBishop, WKnight, WRook, WQueen, WKing, BPawn, BBishop, BKnight, BRook, BQueen, BKing;
    private Pawn _pawnscript;
    private Knight _knightscript;
    private Bishop _bishopscript;
    private Rook _rookscript;
    private Queen _queenscript;
    private King _kingscript;

    public GameObject[,] tiles = new GameObject[8, 8];

    public ChessBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            isOccupied[i, 1] = 1;
        }

        for (int i = 0; i < 8; i++)
        {
            isOccupied[i, 6] = 1;
        }

        for (int i = 0; i < 8; i += 7)
        {
            isOccupied[i, 0] = 1;
        }

        for (int i = 0; i < 8; i += 7)
        {
            isOccupied[i, 7] = 1;
        }

        for (int i = 1; i < 8; i += 5)
        {
            isOccupied[i, 0] = 1;
        }

        for (int i = 1; i < 8; i += 5)
        {
            isOccupied[i, 7] = 1;
        }

        for (int i = 2; i < 8; i += 3)
        {
            isOccupied[i, 0] = 1;
        }

        for (int i = 2; i < 8; i += 3)
        {
            isOccupied[i, 7] = 1;
        }

        isOccupied[3, 0] = 1;
        isOccupied[3, 7] = 1;

        isOccupied[4, 0] = 1;
        isOccupied[4, 7] = 1;
    }
    private void Awake()
    {
        GenerateTiles(1, 8, 8);
        GeneratePieces();
    }

    public void setOccupiedFalse(int x, int y)
    {
        isOccupied[x, y] = 0;
      /*  Debug.Log($"Prev: {x}, {y}:" + isOccupied[x, y]);
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                Debug.Log(i + "," + j + ":" + isOccupied[i, j]); */
    }

    public void setOccupiedTrue(int x, int y)
    {
        isOccupied[x, y] = 1;
       //  Debug.Log($"After {x}, {y}: " + isOccupied[x, y]);
       

    }

    public int getOccupied(int x, int y)
    {
       // Debug.Log(x + "," + y + ":" + this.isOccupied[x, y]);
        return isOccupied[x, y];

    }

    private void GenerateTiles(float TileSize, int tilecountX, int tilecountY)
    {
        _cam.transform.position = new Vector3(tilecountX / 2 - 0.5f, tilecountY / 2 - 0.5f, -10);
        for (int x = 0; x < tilecountX; x++)
        {
            for (int y = 0; y < tilecountY; y++)
            {
                tiles[x, y] = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                tiles[x, y].transform.SetParent(gameObject.transform);
                tiles[x, y].name = $"x:{x}, y:{y}";

                if ((x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0))
                {
                    tiles[x, y].GetComponent<Renderer>().material = baseColour;
                } else
                {
                    tiles[x, y].GetComponent<Renderer>().material = offsetColour;
                }
            }
        }
    }

    private void GeneratePieces()
    {
        // white pawns
        for (int i = 0; i < 8; i++)
        {
            GameObject WPawnSpawn = Instantiate(WPawn, tiles[i, 1].transform.position, Quaternion.identity);
            WPawnSpawn.name = $"WPawn{i}";
            _pawnscript = WPawnSpawn.GetComponent<Pawn>();
            _pawnscript.setPawn(true, true);
            
            
        }

        // black pawns
        for (int i = 0; i < 8; i++)
        {
            GameObject BPawnSpawn = Instantiate(BPawn, tiles[i, 6].transform.position, Quaternion.identity);
            BPawnSpawn.name = $"BPawn{i}";
            _pawnscript = BPawnSpawn.GetComponent<Pawn>();
            _pawnscript.setPawn(true, false);
        }

        // white rooks
        for (int i = 0; i < 8; i += 7)
        {
            GameObject WRookSpawn = Instantiate(WRook, tiles[i, 0].transform.position, Quaternion.identity);
            WRookSpawn.name = $"WRook{i}";
            _rookscript = WRookSpawn.GetComponent<Rook>();
            _rookscript.setRook(true, true);
        }

        // black rooks
        for (int i = 0; i < 8; i += 7)
        {
            GameObject BRookSpawn = Instantiate(BRook, tiles[i, 7].transform.position, Quaternion.identity);
            BRookSpawn.name = $"BRook{i}";
            _rookscript = BRookSpawn.GetComponent<Rook>();
            _rookscript.setRook(true, false);
        }

        // white knights
        for (int i = 1; i < 8; i += 5)
        {
            GameObject WKnightSpawn = Instantiate(WKnight, tiles[i, 0].transform.position, Quaternion.identity);
            WKnightSpawn.name = $"WKnight{i}";
            _knightscript = WKnightSpawn.GetComponent<Knight>();
            _knightscript.setKnight(true, true);
        }

        // black knights
        for (int i = 1; i < 8; i += 5)
        {
            GameObject BKnightSpawn = Instantiate(BKnight, tiles[i, 7].transform.position, Quaternion.identity);
            BKnightSpawn.name = $"BKnight{i}";
            _knightscript = BKnightSpawn.GetComponent<Knight>();
            _knightscript.setKnight(true, false);
        }

        for (int i = 2; i < 8; i += 3)
        {
            GameObject WBishopSpawn = Instantiate(WBishop, tiles[i, 0].transform.position, Quaternion.identity);
            WBishopSpawn.name = $"WBishop{i}";
            _bishopscript = WBishopSpawn.GetComponent<Bishop>();
            _bishopscript.setBishop(true, true);
        }

        for (int i = 2; i < 8; i += 3)
        {
            GameObject BBishopSpawn = Instantiate(BBishop, tiles[i, 7].transform.position, Quaternion.identity);
            BBishopSpawn.name = $"BBishop{i}";
            _bishopscript = BBishopSpawn.GetComponent<Bishop>();
            _bishopscript.setBishop(true, false);
        }

        GameObject WQueenSpawn = Instantiate(WQueen, tiles[3, 0].transform.position, Quaternion.identity);
        WQueenSpawn.name = "WQueen";
        _queenscript = WQueenSpawn.GetComponent<Queen>();
        _queenscript.setQueen(true, true);

        GameObject BQueenSpawn = Instantiate(BQueen, tiles[3, 7].transform.position, Quaternion.identity);
        BQueenSpawn.name = "BQueen";
        _queenscript = BQueenSpawn.GetComponent<Queen>();
        _queenscript.setQueen(true, false);

        GameObject WKingSpawn = Instantiate(WKing, tiles[4, 0].transform.position, Quaternion.identity);
        WKingSpawn.name = "WKing";
        _kingscript = WKingSpawn.GetComponent<King>();
        _kingscript.setKing(true, true);

        GameObject BKingSpawn = Instantiate(BKing, tiles[4, 7].transform.position, Quaternion.identity);
        BKingSpawn.name = "BKing";
        _kingscript = BKingSpawn.GetComponent<King>();
        _kingscript.setKing(true, false);

    }

        public Vector3 getTilePosition(int x, int y)
    {
        return GameObject.Find($"x:{x}, y:{y}").transform.position;
    }
}
