using UnityEngine;

public class VisualWorld : MonoBehaviour {

    public GameObject cubePrefab;

    private int[,,] logic = new int[6, 6, 6];
    private GameObject[,,] visual = new GameObject[6, 6, 6];

    private void Awake() {
        Clear();
        CreateCubes();
    }

    public void CreateCubes() {
        for (int z = 0; z < 6; z++) {
            for (int y = 0; y < 6; y++) {
                for (int x = 0; x < 6; x++) {
                    visual[x, y, z] = GameObject.Instantiate<GameObject>(cubePrefab);
                    visual[x, y, z].transform.position = new Vector3(x, y, z);
                    visual[x, y, z].transform.parent = gameObject.transform;
                }
            }
        }
    }

    public void Clear() {
        for (int z = 0; z < 6; z++) {
            for (int y = 0; y < 6; y++) {
                for (int x = 0; x < 6; x++) {
                    logic[x, y, z] = 0;
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

    public void Set(World world) {
        for (int z = 0; z < 6; z++) {
            for (int y = 0; y < 6; y++) {
                for (int x = 0; x < 6; x++) {
                    logic[x, y, z] = world.Get(x, y, z);
                }
            }
        }
    }

    private void Update() {
        for (int z = 0; z < 6; z++) {
            for (int y = 0; y < 6; y++) {
                for (int x = 0; x < 6; x++) {
                    //visual[x, y, z].gameObject.SetActive(logic[x, y, z] != 0);
                    if (logic[x, y, z] != 0) {
                        visual[x, y, z].gameObject.transform.localScale = new Vector3(0.99f, 0.99f, 0.99f);
                    }
                    else {
                        visual[x, y, z].gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    }
                }
            }
        }
    }
}
