using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    private Vector3 mousepos;
    Camera cam;
    Rigidbody2D rb;
    public float force;
    //
   
    public GameObject[] Bloodtype = new GameObject[6];
    int j;
    // Start is called before the first frame update
    void Start()
    {
        j = Random.Range(0, 5);
        bulletshootToMouseloc();
        Destroy(gameObject, 7);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Zombie"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            PlayerMovement.Roundcoins += 5;
            PlayerMovement.zombiekill += 1;

            rotateWepones.Zombiekillcount += 1;
            GameObject x = Instantiate(Bloodtype[j], collision.transform.position, Quaternion.Euler(-90, transform.position.y, 0));
            j = Random.Range(0, 5);
           
            Destroy(x, 3);
        }
    }
    void bulletshootToMouseloc()
    {
    //    private Vector3 mousepos;
    //Camera cam;
    //Rigidbody2D rb;                       /// לפובליק קלאס
    //public float force;
    //

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousepos - transform.position;
        Vector3 rotation = transform.position - mousepos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float bulletrot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, bulletrot + 90);
    }
}
