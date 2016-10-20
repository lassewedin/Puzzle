using UnityEngine;

public class Puzzle : MonoBehaviour {
    public VisualWorld visualWorld;

    private Slot[] slots = new Slot[6];
    private PieceSet pieceSet = new PieceSet();

    private World world = new World();

    void Start() {
        InitiatePuzzle();

        //World testWorld = new World();
        //bool can0 = slot[0].TryPlaceInWorld(PieceSet.GetPiece(4), 0, 0, world);
        //bool can1 = slot[1].TryPlaceInWorld(PieceSet.GetPiece(5), 0, 0, world);

        //bool can2 = slot[2].TryPlaceInWorld(PieceSet.GetPiece(0), 0, 1, world);
        //slot[2].ForcePlaceInWorld(piece[0], 0, 1, testWorld);
        visualWorld.Set(world);

        if (TryFillSlot(slots[0], pieceSet, world)) {
            Debug.Log("Piece of cake!");
        }
        else {
            Debug.Log("No can do!");
        }
    }

    private bool TryFillSlot(Slot slot, PieceSet pieceSet, World world) {
        for (int pieceIndex = 0; pieceIndex < 6; pieceIndex++) {
            if (pieceSet.IsAvailable(pieceIndex)) {
                for (int rotateY = 0; rotateY < 1; rotateY++) {
                    for (int rotateX = 0; rotateX < 4; rotateX++) {
                        if (slot.CanPlaceInWorld(PieceSet.GetPiece(pieceIndex), rotateY, rotateX, world)) {
                            //push
                            Slot subSlot = slots[slot.index + 1];
                            PieceSet subPieceSet = new PieceSet(pieceSet);
                            subPieceSet.SetAvailable(pieceIndex, false);
                            World subWorld = new World(world);
                            bool ok = slot.TryPlaceInWorld(PieceSet.GetPiece(pieceIndex), rotateY, rotateX, subWorld);
                            if (!ok) {
                                Debug.Log("Ooooops!");
                            }
                            visualWorld.Set(subWorld);
                            visualWorld.ForceUpdate();
                            if (subSlot.index > 5) {
                                return true;
                            }
                            if (TryFillSlot(subSlot, subPieceSet, subWorld)) {
                                return true;
                            }
                            //pop
                        }
                    }
                }
            }
        }
        return false;
    }

    private void InitiatePuzzle() {
        CreateSlots();
    }

    private void CreateSlots() {
        {
            //x bottom
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 1;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 2;
            slots[0] = new Slot(0, bt);
        }

        {
            //x top
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 1; bt.yAxisWorldX = 0; bt.zAxisWorldX = 0; bt.origoWorldX = 0;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0; bt.origoWorldY = 3;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 1; bt.origoWorldZ = 2;
            slots[1] = new Slot(1, bt);
        }

        {
            //y near
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 0; bt.yAxisWorldX = -1; bt.zAxisWorldX = 0; bt.origoWorldX = 3;
            bt.xAxisWorldY = 1; bt.yAxisWorldY = 0;  bt.zAxisWorldY = 0; bt.origoWorldY = 0;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0;  bt.zAxisWorldZ = 1; bt.origoWorldZ = 1;
            slots[2] = new Slot(2, bt);
        }

        {
            //y far
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 0; bt.yAxisWorldX = -1; bt.zAxisWorldX = 0; bt.origoWorldX = 3;
            bt.xAxisWorldY = 1; bt.yAxisWorldY = 0;  bt.zAxisWorldY = 0; bt.origoWorldY = 0;
            bt.xAxisWorldZ = 0; bt.yAxisWorldZ = 0;  bt.zAxisWorldZ = 1; bt.origoWorldZ = 3;
            slots[3] = new Slot(3, bt);
        }

        {
            //z left
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 0;  bt.yAxisWorldX = 0; bt.zAxisWorldX = -1; bt.origoWorldX = 2;
            bt.xAxisWorldY = 0;  bt.yAxisWorldY = 1; bt.zAxisWorldY = 0;  bt.origoWorldY = 2;
            bt.xAxisWorldZ = 1;  bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 0;  bt.origoWorldZ = 0;
            slots[4] = new Slot(4, bt);
        }

        {
            //z right
            BaseTransform bt = new BaseTransform();
            bt.xAxisWorldX = 0; bt.yAxisWorldX = 0; bt.zAxisWorldX = -1; bt.origoWorldX = 4;
            bt.xAxisWorldY = 0; bt.yAxisWorldY = 1; bt.zAxisWorldY = 0;  bt.origoWorldY = 2;
            bt.xAxisWorldZ = 1; bt.yAxisWorldZ = 0; bt.zAxisWorldZ = 0;  bt.origoWorldZ = 0;
            slots[5] = new Slot(5, bt);
        }
    }
}
