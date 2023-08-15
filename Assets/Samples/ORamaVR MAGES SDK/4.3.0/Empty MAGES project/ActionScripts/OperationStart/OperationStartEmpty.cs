using UnityEngine;
using MAGES.UIManagement;
using MAGES.Utilities;
using System.Collections;
using MAGES.ActionPrototypes;
using MAGES.RecorderVR;
using MAGES.GameController;

public class OperationStartEmpty : BasePrototype
{
    private GameObject customizationCanvas;

    public override void Initialize()
    {
        //Use this to change between scenes (fade in - fade out)
        //SceneHandler.AddScene("First_Scene_SH");

        InterfaceManagement.Get.SetUserSpawnedUIAllowance(false);

        StartCoroutine(SpawnAfterWelcome());

        base.Initialize();
    }

    public override void Perform()
    {
        //Use this to change between scenes (fade in - fade out)
        //SceneHandler.SwitchScene("Second_Scene_SH");

        if (MAGESControllerClass.Get.IsInNetwork)
        {
            GameObject recordingManager = GameObject.Find("RecordingManager");
            if (recordingManager != null)
            {
                RecordingCoop recordingCoop = recordingManager.GetComponent<RecordingCoop>();
                if (recordingCoop != null && recordingCoop.recordCoop)
                {
                    recordingCoop.startRecording = true;
                }
            }
        }

        if (GameObject.Find("CharacterCustomizationCanvas(Clone)"))
        {
            customizationCanvas.GetComponent<CustomizationManager>().SkipAllActions();
        }

        InterfaceManagement.Get.SetUserSpawnedUIAllowance(true);
        InterfaceManagement.Get.ResetInterfaceManagement();
        InterfaceManagement.Get.InterfaceRaycastActivation(false);

        StopAllCoroutines();

        MAGES.AmbientSounds.ApplicationAmbientSounds.PlayAmbientNoise();

        DestroyUtilities.RemoteDestroy(GameObject.Find("OperationStart(Clone)"));

        base.Perform();
    }

    IEnumerator SpawnAfterWelcome()
    {
        InterfaceManagement.Get.InterfaceRaycastActivation(false);

        yield return new WaitForSeconds(5f);

        MAGES.AmbientSounds.ApplicationAmbientSounds.PlayAmbientMusic();

        InterfaceManagement.Get.InterfaceRaycastActivation(true);
        customizationCanvas = Instantiate(MAGESSetup.Get.customizationCanvasUI);
    }

}