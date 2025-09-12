using UnityEngine;

public class UI_Root : MonoBehaviour
{
    private static UI_Root _instance;
    public static UI_Root Instance => _instance;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
