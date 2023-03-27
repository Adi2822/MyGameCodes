using UnityEngine;
using System;
using System.Collections.Generic;

namespace Chess.Scripts.Core
{
    public class ChessPlayerPlacementHandler : MonoBehaviour
    {

        [SerializeField] public int row, column;

        private int Boardlength = 8;
        public enum Type { Knight, Pawn, King, Queen, Bishop, Rook }; // Used for switch case
        public Type currttype;
        public int startrow = 1;
        public int[,] integer =
        {
            { 1,0 },{ -1,0 },{ 1,1 },{ 1,-1 },{ -1, 1 },{ 0, 1},{ 0, -1},{ -1, -1} //directions for kingMoves
        };
        public static GameObject[,] refpiece = new GameObject[8, 8]; // array containing reference of objects who have occupied squares on the chessboard as per their index

        public static List<Vector2Int> Occupiedtiles = new List<Vector2Int>();


        //internal static ChessPlayerPlacementHandler Instance;


        private void Start()
        {
            refpiece[row, column] = this.gameObject;
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            Occupiedtiles.Add(new Vector2Int(row, column)); // Adding positons of occupied squares
            //Debug.Log(row * 7 + column);
        }

        public void Checkenemy(int row, int column)
        {
            GameObject temp = refpiece[row, column];

            if (temp != null)
            {
                if (temp.tag != this.tag)
                {
                    ChessBoardPlacementHandler.Instance.HighlightEnemy(row, column); // Displaying possible attack move with a red marker
                }
            }
        }

