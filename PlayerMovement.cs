using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
     
   // public Text scoretext;
    public PlayerStats player;
    public int health;
    public int speed;
    public Slider slider;
    public GameObject deathcanvas;
     
    //bool pause;
    float xdirection;
    float zdirection;
     
   // Vector3 movement = new Vector3();
    Vector3 boundry = new Vector3();
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
         
        health =3;
        speed = player.speed;
        rb = GetComponent<Rigidbody>();
        deathcanvas.SetActive(false);
       // pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        winorlose(health);

          xdirection = Input.GetAxis("Horizontal");
          zdirection = Input.GetAxis("Vertical");

     /*   if(Input.GetKeyDown(KeyCode.Return))
        {
            if(pause)
            {
                Time.timeScale = 1;
                pause = false;
            }

            if (!pause)
            {
                Time.timeScale = 0;
                pause = true;
            }

        }*/

        boundry = transform.position;
        boundry.x = Mathf.Clamp(transform.position.x, -40f, 40f);
        boundry.z = Mathf.Clamp(transform.position.z, -40f, 40f);
        boundry.y = Mathf.Clamp(transform.position.y, 0f, 3f);
        transform.position = boundry;
        // movement = new Vector3(xdirection, 0f, zdirection);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(xdirection, 0f, zdirection) * speed;
        //transform.position += movement * speed*Time.deltaTime;
         // boundry = transform.position;
       // boundry.x = Mathf.Clamp(transform.position.x, 40f, -40f);
        //boundry.z = Mathf.Clamp(transform.position.z, 40f, -40f);
        //boundry.y = Mathf.Clamp(transform.position.y, 0f, 3f);
        //transform.position = boundry;
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, 40f, -40f), transform.position.y, Mathf.Clamp(transform.position.z, 40f, -40f));
         

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedPickUp"))
        {
             speed += 20;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            health--;
            updatehealth(health);
            Destroy(other.gameObject);

        }
    }

    public void updatehealth(int health)
    {
        slider.value = health;

    }

    public void winorlose(int health)
    {
        if(health==0)
        {
             
            gameObject.SetActive(false);
            deathcanvas.SetActive(true);
             
        }

    }
}
