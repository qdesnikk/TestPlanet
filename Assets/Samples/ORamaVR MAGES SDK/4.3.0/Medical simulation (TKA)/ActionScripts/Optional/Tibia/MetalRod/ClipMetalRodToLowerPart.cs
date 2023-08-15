using MAGES.ActionPrototypes;
using MAGES.Utilities;
using UnityEngine;

public class ClipMetalRodToLowerPart : InsertAction
{
    public override void Initialize()
    {
        DestroyUtilities.RemoteDestroy(GameObject.Find("LowerLegAlignmentTool_final(Clone)"));

        SetInsertPrefab("Optional/Tibia/MetalRod/LowerLegAlignmentTool_grabbable", "Optional/Tibia/MetalRod/LowerLegAlignmentTool_final");
        SetHoloObject("Optional/Tibia/MetalRod/Hologram/Hologram_LowerLegAlignmentTool");
        
        base.Initialize();
    }
}
