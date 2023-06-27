using UnityEngine;

public class CarDriver : MonoBehaviour
{
    private const string VerticalAxisName = "Vertical";
    private const string HorizontalAxisName = "Horizontal";
    private const string TagNitro = "Nitro";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _nitroSpeed;
    [SerializeField] private float _bumpSpeed;

    private const float RotateXY = 0;
    private const float TransformXZ = 0;


    private void Update()
    {
        float moveAxis = Input.GetAxis(VerticalAxisName) * Time.deltaTime;
        float rotateAxis = Input.GetAxis(HorizontalAxisName) * Time.deltaTime;
        transform.Rotate(RotateXY, RotateXY, -_rotateSpeed * rotateAxis);
        transform.Translate(TransformXZ, _moveSpeed * moveAxis, TransformXZ);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagNitro))
        {
            _moveSpeed = _nitroSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _moveSpeed -= _bumpSpeed;
        if (_moveSpeed <= 0)
        {
            _moveSpeed = 1;
        }
    }
}

