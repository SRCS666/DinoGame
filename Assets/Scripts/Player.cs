using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController character;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float jumpForce;

    private Vector3 direction;

    private void Awake()
    {
        gravity *= 2f;
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += gravity * Time.deltaTime * Vector3.down;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
