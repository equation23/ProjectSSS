using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Settings")]

    public float JumpForce;

    [Header("References")]

    public Rigidbody2D PlayerRigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
        }
    }
}
