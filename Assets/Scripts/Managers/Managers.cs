using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Initialize(); return s_instance; } }

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }

    UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }


    void Awake()
    {
        Initialize();
        // UI_Root 연결
        _ui.SetRoot(UI_Root.Instance);
    }
    private void Start()
    {
       

    }

    private void Update()
    {
        _input.OnUpdate();
    }

    static void Initialize()
    {
   

        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }    
    }
}
