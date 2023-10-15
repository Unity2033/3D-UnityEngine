using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private GameObject temporaryPrefab;

    void Start()
    {
        temporaryPrefab = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
    }

    public void SavePrefab()
    {
        PrefabUtility.SaveAsPrefabAssetAndConnect
        (
            temporaryPrefab, "Assets/Prefab System/Prefab/" + prefab.name + ".prefab",
            InteractionMode.AutomatedAction
        );
    }

    public void UnpackPrefab()
    {
        PrefabUtility.UnpackPrefabInstance
        (
            temporaryPrefab,
            PrefabUnpackMode.OutermostRoot,
            InteractionMode.AutomatedAction
        );
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 25, 200, 30), "Prefab Release Button"))
        {
            Debug.Log("Prefab Release Button");
            // UnpackPrefab();
        }

        if (GUI.Button(new Rect(20, 80, 200, 30), "Prefab Set Up Button"))
        {
            Debug.Log("Prefab Set Up Button");
            // SavePrefab();
        }
    }
}
