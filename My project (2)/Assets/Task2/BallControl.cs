using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class BallControl : MonoBehaviour
{
    [SerializeField] private float range;
    private float currentSpeed;
    private float startTimer;
    private float timer;
    private Rigidbody rb;
    private Renderer ballRenderer;
    bool isSlow = false;
    bool wasSlow = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>();
        ballRenderer.material.color = Color.white;
    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 currentVelocity = rb.linearVelocity;
        if (currentVelocity.y < 3f) 
        {
            rb.linearVelocity = new Vector3(currentVelocity.x, 8f, currentVelocity.z);
        }
    }
    private void Update()
    {
        currentSpeed = rb.linearVelocity.magnitude;
        CheckForce();
    }
    void CheckForce()
    {
            if (currentSpeed < range && !isSlow)
            {
                isSlow = true;
                startTimer = Time.time;
                ballRenderer.material.color = Color.yellow;
                wasSlow = true;

            }

            if (currentSpeed >= range && isSlow)
            {
                isSlow = false;
                timer = Time.time - startTimer;
                ballRenderer.material.color = Color.white;

                if (wasSlow)
                {
                    Debug.Log($"ћ€ч был медленным в течении: {timer:F2} секунд");
                    wasSlow = false;
                }

            }
    }
}
