using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshCombiner : MonoBehaviour {



    public void simpleMerge()
    {
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;
        
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        Debug.Log(name + " is merging " + filters.Length + " mesh filters");

        Mesh finalMesh = new Mesh();

        CombineInstance[] combiners = new CombineInstance[filters.Length];

        for (int i = 0; i < filters.Length; i++)
        {
            if (filters[i].transform == transform)
            {
                continue;
            }
            combiners[i] = new CombineInstance();
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }

        finalMesh.CombineMeshes(combiners, true);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void advancedMerge()
    {
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>(false);

        Debug.Log(name + " is merging " + filters.Length + " mesh filters");

        Mesh finalMesh = new Mesh();
        MeshFilter myMeshFilter = GetComponent<MeshFilter>();

        List<Material> materials = new List<Material>();
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(false);

        foreach (MeshRenderer renderer in renderers)
        {
            if (renderer.transform == transform)
            {
                continue;
            }

            Material[] localMats = renderer.sharedMaterials;
            foreach(Material localMat in localMats)
            {
                if (!materials.Contains(localMat))
                {
                    materials.Add(localMat);
                }
            }
        }

        Debug.Log(materials.Count + "materials");

        List<Mesh> submeshes = new List<Mesh>();

        foreach(Material material in materials)
        {
            List<CombineInstance> combiners = new List<CombineInstance>();
            foreach (MeshFilter filter in filters)
            {
                MeshRenderer renderer = filter.GetComponent<MeshRenderer>();
                if (renderer == null)
                {
                    Debug.LogError(filter.name + " has no Mesh Renderer");
                    continue;
                }

                Material[] localMats = renderer.sharedMaterials;
                for (int materialIndex = 0; materialIndex < localMats.Length; materialIndex++)
                {
                    if (localMats[materialIndex] != material)
                        continue;

                    CombineInstance ci = new CombineInstance();
                    ci.mesh = filter.sharedMesh;
                    ci.subMeshIndex = materialIndex;
                    ci.transform = filter.transform.localToWorldMatrix;
                    combiners.Add(ci);
                }
            }
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combiners.ToArray(), true);
            submeshes.Add(mesh);
        }

        List<CombineInstance> finalCombiners = new List<CombineInstance>();

        foreach (Mesh mesh in submeshes)
        {
            CombineInstance ci = new CombineInstance();
            ci.mesh = mesh;
            ci.subMeshIndex = 0;
            ci.transform = Matrix4x4.identity;
            finalCombiners.Add(ci);
        }

        finalMesh.CombineMeshes(finalCombiners.ToArray(), false);
        myMeshFilter.sharedMesh = finalMesh;
        Debug.Log("Final mesh has " + submeshes.Count + " materials");
        MeshRenderer mr = GetComponent<MeshRenderer>();

        transform.rotation = oldRot;
        transform.position = oldPos;
        transform.localScale = new Vector3(1, 1, 1);

        mr.sharedMaterials = materials.ToArray();
    }

    public void addBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>();
    }

    public void addMeshCollider()
    {
        gameObject.AddComponent<MeshCollider>();
    }

    public void deleteAllChildren()
    {

        GameObject[] children = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject child in children)
        {
            DestroyImmediate(child);
        }
    }
}
