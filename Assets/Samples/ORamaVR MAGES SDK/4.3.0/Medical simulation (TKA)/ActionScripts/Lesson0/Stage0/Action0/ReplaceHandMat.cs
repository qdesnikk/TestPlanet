using MAGES.GameController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceHandMat : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = MAGESControllerClass.Get.leftHand.transform.Find("HandRenderer").GetComponent<SkinnedMeshRenderer>().material;
    }
}
