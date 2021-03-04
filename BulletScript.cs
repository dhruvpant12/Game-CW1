using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletScript : MonoBehaviour
{
    int score=0;
   
     
    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            score++;
             

        }
    }

    public int sendscore()
    {
        return score;
    }
     
}

