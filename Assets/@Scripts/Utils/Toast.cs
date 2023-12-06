using System;
using UnityEngine;

public class Toast
{
    private static Toast _instance => LazyLoader.Value;
    private string toastString;
    private AndroidJavaObject currentActivity;
    private static readonly Lazy<Toast> LazyLoader = new Lazy<Toast>(() => new Toast());

    public static void Show(string toastString)
    {
#if UNITY_EDITOR
        Debug.Log($"Showed Android Toast: \"{toastString}\"");
#else
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        _instance.currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        _instance.toastString = toastString;
        _instance.currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(_instance.ShowToast));
#endif
    }

    private void ShowToast()
    {
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);

        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_LONG"));
        toast.Call("show");
    }
}
