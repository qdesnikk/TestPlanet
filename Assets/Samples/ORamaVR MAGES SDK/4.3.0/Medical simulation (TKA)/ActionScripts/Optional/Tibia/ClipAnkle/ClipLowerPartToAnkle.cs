using UnityEngine;
using MAGES.ActionPrototypes;
using MAGES.Utilities;
using MAGES.sceneGraphSpace;

public class ClipLowerPartToAnkle : InsertAction
{
    public override void Initialize()
    {
        DestroyUtilities.RemoteDestroy(GameObject.Find("ClipLowerPartToAnkle_final(Clone)"));

        SetInsertPrefab("Optional/Tibia/ClipAnkle/ClipLowerPartToAnkle_grabbable", "Optional/Tibia/ClipAnkle/ClipLowerPartToAnkle_final");
        SetHoloObject("Optional/Tibia/ClipAnkle/Hologram/Hologram_ClipLowerPartToAnkle");

        //It is important to add this line if your perform method changes the scengergraph runtime (eg uses the ReplaceNoreRuntime)
        GetComponent<ActionProperties>().actionType = ActionType.OptionalConvertedToNormal;

        base.Initialize();
    }

    public override void Perform()
    {
        ScenegraphTraverse.ReplaceNodeRuntime("Femur Preparation", "Tibia Preparation part 2");

        base.Perform();
    }

}
