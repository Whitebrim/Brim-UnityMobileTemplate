using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float Life = 0.1f;

    void Start()
    {
        Destroy(gameObject, Life);
    }

}