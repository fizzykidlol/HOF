using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {


    private GameObject[] EnvironmentObjects;
    public Mesh[] EnvironmentMeshes;

	// Use this for initialization
	void Start () {
        EnvironmentObjects = GameObject.FindGameObjectsWithTag("test");
        EnvironmentMeshes = new Mesh[EnvironmentObjects.Length];

        for (int i = 0; i < EnvironmentObjects.Length; i++)
        {
            EnvironmentMeshes[i] = EnvironmentObjects[i].GetComponent<MeshFilter>().mesh;
        }
	}

    // Update is called once per frame
    void Update()
    {
        cullPlanes();
    }

    public void cullPlanes()
    {
        Vector3 eyeVector = Camera.main.transform.forward;
        foreach (Mesh mesh in EnvironmentMeshes)
        {
            List<int> triangles = new List<int>();

            for (int i = 0; i < mesh.triangles.Length; i = i + 3)
            {
                Vector3 v0 = mesh.vertices[mesh.triangles[i + 0]];
                Vector3 v1 = mesh.vertices[mesh.triangles[i + 1]];
                Vector3 v2 = mesh.vertices[mesh.triangles[i + 2]];

                Vector3 s0 = v1 - v0;
                Vector3 s1 = v2 - v0;

                Vector3 crossProduct = Vector3.Cross(s1, s0);

                float dotProduct = Vector3.Dot(eyeVector, crossProduct);

                if (dotProduct > 0.0f)
                {
                    triangles.Add(mesh.triangles[i + 0]);
                    triangles.Add(mesh.triangles[i + 1]);
                    triangles.Add(mesh.triangles[i + 2]);
                }
            }

            mesh.triangles = triangles.ToArray();
        }
    }
}