        //Move Functions
        public void Rightmov()
        {
            for (int l = 1; l <= Boardlength; l++)

            {
                if (column + l < 8 && !Occupiedtiles.Contains(new Vector2Int(row, column + l)))
                {

                    ChessBoardPlacementHandler.Instance.Highlight(row, column + l);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row, column + l)))
                {
                    Checkenemy(row, column + l);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void Leftmov()
        {
            for (int l = 1; l <= Boardlength; l++)

            {
                if (column - l >= 0 && !Occupiedtiles.Contains(new Vector2Int(row, column - l)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row, column - l);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row, column - l)))
                {
                    Checkenemy(row, column - l);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void movUp()
        {
            for (int l = 1; l <= Boardlength; l++)

            {

                if (row + l < 8 && !Occupiedtiles.Contains(new Vector2Int(row + l, column)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row + l, column);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row + l, column)))
                {
                    Checkenemy(row + l, column);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void movDown()
        {
            for (int l = 1; l <= Boardlength; l++)

            {
                if (row - l >= 0 && !Occupiedtiles.Contains(new Vector2Int(row - l, column)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row - l, column);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row - l, column)))
                {
                    Checkenemy(row - l, column);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void movTopright()
        {
            for (int l = 1; l <= Boardlength; l++)

            {
                if (row + l < 8 && column + l < 8 && !Occupiedtiles.Contains(new Vector2Int(row + l, column + l)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row + l, column + l);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row + l, column + l)))
                {
                    Checkenemy(row + l, column + l);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void movTopleft()
        {
            for (int l = 1; l <= Boardlength; l++)

            {
                if (row + l < 8 && column - l >= 0 && !Occupiedtiles.Contains(new Vector2Int(row + l, column - l)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row + l, column - l);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row + l, column - l)))
                {
                    Checkenemy(row + l, column - l);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void movBottomright()
        {
            for (int l = 1; l <= Boardlength; l++)

            {
                if (row - l >= 0 && column + l < 8 && !Occupiedtiles.Contains(new Vector2Int(row - l, column + l)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row - l, column + l);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row - l, column + l)))
                {
                    Checkenemy(row - l, column + l);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void movBottomleft()
        {
            for (int l = 1; l <= Boardlength; l++)

            {
                if (row - l >= 0 && column - l >= 0 && !Occupiedtiles.Contains(new Vector2Int(row - l, column - l)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row - l, column - l);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row - l, column - l)))
                {
                    Checkenemy(row - l, column - l);
                    return;
                }
                else
                {
                    return;
                }
            }

        }
        public void KnightMov1()
        {
            if (row + 2 < 8 && column - 1 >= 0 && !Occupiedtiles.Contains(new Vector2Int(row + 2, column - 1)))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row + 2, column - 1);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row + 2, column - 1)))
            {
                Checkenemy(row + 2, column - 1);
            }

        }
        public void KnightMov2()
        {
            if (row + 2 < 8 && column + 1 < 8 && !Occupiedtiles.Contains(new Vector2Int(row + 2, column + 1)))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row + 2, column + 1);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row + 2, column + 1)))
            {
                Checkenemy(row + 2, column + 1);
            }
        }
        public void KnightMov3()
        {
            if (row - 2 >= 0 && column + 1 < 8 && !Occupiedtiles.Contains(new Vector2Int(row - 2, column + 1)))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row - 2, column + 1);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row - 2, column + 1)))
            {
                Checkenemy(row - 2, column + 1);
            }

        }
        public void KnightMov4()
        {
            if (row - 2 >= 0 && column - 1 >= 0 && !Occupiedtiles.Contains(new Vector2Int(row - 2, column - 1)))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row - 2, column - 1);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row - 2, column - 1)))
            {
                Checkenemy(row - 2, column - 1);
            }
        }
        public void KnightMov5()
        {
            if (row - 1 >= 0 && column - 2 >= 0 && !Occupiedtiles.Contains(new Vector2Int(row - 1, column - 2)))
            {
               
                ChessBoardPlacementHandler.Instance.Highlight(row - 1, column - 2);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row - 1, column - 2)))
            {
                Checkenemy(row - 1, column - 2);
            }

        }
        public void KnightMov6()
        {

            if (row + 1 < 8 && column - 2 >= 0 && !Occupiedtiles.Contains(new Vector2Int(row + 1, column - 2)))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row + 1, column - 2);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row + 1, column - 2)))
            {
                Checkenemy(row + 1, column - 2);
            }
        }
        public void KnightMov7()
        {
            if (row - 1 >= 0 && column + 2 < 8 && !Occupiedtiles.Contains(new Vector2Int(row - 1, column + 2)))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row - 1, column + 2);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row - 1, column + 2)))
            {
                Checkenemy(row - 1, column + 2);
            }
        }
        public void KnightMov8()
        {
            if (row + 1 < 8 && column + 2 < 8 && !Occupiedtiles.Contains(new Vector2Int(row + 1, column + 2)))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row + 1, column + 2);
            }
            else if (Occupiedtiles.Contains(new Vector2Int(row + 1, column + 2)))
            {
                Checkenemy(row + 1, column + 2);
            }
        }
        public void PawnMove()
        {
            if (this.tag == "EnemyPiece")
            {
                if (row - 1 < 8 && !Occupiedtiles.Contains(new Vector2Int(row - 1, column)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row - 1, column);

                    if (row == startrow && !Occupiedtiles.Contains(new Vector2Int(row - 2, column)))
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(row - 2, column);
                    }

                }
                if (checkbound(row - 1) && checkbound(column - 1) && Occupiedtiles.Contains(new Vector2Int(row - 1, column - 1)))
                {
                    Checkenemy(row - 1, column - 1);
                }
                if (checkbound(row - 1) && checkbound(column + 1) && Occupiedtiles.Contains(new Vector2Int(row - 1, column + 1)))
                {
                    Checkenemy(row - 1, column + 1);
                }

            }
            else
            {
                if (row + 1 < 8 && !Occupiedtiles.Contains(new Vector2Int(row + 1, column)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row + 1, column);
                    if (row == startrow && !Occupiedtiles.Contains(new Vector2Int(row + 2, column)))
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(row + 2, column);
                    }

                }
                if (checkbound(row + 1) && checkbound(column - 1) && Occupiedtiles.Contains(new Vector2Int(row + 1, column - 1)))
                {
                    Checkenemy(row + 1, column - 1);
                }
                if (checkbound(row + 1) && checkbound(column + 1) && Occupiedtiles.Contains(new Vector2Int(row + 1, column + 1)))
                {
                    Checkenemy(row + 1, column + 1);
                }
            }
        }
        public void KingMove()
        {
            for (int a = 0; a < 8; a++)
            {
                int r, c;
                r = integer[a, 0];
                c = integer[a, 1];
                if (checkbound(row + r) && checkbound(column + c) && !Occupiedtiles.Contains(new Vector2Int(row + r, column + c)))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(row + r, column + c);
                }
                else if (Occupiedtiles.Contains(new Vector2Int(row + r, column + c)))
                {
                    Checkenemy(row + r, column + c);
                }

            }
        }

        public bool checkbound(int boun) // to check if the position is on Board
        {
            if (boun >= 0 && boun < 8)
            {
                return true;
            }
            return false;
        }

        public void OnMouseDown() 
        {


            switch (currttype)
            {
                case Type.Knight:
                    ChessBoardPlacementHandler.Instance.ClearHighlights();
                    KnightMov1();
                    KnightMov2();
                    KnightMov3();
                    KnightMov4();
                    KnightMov5();
                    KnightMov6();
                    KnightMov7();
                    KnightMov8();
                    break;

                case Type.Pawn:
                    ChessBoardPlacementHandler.Instance.ClearHighlights();
                    PawnMove();
                    break;

                case Type.King:
                    ChessBoardPlacementHandler.Instance.ClearHighlights();
                    KingMove();
                    break;

                case Type.Queen:
                    ChessBoardPlacementHandler.Instance.ClearHighlights();
                    Rightmov();
                    Leftmov();
                    movDown();
                    movUp();
                    movTopright();
                    movTopleft();
                    movBottomright();
                    movBottomleft();
                    break;

                case Type.Rook:
                    ChessBoardPlacementHandler.Instance.ClearHighlights();
                    Rightmov();
                    Leftmov();
                    movDown();
                    movUp();

                    break;

                case Type.Bishop:
                    ChessBoardPlacementHandler.Instance.ClearHighlights();
                    movTopleft();
                    movTopright();
                    movBottomleft();
                    movBottomright();

                    break;

            }


        }






    }
}