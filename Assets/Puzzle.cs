﻿using UnityEngine;

public class Puzzle : MonoBehaviour {
    public VisualWorld visualWorld;

    private Slot[] slot = new Slot[6];
    private Piece[] piece = new Piece[6];
    private bool[] usedPieces = new bool[6];

    void Start() {
        InitiatePuzzle();

        World testWorld = new World();
        slot[0].PlaceInWorld(piece[0], 0, 0, testWorld);

        visualWorld.Set(testWorld);
    }

    private void InitiatePuzzle() {
        CreateFreePieces();
        CreateSlots();
        CreatePieces();
    }

    private void CreateFreePieces() {
        for (int index = 0; index < 6; index++) {
            usedPieces[index] = false;
        }
    }

    private void CreateSlots() {
        {
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 1;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 2;
            slot[0] = new Slot(0, bt);
        }

        {
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 0;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 0;
            slot[1] = new Slot(1, bt);
        }

        {
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 0;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 0;
            slot[2] = new Slot(2, bt);
        }

        {
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 0;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 0;
            slot[3] = new Slot(3, bt);
        }

        {
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 0;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 0;
            slot[4] = new Slot(4, bt);
        }

        {
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 0;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 0;
            slot[5] = new Slot(5, bt);
        }
    }

    private void CreatePieces() {
        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 1; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1;
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 1; shape[3, 1, 0] = 1; shape[4, 1, 0] = 1; shape[5, 1, 0] = 1;
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 0; shape[2, 0, 1] = 0; shape[3, 0, 1] = 0; shape[4, 0, 1] = 0; shape[5, 0, 1] = 1;
            shape[0, 1, 1] = 1; shape[1, 1, 1] = 0; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1;

            piece[0] = new Piece(0, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 1; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1;
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 1; shape[3, 1, 0] = 1; shape[4, 1, 0] = 1; shape[5, 1, 0] = 1;
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 0; shape[2, 0, 1] = 0; shape[3, 0, 1] = 0; shape[4, 0, 1] = 0; shape[5, 0, 1] = 1;
            shape[0, 1, 1] = 1; shape[1, 1, 1] = 0; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1;

            piece[1] = new Piece(1, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 1; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1;
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 1; shape[3, 1, 0] = 1; shape[4, 1, 0] = 1; shape[5, 1, 0] = 1;
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 0; shape[2, 0, 1] = 0; shape[3, 0, 1] = 0; shape[4, 0, 1] = 0; shape[5, 0, 1] = 1;
            shape[0, 1, 1] = 1; shape[1, 1, 1] = 0; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1;

            piece[2] = new Piece(2, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 1; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1;
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 1; shape[3, 1, 0] = 1; shape[4, 1, 0] = 1; shape[5, 1, 0] = 1;
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 0; shape[2, 0, 1] = 0; shape[3, 0, 1] = 0; shape[4, 0, 1] = 0; shape[5, 0, 1] = 1;
            shape[0, 1, 1] = 1; shape[1, 1, 1] = 0; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1;

            piece[3] = new Piece(3, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 1; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1;
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 1; shape[3, 1, 0] = 1; shape[4, 1, 0] = 1; shape[5, 1, 0] = 1;
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 0; shape[2, 0, 1] = 0; shape[3, 0, 1] = 0; shape[4, 0, 1] = 0; shape[5, 0, 1] = 1;
            shape[0, 1, 1] = 1; shape[1, 1, 1] = 0; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1;

            piece[4] = new Piece(4, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 1; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1;
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 1; shape[3, 1, 0] = 1; shape[4, 1, 0] = 1; shape[5, 1, 0] = 1;
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 0; shape[2, 0, 1] = 0; shape[3, 0, 1] = 0; shape[4, 0, 1] = 0; shape[5, 0, 1] = 1;
            shape[0, 1, 1] = 1; shape[1, 1, 1] = 0; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1;

            piece[5] = new Piece(5, shape);
        }
    }

    private bool TryPlace(Slot slot, Piece piece, bool[] usedPieces, Space space) {


        return false;
    }



    private void PutPieceInWorld(World space, Slot slot, Piece piece, int rotateX, int rotateY) {

    }
}