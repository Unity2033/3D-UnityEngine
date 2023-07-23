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
}
