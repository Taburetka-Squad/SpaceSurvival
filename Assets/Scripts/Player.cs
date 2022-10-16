using UnityEngine;

using FishNet.Object;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody;
    private NetworkObject _networkObject;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _networkObject = GetComponent<NetworkObject>();
    }
    private void Update()
    {
        if (_networkObject.IsOwner)
            Move();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector2(horizontal, vertical);

        _rigidbody.velocity = direction * _speed;
    }
}