using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWepones : MonoBehaviour
{
    GameObject PLAYER;
    public Vector3 rotate;
    int HP;
    public static int Zombiekillcount; // בשביל ליצור עוד חרבות
    AudioSource killzombie;
    //
    
    public GameObject[] Bloodtype = new GameObject[6];
    int j;


    // Start is called before the first frame update
    void Start()
    {
        j = Random.Range(0, 5);
        transform.localPosition =new Vector2(3, 0);
       transform.rotation =  Quaternion.Euler(0, 0, 0);
        Zombiekillcount = 0;
        PLAYER = GameObject.Find("Player");
        rotate = new Vector3(0, 0, -1);
        HP = 5;
        killzombie = GetComponent<AudioSource>();
        killzombie.mute = true;
    }

    // Update is called once per frameframe
    void Update()
    {
        circleThePlayer();

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
       // Quaternion.Euler(0, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Zombie")
        {
            HP -= 1;
            Destroy(collision.gameObject);
            Zombiekillcount += 1;
            killzombie.mute = false;
            killzombie.Play();
            PlayerMovement.Roundcoins += 5;
            PlayerMovement.zombiekill += 1;

            GameObject x = Instantiate(Bloodtype[j], collision.transform.position, Quaternion.Euler(-90, transform.position.y, 0));
            j = Random.Range(0, 5);
           
            Destroy(x , 3);
        }
    }
    void circleThePlayer()
    {
        transform.RotateAround(PLAYER.transform.localPosition, rotate, 50 * Time.deltaTime); 
        // גם פוזישן רגיל לא עבד טוב
       // transform.rotation =Quaternion.Euler(transform.rotation.x,transform.rotation.y, 0);
       //עבד טוב ששמתי אותו ילד של השחקן
       
    }
}
