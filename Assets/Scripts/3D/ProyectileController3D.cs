using UnityEngine;
public class ProyectileController3D : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 velocity = myRB.velocity;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.LookRotation(velocity);
    }
}
