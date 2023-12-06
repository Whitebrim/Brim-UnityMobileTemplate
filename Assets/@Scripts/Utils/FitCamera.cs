using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FitCamera : MonoBehaviour
{
    public float unitsWidth;

    [Sirenix.OdinInspector.Button]
    private void Start()
    {
        GetComponent<Camera>().orthographicSize = unitsWidth * ((float)Screen.height / Screen.width) * 0.5f;
    }
}
