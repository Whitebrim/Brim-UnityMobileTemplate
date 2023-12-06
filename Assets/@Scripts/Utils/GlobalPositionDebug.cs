using UnityEngine;

[RequireComponent(typeof(Transform))]
[ExecuteAlways]
public class GlobalPositionDebug : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] Vector3 globalPosition;
    [SerializeField] Quaternion globalRotation;
    [SerializeField] Vector3 lossyScale;
    [Header("Local")]
    [SerializeField] Vector3 localPosition;
    [SerializeField] Quaternion localRotation;
    [SerializeField] Vector3 localScale;

    private void Update()
    {
        globalPosition = transform.position;
        globalRotation = transform.rotation;
        lossyScale = transform.lossyScale;

        localPosition = transform.localPosition;
        localRotation = transform.localRotation;
        localScale = transform.localScale;
    }
}