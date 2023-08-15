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

public class ActionManager : MonoBehaviour
{
    public UnityEngine.UI.Text description;

    public GameObject previousButton;
    public GameObject nextButton;

    public void PreviousButtonEnabled(bool enabled)
    {
        previousButton.SetActive(enabled);
    }

    public void NextButtonEnabled(bool enabled)
    {
        nextButton.SetActive(enabled);
    }

    public void GoToNextAction()
    { 
        Operation.Get.Perform();
    }

    public void GoToPrebiousAction()
    {
        Operation.Get.Undo();
    }

    public void SetDescriptionText(string text)
    {
        this.description.text = text;
    }

    public void Start()
    {
        //this.description.text = "";
    }
}
