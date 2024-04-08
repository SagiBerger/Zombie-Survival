using TMPro;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public static int bullets = 0;
    public AudioSource bulletSound;
    public AudioClip bulletSoundClip;
    public TMP_Text bulletText;

    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
        bulletSound.mute = true;
        Invoke(nameof(Unmute), 1);
    }

    void Update()
    {
        UpdateBulletText();

        if (bullets == -1)
        {
            HandleOutOfBullets();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUpGun();
        }
    }

    void Unmute()
    {
        bulletSound.mute = false;
    }

    void UpdateBulletText()
    {
        bulletText.text = bullets.ToString();
    }

    void HandleOutOfBullets()
    {
        bulletText.text = "0";
        Shooting.Canfire = false;
        Destroy(PlayerMovement.thecolitiongun);
        PlayerMovement.CanpicUpgun = true;
    }

    void PickUpGun()
    {
        bulletSound.PlayOneShot(bulletSoundClip);
        // Implement logic for picking up the gun
    }
}




//using TMPro;
//using UnityEngine;

//public class gunScript : MonoBehaviour
//{
//    public static int bullets ;
//    public static  AudioSource bulletsound;
//    public  AudioClip bulletsoundclip;
//    public TMP_Text bullettext;
//    // Start is called before the first frame update
//    void Start()
//    {
//        bullets = 0;
//        bulletsound = GetComponent<AudioSource>();
//        bulletsound.mute = true;
//        Invoke(nameof(unmute), 1);

//    }
//    private void Update()
//    {
//        bullettext.text = bullets.ToString();
//        if (bullets == -1)
//        {
//            bullettext.text = 0.ToString();
//            Shooting.Canfire = false;
//            Destroy(PlayerMovment.thecolitiongun);
//            PlayerMovment.CanpicUpgun = true;
//           // PlayerMovment.thecolitiongun.SetActive(false);


//        }
//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.gameObject.tag == "Player" )// && Shooting.Canfire == false)
//        {
//            //bulletsound.mute = false ;
//            bulletsound.PlayOneShot(bulletsoundclip);
//           // Shooting.Canfire =true;


//        }
//    }
//    void unmute()
//    {
//        bulletsound.mute = false;
//    }

//}
