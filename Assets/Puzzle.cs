using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {
    public VisualWorld visualWorld;

    private Slot[] slots = new Slot[6];
    private PieceSet pieceSet = new PieceSet();

    private World world = new World();

    void Start() {
        InitiatePuzzle();
        visualWorld.Refresh(world);
        GenerateAllCombinations();
        startTime = Time.realtimeSinceStartup;
    }

    private bool done = false;
    private int sulotionIndex = 0;
    private int piecePlacedRecord = 0;
    private World recordWorld;
    private float startTime;

    private const int solutionLimit = 6;
    private const int orientationsPerPiece = 8;

    private PieceInPosition jammerPiece;

    public bool enableSkip = false;

    private void FixedUpdate() {
        if (solutionList.Count == 0 || done) {
            return;
        }

        bool skip = false;
        do {
            skip = false;
            if (sulotionIndex < solutionList.Count) {
                PieceInPosition[] solution = solutionList[sulotionIndex];


                if (jammerPiece != null && enableSkip) {
                    PieceInPosition possibleJammerPiece = solution[jammerPiece.slotIndex];
                    if (possibleJammerPiece.pieceIndex == jammerPiece.pieceIndex && possibleJammerPiece.rotationY == jammerPiece.rotationY && possibleJammerPiece.rotationX == jammerPiece.rotationX) {
                        skip = true;
                    }
                    else {
                        jammerPiece = null;
                    }
                }

                if (!skip) {
                    world.Clear();
                    bool wasted = false;
                    for (int slotIndex = 0; slotIndex < 6; slotIndex++) {
                        bool couldPlace = slots[slotIndex].CanPlaceInWorld(PieceSet.GetPiece(solution[slotIndex].pieceIndex), solution[slotIndex].rotationY, solution[slotIndex].rotationX, world);
                        slots[slotIndex].ForcePlaceInWorld(PieceSet.GetPiece(solution[slotIndex].pieceIndex), solution[slotIndex].rotationY, solution[slotIndex].rotationX, world, wasted || !couldPlace);
                        if (!couldPlace || wasted) {
                            if (!wasted) {
                                jammerPiece = solution[slotIndex];
                                jammerPiece.slotIndex = slotIndex;
                            }
                            wasted = true;
                            if (enableSkip) {
                                break;
                            }
                        }
                        else {
                            if (slotIndex + 1 > piecePlacedRecord) {
                                piecePlacedRecord = slotIndex + 1;
                                recordWorld = new World(world);

                                if (piecePlacedRecord == solutionLimit) {
                                    break;
                                }
                            }
                        }
                    }
                }

                sulotionIndex++;
                if (sulotionIndex % 100 == 0) {
                    float timeElapsed = Time.realtimeSinceStartup - startTime;
                    float timeLeft = (((float)solutionList.Count / (float)sulotionIndex) * timeElapsed - timeElapsed) / 60f;
                    Debug.Log("Checking combination: " + sulotionIndex + " of " + solutionList.Count + ", Checked: " + 100f * ((float)sulotionIndex / (float)solutionList.Count) + " %, Record: " + piecePlacedRecord + " pieces, Estimated time left: < " + (timeLeft < 60 ? timeLeft + " minutes" : timeLeft / 60f + " hours"));
                }

                if (piecePlacedRecord == solutionLimit) {
                    Debug.Log("Yey!! :) Solution found!!");
                    done = true;
                }

                visualWorld.Refresh(world);
            }
            else {
                Debug.Log("This puzzle is Shit! Every possible combination tried (" + solutionList.Count + "). Could only place " + piecePlacedRecord + " pieces. One of the best solutions is shown.");
                visualWorld.Refresh(recordWorld);
                done = true;
            }
        } while (skip);
    }

    public List<PieceInPosition[]> solutionList = new List<PieceInPosition[]>();

    //find all possible combinations
    public void GenerateAllCombinations() {
        Debug.Log("Generating Combinations...");
        int combinationCount = 5 * 4 * 3 * 2 * orientationsPerPiece * orientationsPerPiece * orientationsPerPiece * orientationsPerPiece * orientationsPerPiece;

        int[] pieceAtSlot = new int[6];
        pieceAtSlot[0] = 0;
        for (pieceAtSlot[1] = 0; pieceAtSlot[1] < 6; pieceAtSlot[1]++) {
            for (pieceAtSlot[2] = 0; pieceAtSlot[2] < 6; pieceAtSlot[2]++) {
                for (pieceAtSlot[3] = 0; pieceAtSlot[3] < 6; pieceAtSlot[3]++) {
                    for (pieceAtSlot[4] = 0; pieceAtSlot[4] < 6; pieceAtSlot[4]++) {
                        for (pieceAtSlot[5] = 0; pieceAtSlot[5] < 6; pieceAtSlot[5]++) {
                            if (isPermutation(pieceAtSlot)) { //OK!!! :)
                                int[] orientationAtSlot = new int[6];
                                
                                orientationAtSlot[0] = 0;
                                for (orientationAtSlot[1] = 0; orientationAtSlot[1] < orientationsPerPiece; orientationAtSlot[1]++) {
                                    for (orientationAtSlot[2] = 0; orientationAtSlot[2] < orientationsPerPiece; orientationAtSlot[2]++) {
                                        for (orientationAtSlot[3] = 0; orientationAtSlot[3] < orientationsPerPiece; orientationAtSlot[3]++) {
                                            for (orientationAtSlot[4] = 0; orientationAtSlot[4] < orientationsPerPiece; orientationAtSlot[4]++) {
                                                for (orientationAtSlot[5] = 0; orientationAtSlot[5] < orientationsPerPiece; orientationAtSlot[5]++) {
                                                    PieceInPosition[] solution = new PieceInPosition[6];
                                                    for (int slotIndex = 0; slotIndex < 6; slotIndex++) {
                                                        solution[slotIndex] = new PieceInPosition(pieceAtSlot[slotIndex], GetOrientation(orientationAtSlot[slotIndex])[0], GetOrientation(orientationAtSlot[slotIndex])[1]);
                                                    }
                                                    solutionList.Add(solution);
                                                }
                                            }
                                        }
                                    }
                                }
                                
                                Debug.Log("Generating Combination: " + solutionList.Count + " of " + combinationCount + " (" + 100f * ((float)solutionList.Count / (float)combinationCount) + "%)");
                            }
                        }
                    }
                }
            }
        }

        Debug.Log("All " + solutionList.Count + " combinations generated...");
    }

    //rewturn Y, X
    private int[] GetOrientation(int index) {
        int[] orientation = new int[2];
        switch (index) {
            case 0:
                orientation[0] = 0; orientation[1] = 0;
                break;
            case 1:
                orientation[0] = 0; orientation[1] = 1;
                break;
            case 2:
                orientation[0] = 0; orientation[1] = 2;
                break;
            case 3:
                orientation[0] = 0; orientation[1] = 3;
                break;
            case 4:
                orientation[0] = 1; orientation[1] = 0;
                break;
            case 5:
                orientation[0] = 1; orientation[1] = 1;
                break;
            case 6:
                orientation[0] = 1; orientation[1] = 2;
                break;
            case 7:
                orientation[0] = 1; orientation[1] = 3;
                break;
        }
        return orientation;
    }

    private bool isPermutation(int[] place) {
        bool[] hasAllready = new bool[6];
        for (int index = 0; index < 6; index++) {
            if (hasAllready[place[index]]) {
                return false;
            }
            hasAllready[place[index]] = true;
        }

        return true;
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

        /* private bool solved = false;
     private int tries = 0;
     private void FixedUpdate() {
         if (solved) {
             return;
         }
         if (tries % 1000 == 0) {
             Debug.Log("Tries: " + tries);
         }
         tries++;


         int[] piecePermutation = CreateRandomPermutation();

         for (int slotIndex = 0; slotIndex < 6; slotIndex++) {
             Slot slot = slots[slotIndex];
             int pieceIndex = piecePermutation[slotIndex];
             Piece piece = PieceSet.GetPiece(pieceIndex);

             int rotateY = RandomInt(1);
             int rotateX = RandomInt(3);

             bool ok = slot.TryPlaceInWorld(PieceSet.GetPiece(pieceIndex), rotateY, rotateX, world);
             if (!ok) {

                 visualWorld.Set(new World(world));
                 world.Clear();
                 return;
             }         
         }
         visualWorld.Set(world);
         solved = true;

     }

     private int[] CreateRandomPermutation() {
         int[] sequence = new int[6];
         bool[] taken = new bool[6];
         int index = 0;

         while (index < 6) {
             int random = RandomInt(5);
             if (!taken[random]) {
                 sequence[index] = random;
                 index++;
                 taken[random] = true;
             }
         }
         return sequence;
     }

     private int RandomInt(int max) {
         return (int)Random.Range(0f, max + 0.99f);
     }




     private bool TryFillSlot(Slot slot, PieceSet pieceSet, World world) {
         for (int pieceIndex = 0; pieceIndex < 6; pieceIndex++) {
             if (pieceSet.IsAvailable(pieceIndex)) {
                 for (int rotateY = 0; rotateY < 1; rotateY++) {
                     for (int rotateX = 0; rotateX < 4; rotateX++) {
                         if (slot.CanPlaceInWorld(PieceSet.GetPiece(pieceIndex), rotateY, rotateX, world)) {
                             //push
                             World subWorld = new World(world);
                             bool ok = slot.TryPlaceInWorld(PieceSet.GetPiece(pieceIndex), rotateY, rotateX, subWorld);
                             visualWorld.Set(subWorld);

                             if (slot.index >= 4) {
                                 return true;
                             }
                             else {
                                 Slot subSlot = slots[slot.index + 1];
                                 PieceSet subPieceSet = new PieceSet(pieceSet);
                                 subPieceSet.SetAvailable(pieceIndex, false);


                                 if (TryFillSlot(subSlot, subPieceSet, subWorld)) {
                                     return true;
                                 }
                             }
                             //pop
                         }
                     }
                 }
             }
         }
         return false;
     } */
}
