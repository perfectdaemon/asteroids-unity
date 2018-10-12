using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly Vector3 _upAxis = new Vector3(0, 0, 1);
    private Transform _transform;
    private float _rotateInput;
    private float _speedInput;
    private Vector3 _movement;

    [SerializeField]
    public Transform PlayerShip;

    [SerializeField]
    [Range(1f, 100f)]
    public float RotateSpeed = 1f;

    [SerializeField]
    [Range(1f, 100f)]
    public float AccelerationSpeed = 1f;

    [SerializeField]
    [Range(1f, 100f)]
    public float MaxSpeed = 10f;

    // Use this for initialization
    public void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {
        _rotateInput = Input.GetAxis("Horizontal");
        _speedInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(_rotateInput) > Mathf.Epsilon)
        {
            PlayerShip.Rotate(_upAxis, _rotateInput * RotateSpeed * Time.deltaTime);
        }

        if (_speedInput > Mathf.Epsilon)
        {
            _movement = _movement + PlayerShip.up * _speedInput * AccelerationSpeed * Time.deltaTime;

            if (_movement.magnitude > MaxSpeed)
                _movement = _movement.normalized * MaxSpeed;
        }

        _transform.Translate(_movement * Time.deltaTime, Space.Self);
    }
}

