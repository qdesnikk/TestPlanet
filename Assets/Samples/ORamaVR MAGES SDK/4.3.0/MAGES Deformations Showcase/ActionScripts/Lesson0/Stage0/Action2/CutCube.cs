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

public class CutCube : CutAction
{
    private GameObject m_ActionManager;
    public override void Initialize()
    {
        SpawnCuttingTools("Lesson0/Stage0/Action2/Scalpel");
        SpawnCutObject("Lesson0/Stage0/Action2/Cube");
        SetCutPrefabs("Lesson0/Stage0/Action2/CutCubeConstructor", "Cube(Clone)");
        m_ActionManager = Spawn("Lesson0/Stage0/Generic/ActionManager");
        m_ActionManager.GetComponent<ActionManager>().SetDescriptionText("MAGES SDK RealTime Deformations. \n\nUse the knife to cut the object found below");

        base.Initialize();
    }

    public override void Perform()
    {
        DestroyUtilities.RemoteDestroy(m_ActionManager);
        base.Perform();
    }

    public override void Undo()
    {
        DestroyUtilities.RemoteDestroy(m_ActionManager);
        base.Undo();
    }
}
