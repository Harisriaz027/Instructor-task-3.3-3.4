using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float bulletspeed;
    public GameObject[] ballPrefabs;
    private GameObject ball1, ball2;
    public AudioClip popSound;
    

    private void Start()
    {
       
    }
    void Update()
    {
        transform.Translate(Vector3.up * bulletspeed * Time.deltaTime);
        if (transform.position.y > 25)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Ball 1"))
        {
            score.count++;
            AudioSource.PlayClipAtPoint(popSound,gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ball1= Instantiate(ballPrefabs[0], collision.transform.position, collision.transform.rotation);
            ball2= Instantiate(ballPrefabs[0], collision.transform.position, collision.transform.rotation);
            ball1.GetComponent<Rigidbody>().velocity = new Vector3(8.2f, 5.5f, 0);
            ball2.GetComponent<Rigidbody>().velocity = new Vector3(-8.2f, 5.5f, 0);


        }
       if (collision.gameObject.CompareTag("Ball 2"))
       {
            score.count++;
            AudioSource.PlayClipAtPoint(popSound, gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ball1=Instantiate(ballPrefabs[1], collision.transform.position, collision.transform.rotation);
            ball2=Instantiate(ballPrefabs[1], collision.transform.position, collision.transform.rotation);
            ball1.GetComponent<Rigidbody>().velocity = new Vector3(8.2f, 5.5f, 0);
            ball2.GetComponent<Rigidbody>().velocity = new Vector3(-8.2f, 5.5f, 0);
        }
        if (collision.gameObject.CompareTag("Ball 3"))
       {
            score.count++;
            AudioSource.PlayClipAtPoint(popSound, gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
       }
    }
}
