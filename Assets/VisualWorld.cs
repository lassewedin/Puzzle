using UnityEngine;

public class VisualWorld : MonoBehaviour {

    public GameObject cubePrefab;
    public bool showEmptySpaceCubelets = false;

    public Color colorEmpty;
    public Color[] colorPiece;

    public bool[] visible = new bool[6];

    private int[,,] logic = new int[6, 6, 6];
    private GameObject[,,] visual = new GameObject[6, 6, 6];

    private void Awake() {
        Clear();
        CreateCubes();
        SetAllVisible();
    }

    public void CreateCubes() {
        for (int z = 0; z < 6; z++) {
            for (int y = 0; y < 6; y++) {
                for (int x = 0; x < 6; x++) {
                    visual[x, y, z] = GameObject.Instantiate<GameObject>(cubePrefab);
                    visual[x, y, z].gameObject.SetActive(true);
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
                    logic[x, y, z] = -1; // empty
                }
            }
        }
    }

    public void SetAllVisible() {
        for (int z = 0; z < 6; z++) {
            visible[z] = true; // empty
        }
    }

    public int Get(int x, int y, int z) {
        return logic[x, y, z];
    }

    public void Set(int x, int y, int z, int index) {
        logic[x, y, z] = index;
    }

    public void Refresh(World world) {
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
                    if (logic[x, y, z] != -1 && (logic[x, y, z] > 5 || visible[logic[x, y, z]])) {
                        visual[x, y, z].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                        visual[x, y, z].gameObject.GetComponent<MeshRenderer>().material.color = colorPiece[logic[x, y, z]];
                        visual[x, y, z].gameObject.SetActive(true);
                    }
                    else {
                        visual[x, y, z].gameObject.SetActive(showEmptySpaceCubelets);
                        visual[x, y, z].gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                        visual[x, y, z].gameObject.GetComponent<MeshRenderer>().material.color = colorEmpty;
                    }
                }
            }
        }
    }
}
