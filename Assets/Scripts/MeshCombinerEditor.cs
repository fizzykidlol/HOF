#if (UNITY_EDITOR)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshCombiner))]

public class MeshCombinerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MeshCombiner mc = (MeshCombiner)target;
        if (GUILayout.Button("Simple Merge"))
        {
            mc.simpleMerge();
        }

        if (GUILayout.Button("Advanced Merge"))
        {
            mc.advancedMerge();
        }

        if (GUILayout.Button("Advanced Merge + box collider + destroy children"))
        {
            mc.advancedMerge();
            mc.addBoxCollider();
            mc.deleteAllChildren();
        }

        if (GUILayout.Button("Advanced Merge + mesh collider + destroy children"))
        {
            mc.advancedMerge();
            mc.addMeshCollider();
            mc.deleteAllChildren();
        }
    }
}
#endif
