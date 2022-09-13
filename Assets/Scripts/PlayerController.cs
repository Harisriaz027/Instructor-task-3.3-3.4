using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float horizontalInput;
    public float xRange=18;
    public GameObject bullet;
    private Animator playerAnim;
    public int life;
    public ParticleSystem dirtParticle;
    
    
    
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (horizontalInput == 0)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else if (horizontalInput > 0)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            transform.eulerAngles = new Vector3(0, 90, 0);
            dirtParticle.Play();
            transform.Translate(Vector3.forward * speed * Time.deltaTime * horizontalInput);
            playerAnim.SetFloat("Speed_f", horizontalInput);
            playerAnim.SetBool("Static_b", true);
            
        }
        else if (horizontalInput < 0)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            transform.eulerAngles = new Vector3(0, -90, 0);
            transform.Translate(Vector3.back * speed * Time.deltaTime * horizontalInput);
            playerAnim.SetFloat("Speed_f", -horizontalInput);
            playerAnim.SetBool("Static_b", true);
            dirtParticle.Play();
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (transform.position.x > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position,transform.rotation);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball 1")|| collision.gameObject.CompareTag("Ball 2")|| collision.gameObject.CompareTag("Ball 3"))
        {
            life--;
        }
        if (life < 1)
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
