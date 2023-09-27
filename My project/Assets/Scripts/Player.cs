using UnityEngine;

public class Player : MonoBehaviour
{
 private  CharacterController character; 
 private Vector3 direction;

public float gravity = 9.8f * 2f;
public float jumpForce = 8f;
public float doubleForce = 4f;
public AudioSource jumpSound;

private float jumped = 0f;
private float spamJumped = 0f;


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
    float PlayeryPos = GameObject.Find("player").transform.position.y;
       
      
        direction += Vector3.down * gravity * Time.deltaTime;
        
        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
                jumpSound.Play();
                jumped = 0f;
                spamJumped =0f;
                
            }
        }
        if(Input.GetButtonDown("Jump")){
            if(PlayeryPos> .9){
                if(PlayeryPos < 1.61){
                    spamJumped = 1f;

                }
             }
         }

        if(spamJumped == 0f)
        if(jumped == 0f){
            if(PlayeryPos>= 1.61){
            
                if(PlayeryPos < 1.7){
           
                     if (Input.GetButtonDown("Jump"))
                     {
                        direction = Vector3.up * 7f;
                        jumped = 1f;
                        jumpSound.Play();

                        }
                }
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
    if (other.CompareTag("PowerUp3"))
    {
        GameManager.Instance.Ability3();
    }
    
 }
 
 
}
