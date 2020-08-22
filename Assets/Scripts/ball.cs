using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public GameObject particle;
    public GameObject paddle;
    public Canvas blockArea;
    private bool isPlaying = false;
    Vector3 startPos = new Vector3();
    
    private float powerForce = 1.6f; // сила толчка 
     
    void Start()
    {
        blockArea.GetComponent<GridLayoutGroup>().enabled = true;

        startPos = gameObject.transform.position;
        readyToPlay();   
    }

    // Update is called once per frame
    void Update()
    {
    }

    void readyToPlay()
    {
        isPlaying = false;
        gameObject.GetComponent<Rigidbody2D>().Sleep();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && !isPlaying)
        {
            blockArea.GetComponent<GridLayoutGroup>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().WakeUp();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1.2f) * powerForce * Time.deltaTime);
            isPlaying = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "loseBox")
        {
            gameObject.transform.position = startPos;
            readyToPlay();
        }
        else
        {
            Debug.Log("ball collision with " + collision.gameObject.name + "\n");
            particle.GetComponent<ParticleSystem>().transform.position = gameObject.transform.position;
            //particle.GetComponent<ParticleSystem>().main.startColor.color.a = collision.gameObject.GetComponent<Color>();
            particle.GetComponent<ParticleSystem>().Play();
        }
        if (collision.gameObject.tag == "block1")
        {
            Destroy(collision.gameObject);
        }
    }
}
