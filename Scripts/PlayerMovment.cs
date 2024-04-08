using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Movement variables
    float speed;
    float lookspeedx;

    // Camera variables
    public Camera Camera;
    float mousex;
    float mousey;

    // Shooting variables
    public GameObject bulletcreatLoc;
    public static GameObject thecolitiongun;
    public static bool CanpicUpgun;

    // Animation and Audio variables
    Animator animator;
    AudioSource AudioSourcerun;

    // Health variables
    int HP;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;
    public Image[] Hearts = new Image[5];
    int i;

    // Coin variables
    public static int Roundcoins;
    int totalcoins;
    public TMP_Text coinEarndtext;

    // Zombie kill variables
    public static int zombiekill;
    int totalzombiekill;
    public TMP_Text zombiekilltext;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        AudioSourcerun = GetComponent<AudioSource>();
        coinEarndtext.text = Roundcoins.ToString();
        zombiekilltext.text = zombiekill.ToString();
        Roundcoins = 0;
        zombiekill = 0;
        i = 0;
        Hearts = new Image[] { heart1, heart2, heart3, heart4, heart5 };
        HP = 5;

        // Check if AudioSource component is found
        if (AudioSourcerun == null)
        {
            Debug.LogWarning("AudioSource component not found on the GameObject.");
        }
        else
        {
            AudioSourcerun.mute = true;
        }

        // Set initial camera rotation
        Camera.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Get Animator component
        animator = GetComponent<Animator>();

        // Set initial values
        CanpicUpgun = true;
        speed = 2;
        lookspeedx = 20;
    }

    // Update is called once per frame
    void Update()
    {
        // Activate/deactivate bullet creation location
        bulletcreatLoc.SetActive(Shooting.Canfire);

        // Perform player movement
        movment();

        // Update coin and zombie kill text
        coinEarndtext.text = Roundcoins.ToString();
        zombiekilltext.text = zombiekill.ToString();
    }

    // Handle collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gun1" && CanpicUpgun)
        {
            // Pick up gun
            thecolitiongun = collision.gameObject;
            GunScript.bullets = 8;
            Shooting.Canfire = true;
            CanpicUpgun = false;
            Destroy(collision.gameObject, 0.5f);
        }

        if (collision.gameObject.tag == "Zombie")
        {
            // Decrease health
            if (i < Hearts.Length)
            {
                Destroy(Hearts[i].gameObject);
                i++;
            }

            Destroy(collision.gameObject);
            HP -= 1;

            // Check if player is dead
            if (HP == 0)
            {
                totalcoins += Roundcoins;
                totalzombiekill += zombiekill;
                SceneManager.LoadScene("ShopAndRestart");
            }
        }

        if (collision.gameObject.layer == 11)
        {
            // Reset player position
            transform.position = new Vector3(0, 0, 0);
        }
    }

    // Perform player movement
    void movment()
    {
        // Handle player movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((new Vector3(0, 2, 0) * speed * Time.deltaTime));
            animator.SetBool("isrunning", true);
            AudioSourcerun.mute = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 2, 0) * -speed * Time.deltaTime);
            animator.SetBool("isrunning", true);
            AudioSourcerun.mute = false;
        }
        else
        {
            animator.SetBool("isrunning", false);
            AudioSourcerun.mute = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(2, 0, 0) * speed * Time.deltaTime);
            animator.SetBool("isrunning", true);
            animator.SetBool("IsRunningLeft", false);
            AudioSourcerun.mute = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(2, 0, 0) * -speed * Time.deltaTime);
            animator.SetBool("IsRunningLeft", true);
            animator.SetBool("isrunning", false);
            AudioSourcerun.mute = false;
        }
        else
        {
            animator.SetBool("isrunning", false);
            animator.SetBool("IsRunningLeft", false);
            AudioSourcerun.mute = true;
        }

        // Handle animation based on movement direction
        bool isMovingVertically = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);

        if (isMovingVertically)
        {
            if (isMovingLeft)
            {
                animator.SetBool("isrunning", false);
                animator.SetBool("IsRunningLeft", true);
            }
            else if (isMovingRight)
            {
                animator.SetBool("isrunning", true);
                animator.SetBool("IsRunningLeft", false);
            }
            else
            {
                animator.SetBool("isrunning", true);
                animator.SetBool("IsRunningLeft", false);
            }
            AudioSourcerun.mute = false;
        }
        else if (isMovingLeft)
        {
            animator.SetBool("IsRunningLeft", true);
            animator.SetBool("isrunning", false);
            AudioSourcerun.mute = false;
        }
        else if (isMovingRight)
        {
            animator.SetBool("IsRunningLeft", false);
            animator.SetBool("isrunning", true);
            AudioSourcerun.mute = false;
        }
        else
        {
            animator.SetBool("isrunning", false);
            animator.SetBool("IsRunningLeft", false);
            AudioSourcerun.mute = true;
        }
    }

    // Rotate camera
    void Camararotition()
    {
        if (Camera.transform.rotation.y >= -8f)
        {
            mousex = Input.GetAxis("Mouse X") * lookspeedx * Time.deltaTime;
            Camera.transform.Rotate(0, mousex, 0);
        }
    }
}
