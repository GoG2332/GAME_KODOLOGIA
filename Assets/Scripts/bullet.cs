using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 3f;
    float TimeToDisable = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetDisable());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       StopCoroutine(SetDisable());
       gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(TimeToDisable);
        gameObject.SetActive(false);
    
    }

}

