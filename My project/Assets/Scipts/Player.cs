using UnityEngine;

public class Player : MonoBehaviour
{
 private  CharacterController character; 
 private Vector3 direction;

public float gravity = 9.8f * 2f;
public float jumpForce = 8f;
public AudioSource jumpSound;

 private void Awake()
 {
        character = GetComponent<UnityEngine.CharacterController>();
 }
 private void OnEnable()
 {
    direction = Vector3.zero;
 }

 private void Update()
 {
        direction += Vector3.down * gravity * Time.deltaTime;
        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
                jumpSound.Play();
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
    if (other.CompareTag("PowerUp"))
    {
        GameManager.Instance.Ability1();
    }
    if (other.CompareTag("PowerUp2"))
    {
        GameManager.Instance.Ability2();
    }
    
 }
 
 
}
