using UnityEngine;

public class Shooting : MonoBehaviour
{// TargetIsTheMouse()
    private Camera camera1;
    private Vector3 mousePos;
  
    //shoot
    public GameObject bullet;
    public GameObject bulletcreatLoc1;
    public static bool Canfire;
    //
    public AudioSource bulletstart;

  
    // Start is called before the first frame update
    void Start()
    {
        bulletstart.mute = true;
        camera1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();//TargetIsTheMouse()
       // Canfire =false;
    }

    // Update is called once per frame
    void Update()
    {
      
       
        TargetIsTheMouse();
        if(Input.GetMouseButtonDown(0) && Canfire && Time.timeScale > 0)
        {
            Instantiate(bullet, bulletcreatLoc1.transform.position ,Quaternion.identity );
            GunScript.bullets -= 1;
            bulletstart.mute = false;
            bulletstart.Play();
        }


    }
    void TargetIsTheMouse()
    {
        mousePos = camera1.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    

    }
}
