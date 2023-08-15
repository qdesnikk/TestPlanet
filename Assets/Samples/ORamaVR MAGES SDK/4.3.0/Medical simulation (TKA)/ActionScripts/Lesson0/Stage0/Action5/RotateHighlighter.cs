using UnityEngine;

public class RotateHighlighter : MonoBehaviour {
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, 1), 2);
	}
}
