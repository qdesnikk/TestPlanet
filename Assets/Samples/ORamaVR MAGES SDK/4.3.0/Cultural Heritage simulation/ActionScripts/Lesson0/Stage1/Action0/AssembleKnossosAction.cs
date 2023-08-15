using MAGES.ActionPrototypes;
using MAGES.sceneGraphSpace;
using MAGES.UIManagement;
using System;
using UnityEngine;

/// <summary>
/// This is an example of Parallel Action
/// Both Actions (AssembleKnossosPartOfAction, AssembleSponzaPartOfAction) will initialized automatically and run in parallel
/// </summary>
public class AssembleKnossosAction : InsertAction
{

    public override void Initialize()
    {
        SetInsertPrefab("Lesson0/Stage1/Action0/FrontPartInteractable", "Lesson0/Stage1/Action0/FrontPartFinal");
        SetHoloObject("Lesson0/Stage1/Action0/Hologram/FrontPartHologram");

        base.Initialize();
    }
}
