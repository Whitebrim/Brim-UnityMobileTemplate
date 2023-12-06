using UnityEngine;

public class ApplicationFocus : MonoBehaviour
{
    public delegate void BoolDelegate(bool hasFocus);
    public static event BoolDelegate onApplicationFocus;

    private void OnApplicationFocus(bool hasFocus)
    {
        onApplicationFocus?.Invoke(hasFocus);
    }
}