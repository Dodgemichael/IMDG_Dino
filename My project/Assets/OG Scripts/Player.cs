using UnityEngine;

public class Player1 : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity1 = 9.81f * 2f;
    public float jumpForce1 = 8f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity1 * Time.deltaTime;

        if(character.isGrounded)
        {
            direction = Vector3.down;

            if(Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce1;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle1"))
        {
            GameManager1.Instance.GameOver();
        }
    }

}
