using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float mooveSpeed = 10;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * mooveSpeed;
    }
}
