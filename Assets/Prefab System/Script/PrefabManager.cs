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
            UnpackPrefab();
        }
    }
}
