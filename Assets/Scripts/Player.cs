using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpHeight;
    public Transform groundCheck;
    bool isGrounded;
    Animator anim;
    int currHp;
    int maxHp = 3;
    public Main main;
    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currHp = maxHp;
    }



    // Update is called once per frame
    void Update()


    {



        Jump();
        CheckGround();
        if (Input.GetAxis("Horizontal") == 0 && isGrounded)
        {
            anim.SetInteger("State", 1);

        }
       else
        {
            Flip();
            if (isGrounded)
            {
                anim.SetInteger("State", 2);
            }


        }






    }

       



    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);

        }

        if (!isGrounded)
            anim.SetInteger("State", 3);     
    }


    void CheckGround()

    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGrounded = colliders.Length > 1;
    
   
    }

    public void RecountHp(int deltaHp)
    {
        currHp += deltaHp;
        print(currHp);
        if (deltaHp < 0)
        
        {
            StopCoroutine(OnHit());
            isHit = true;
            StartCoroutine(OnHit());
        }
       
        if (currHp <= 0)
        {

        }

    }

    void Lose()
    {
        main.GetComponent<Main>().Lose();
    }


    IEnumerator OnHit()
    {
        if (isHit)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f);
        }


        if (GetComponent<SpriteRenderer>().color.g <= 0)
        {
            isHit = false;
        }

        if (GetComponent<SpriteRenderer>().color.g == 1)

        {
            StopCoroutine(OnHit());
        }

        yield return new WaitForSeconds(0.02f);
        StartCoroutine(OnHit());
    }

}

       

