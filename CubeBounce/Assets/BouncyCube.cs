using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCube : MonoBehaviour {

    protected MeshFilter MeshFilter;
    protected Mesh Mesh;

    public float UpDownFactor = 0.1f;
    public float UpDownSpeed = 6f;
    public float LeftFactor = 0.3f;
    public float LeftSpeed = 3f;
    public float LeftOffset = 2.3f;
    public float StretchFactor = -0.1f;
    public float StretchSpeed = 6f;


    // Start is called before the first frame update
    void Start() {
        Mesh = new Mesh();
        Mesh.name = "GeneratedMesh";

        Mesh.vertices = GenerateVerts();
        Mesh.triangles = GenerateTries();

        Mesh.RecalculateNormals();
        Mesh.RecalculateBounds();

        MeshFilter = gameObject.AddComponent<MeshFilter>();
        MeshFilter.mesh = Mesh;
    }

    private Vector3[] GenerateVerts(float up = 0f, float left = 0f, float stretch = 0f) {
        return new Vector3[] {
            // Bottom
            new Vector3(-1, 0 , 1),
            new Vector3(1, 0 , 1),
            new Vector3(1, 0 , -1),
            new Vector3(-1, 0 , -1),

            // Top
            new Vector3(-1 - stretch + left, 2 + up, 1 + stretch),
            new Vector3(1 + stretch + left, 2 + up, 1 + stretch),
            new Vector3(1 + stretch + left, 2 + up, -1 - stretch),
            new Vector3(-1 - stretch + left, 2 + up, -1 - stretch),

            // Left
            new Vector3(-1, 0, 1),
            new Vector3(-1, 0, -1),
            new Vector3(-1 - stretch + left, 2 + up, 1 + stretch),
            new Vector3(-1 - stretch + left, 2 + up, -1 - stretch),

            // Right
            new Vector3(1, 0, 1),
            new Vector3(1, 0, -1),
            new Vector3(1 + stretch + left, 2 + up, 1 + stretch),
            new Vector3(1 + stretch + left, 2 + up, -1 - stretch),

            // Front
            new Vector3(1, 0, -1),
            new Vector3(-1, 0, -1),
            new Vector3(1 + stretch + left, 2 + up, -1 - stretch),
            new Vector3(-1 - stretch + left, 2 + up, -1 - stretch),

            // Back
            new Vector3(-1, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(-1 - stretch + left, 2 + up, 1 + stretch),
            new Vector3(1 + stretch + left, 2 + up, 1 + stretch)
        };
    }

    private int[] GenerateTries() {
        return new int[] {
            // Bottom/Top
            1, 0, 2,
            2, 0, 3,
            4, 5, 6,
            4, 6, 7,

            // Left/Right
            9, 10, 11,
            8, 10, 9,
            12, 13, 15,
            14, 12, 15,

            // Front/Back
            16, 17, 19,
            18, 16, 19,
            20, 21, 23,
            22, 20, 23,
        };
    }

    // Update is called once per frame
    void Update() {
        
        Mesh.vertices = GenerateVerts(Mathf.Sin(Time.realtimeSinceStartup * UpDownSpeed) * UpDownFactor,
                                      Mathf.Sin(Time.realtimeSinceStartup * LeftSpeed + LeftOffset) * LeftFactor,
                                      Mathf.Sin(Time.realtimeSinceStartup * StretchSpeed) * StretchFactor);
    }
}
