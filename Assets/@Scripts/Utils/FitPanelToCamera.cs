using Sirenix.OdinInspector;
using UnityEngine;

public class FitPanelToCamera : MonoBehaviour
{
    private Camera _mainCamera;

    [Button]
    void Start()
    {
        _mainCamera = Camera.main;
        Vector3 cameraPosition = _mainCamera.transform.position;
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y, 0);
        Vector3 bottomLeft = _mainCamera.ViewportToWorldPoint(Vector3.zero) * 100;
        Vector3 topRight = _mainCamera.ViewportToWorldPoint(new Vector3(_mainCamera.rect.width, _mainCamera.rect.height)) * 100;
        Vector3 screenSize = topRight - bottomLeft;
        float screenRatio = screenSize.x / screenSize.y;
        Vector3 localScale = transform.localScale;
        float desiredRatio = localScale.x / localScale.y;

        if (screenRatio > desiredRatio)
        {
            float height = screenSize.y;
            transform.localScale = new Vector3(height * desiredRatio, height);
        } else
        {
            float width = screenSize.x;
            transform.localScale = new Vector3(width, width / desiredRatio);
        }
    }
}
