using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocity;
    public Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject. GetComponent<Rigidbody>();
        rb.linearVelocity = direction*velocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
