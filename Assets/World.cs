using UnityEngine;

public class World {
    private int[,,] logic = new int[6, 6, 6];

    public World() {
        Clear();
    }

    public World(World space) {
        for (int z = 0; z < 6; z++) {
            for (int y = 0; y < 6; y++) {
                for (int x = 0; x < 6; x++) {
                    logic[x, y, z] = space.Get(x, y, z);
                }
            }
        }
    }

    public void Clear() {
        for (int z = 0; z < 6; z++) {
            for (int y = 0; y < 6; y++) {
                for (int x = 0; x < 6; x++) {
                    logic[x, y, z] = -1; //empty
                }
            }
        }
    }

    public int Get(int x, int y, int z) {
        return logic[x, y, z];
    }

    public void Set(int x, int y, int z, int index) {
        logic[x, y, z] = index;
    }
}
