using MAGES.Utilities;
using UnityEngine;
using MAGES.ToolManager.tool;
public class DrillCriticalError : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == ToolsEnum.Drill.ToString())
        {
            if(!GameObject.Find("CriticalErrorUI(Clone)"))
                PrefabImporter.SpawnActionPrefab("Lesson1/Stage0/Action0/CriticalErrorUI");

            DestroyUtilities.RemoteDestroy(gameObject);
        }
    }
}
