using UnityEngine;
using MAGES.OperationAnalytics;
using MAGES.UIManagement;
using MAGES.Utilities;
using MAGES.ActionPrototypes;

public class SoftbodyCTDEnd : BasePrototype
{
    private GameObject exit;

    public override void Initialize()
    {
        InterfaceManagement.Get.InterfaceRaycastActivation(true);

        exit = PrefabImporter.SpawnActionPrefab("Lesson0/Stage0/OperationEnd/OperationExit");

        if (MAGES.RecorderVR.RecordingWriter.Instance.isRecording)
            MAGES.RecorderVR.RecordingWriter.Instance.EndRecording(true);
        else
            GameObject.Find("OperationExit(Clone)/InterfaceContent/RecordingUpload").SetActive(false);

        // Call OperationFinished to export Analytics
        AnalyticsMain.OperationFinished();

        base.Initialize();
    }

    public override void Undo()
    {
        DestroyUtilities.RemoteDestroy(exit);
        InterfaceManagement.Get.InterfaceRaycastActivation(false);

        base.Undo();
    }
}