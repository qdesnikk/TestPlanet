using UnityEngine;
using MAGES.OperationAnalytics;
using MAGES.UIManagement;
using MAGES.Utilities;
using MAGES.ActionPrototypes;

public class MedicalOperationEnd : BasePrototype
{
    private GameObject exit;

    public override void Initialize()
    {
        InterfaceManagement.Get.InterfaceRaycastActivation(true);

        exit = PrefabImporter.SpawnActionPrefab("Lesson1/Stage2/Action3/OperationExitMedical");
        // Call OperationFinished to export Analytics
        AnalyticsMain.OperationFinished();

        base.Initialize();
    }

    public override void Undo()
    {
        DestroyUtilities.RemoteDestroy(GameObject.Find("FemoralGuideFinal(Clone)"));
        DestroyUtilities.RemoteDestroy(GameObject.Find("CuttingBlockFinal(Clone)"));

        DestroyUtilities.RemoteDestroy(exit);
        InterfaceManagement.Get.InterfaceRaycastActivation(false);

        base.Undo();
    }
}
