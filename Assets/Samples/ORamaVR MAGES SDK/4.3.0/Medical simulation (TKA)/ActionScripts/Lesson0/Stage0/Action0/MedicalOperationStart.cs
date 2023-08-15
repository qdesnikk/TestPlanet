﻿using UnityEngine;
using MAGES.UIManagement;
using MAGES.Utilities;
using System.Collections;
using MAGES.ActionPrototypes;
using MAGES.OperationAnalytics;
using MAGES.RecorderVR;
using MAGES.GameController;

public class MedicalOperationStart : BasePrototype
{
    private GameObject customizationCanvas;

    public override void Initialize()
    {
        InterfaceManagement.Get.SetUserSpawnedUIAllowance(false);

        StartCoroutine(SpawnAfterWelcome());

        base.Initialize();
    }

    public override void Perform()
    {
        
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

        DestroyUtilities.RemoteDestroy(GameObject.Find("OperationStartMedical(Clone)"));
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