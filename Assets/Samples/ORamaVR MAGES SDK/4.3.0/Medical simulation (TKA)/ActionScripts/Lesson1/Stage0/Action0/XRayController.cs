using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayController : MonoBehaviour
{

    private static XRayController controller;
    public static XRayController instance
    {
        get
        {
            if (!controller)
            {
                controller = FindObjectOfType(typeof(XRayController)) as XRayController;
                if (!controller)
                {
                    controller = new XRayController();
                }
            }
            return controller;
        }
    }

    [SerializeField]
    GameObject monitor;
    [SerializeField]
    GameObject Bones;


    void Start()
    {
        controller = this;
        SetXray(false);
    }

    public void SetXray(bool enabled)
    {
        monitor?.SetActive(enabled);
        Bones?.SetActive(enabled);
    }
}
