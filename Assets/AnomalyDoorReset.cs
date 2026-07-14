using UnityEngine;

public class AnomalyDoorReset : MonoBehaviour
{
    void OnEnable()
    {
        BailoutSwitch bailout = GetComponentInChildren<BailoutSwitch>();

        if (bailout != null)
        {
            Transform t = bailout.transform;

            Transform openDoor = t.Find("DoorOpenObject") ?? t.Find("doorOpenObject");
            Transform closedDoor = t.Find("DoorClosedObject") ?? t.Find("doorClosedObject");
            Transform textObj = t.Find("BailoutTextObject") ?? t.Find("bailoutTextObject");

            if (openDoor == null && t.childCount > 0) openDoor = t.GetChild(0);
            if (closedDoor == null && t.childCount > 1) closedDoor = t.GetChild(1);

            if (openDoor != null) openDoor.gameObject.SetActive(true);
            if (closedDoor != null) closedDoor.gameObject.SetActive(false);
            if (textObj != null) textObj.gameObject.SetActive(false);
        }
    }
}