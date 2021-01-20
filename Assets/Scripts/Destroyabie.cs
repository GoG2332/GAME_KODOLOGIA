using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyabie : MonoBehaviour
{
       
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")

            {
                
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * collision.gameObject.GetComponent<Player>().jumpHeight, ForceMode2D.Impulse);
            gameObject.GetComponentInParent<Enemy>().StartDeath();


            }





        }
    
}
