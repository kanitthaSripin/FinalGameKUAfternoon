using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerRigidbody : MonoBehaviour
{
    public float speed = 0.5f;
    public float newRotY = 0 ;
    public float rotSpeed = 20f;
    public float jumpForce = 10;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    Animator anim;
    Rigidbody rb;
    
    public int ballCount = 0;
    public int countDown = 0 ;
    PlaygroundSceneManager manager;
    public AudioSource audioBall;
    public AudioSource audioJump;
   
    //public Text t;
    //public float n;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

         if(manager == null)
         {
           manager = FindObjectOfType<PlaygroundSceneManager>();
         }
         if(PlayerPrefs.HasKey("BallCount"))
         { 
            ballCount = PlayerPrefs.GetInt("BallCount");
         }
         manager.SetTextBall(countDown);
          if(PlayerPrefs.HasKey("CountDown"))
         { 
            countDown = PlayerPrefs.GetInt("CountDown");
         }
         manager.SetTextBall(countDown);
    }

   /* void Update()
    {
       n -= Time.deltaTime;
       t.text = Mathf.Round(n).ToString();
       if(n<= 0)
       {
        t.text = "หมดเวลา";
       }
    } */

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal")*speed;
        float vertical = Input.GetAxis("Vertical")*speed;

        if(horizontal > 0)
        {   
            newRotY = 90;
        }
        else if(horizontal < 0)
        {
            newRotY = -90;
        }
        if(vertical > 0)
        {
            newRotY = 0;
        }
        else if(vertical < 0)
        {
            newRotY = 180;
        }
       rb.AddForce(horizontal,0,vertical,ForceMode.VelocityChange);
       transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,newRotY,0),
                                             transform.rotation,
                                             rotSpeed * Time.deltaTime); 

            if (Input.GetButtonDown("Jump") && Time.time > canJump)
            {
                rb.AddForce(0, jumpForce, 0,ForceMode.Impulse);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
            }
        }

         private void OnCollisionEnter(Collision collision)
         {
            print(collision.gameObject.name);
            if(collision.gameObject.tag == "Collectable")
            {
                Destroy(collision.gameObject);
            }
         }

        private void OnTriggerEnter(Collider other)
         {
          
            if(other.gameObject.tag == "Collectable")
            {
                Destroy(other.gameObject);
                ballCount++;
                manager.SetTextBall(ballCount);
                audioBall.Play();
                PlayerPrefs.SetInt("BallCount",ballCount);
            }

            if(other.gameObject.tag == "Collectable")
            {
                Destroy(other.gameObject);
                countDown += 5;
                manager.SetTextTime(countDown);
                audioBall.Play();
                PlayerPrefs.SetInt("CountDown",countDown);
            }

   }

}