using UnityEngine;
using System.Collections;

public class BallJumper : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color highlightColor = Color.yellow;
    [SerializeField] private float threshold = 0.1f;

    private Rigidbody _rb;
    private Renderer _sr;
    private bool _isColoring;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _sr = GetComponent<Renderer>();
        SetColor(defaultColor);
    }

    private void FixedUpdate()
    {
        float speed = _rb.linearVelocity.y;
        if (!_isColoring && speed < threshold)
        {
            _isColoring = true;
            StartCoroutine(ColorBall());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Jump();
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    }

    private IEnumerator ColorBall()
    {
        SetColor(highlightColor);
        do
        {
            yield return new WaitForFixedUpdate();
        } while (_rb.linearVelocity.y < threshold);

        SetColor(defaultColor);
        _isColoring = false;
    }

    private void SetColor(Color color)
    {
        _sr.material.color = color;
    }
}