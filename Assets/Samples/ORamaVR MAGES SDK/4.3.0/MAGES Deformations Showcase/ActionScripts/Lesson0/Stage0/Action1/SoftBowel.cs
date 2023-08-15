using UnityEngine;
using MAGES.CustomEventManager;
using MAGES.sceneGraphSpace;
using UnityEngine.Events;
using System;
using MAGES.UIManagement;
using MAGES.Utilities;
using System.Collections;
using MAGES.Utilities.SceneHandler;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using MAGES.ActionPrototypes;

public class SoftBowel : MonoBehaviour, IAction
{
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Transform bowel;
    private Vector3 initialBowelSpawnPosition;


    #region Action Variables
    private UnityAction listener;
    private GameObject customizationCanvas;
    private GameObject startAnimation;
    private bool initialized = false;
    #endregion

    #region IAction Variables
    private string AName;
    private GameObject acNode;
    public string ActionName
    {
        get { return this.AName; }
        set { this.AName = value; }
    }
    public GameObject ActionNode
    {
        get { return this.acNode; }
        set { this.acNode = value; }
    }
    #endregion

    #region IAction Functions
    public void Initialize()
    {
        spawnedObjects.Add(PrefabImporter.SpawnActionPrefab("Lesson0/Stage0/Action1/Bowel"));
        bowel = spawnedObjects[spawnedObjects.Count - 1].transform;
        initialBowelSpawnPosition = bowel.transform.position;
        spawnedObjects.Add(PrefabImporter.SpawnActionPrefab("Lesson0/Stage0/Generic/ActionManager"));
        spawnedObjects[spawnedObjects.Count - 1].GetComponent<ActionManager>().PreviousButtonEnabled(false);
        spawnedObjects[spawnedObjects.Count - 1].GetComponent<ActionManager>().SetDescriptionText("MAGES SDK Softbody Simulations.\n\nInteract with the object below to see it in action");
        InterfaceManagement.Get.InterfaceRaycastActivation(true);
    }

    public void Perform()
    {
        BasePrototype.cameFromUndo = false;
        DestroySpawnedPrefabs();
    }

    public void DestroySpawnedPrefabs()
    {
        foreach(GameObject g in spawnedObjects)
        {
            Destroy(g);
        }

        spawnedObjects.Clear();
    }

    void EndAction()
    {
        DestroySpawnedPrefabs();
        Operation.Get.Perform();
    }

    public void Undo()
    {
        DestroySpawnedPrefabs();
    }

    public void InitializeHolograms()
    { }

    public void DifficultyRestrictions()
    { }

    public void SetNextModule(Action action)
    {
    }

    public void DestroyAction()
    {
    }
    #endregion

    public void Update()
    {
        
        if( bowel && Vector3.Distance(bowel.position, initialBowelSpawnPosition) > 1.5f)
        {
            bowel.transform.position = initialBowelSpawnPosition;
            bowel.transform.rotation = Quaternion.identity;
            bowel.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
