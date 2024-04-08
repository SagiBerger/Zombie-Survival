using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieCreator : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject saw;
    int cretezombietime;
    //
    public static Vector2 roomRed;
    public static Vector2 roomblue;
    public static Vector2 roomgreen;
    int X;
    int Y;
    //
     public GameObject Player;
    Vector3 playersawinstantite;
    // 
    int functionselctor;
    string functionName;
    
    AudioSource zombiestart;
    //

    public static int RoundTime;
   public TMP_Text roundtimetext;
    //

   


    void Start()
    {
        zombiestart = GetComponent<AudioSource>();
        zombiestart.mute = true;
        Invoke(nameof(unmutesound), 1);

        RoundTime = 0;
        functionName = "createzomieroomRed";
        functionselctor = 1;
        //
        cretezombietime = 5;
       X = Random.Range(-11, 11);
        Y = Random.Range(-7, 15);
        playersawinstantite = new Vector3(Player.transform.localPosition.x + 2 , Player.transform.localPosition.y , Player.transform.localPosition.z);

        InvokeRepeating(functionName, 0, cretezombietime);
        InvokeRepeating(nameof(createZombisTimeShort), 5, 30);
        InvokeRepeating(nameof(roundtime1), 0, 1);

    }

    // Update is called once per frame
    void Update()
    {

        if (Player.transform.position.y > -7 && Player.transform.position.y < 15.3f && // ככה מתחמים לתחומים
            Player.transform.position.x > -11 && Player.transform.position.x < 11)
        {
            functionselctor = 1;
        }
        else if (Player.transform.position.y > 22 && Player.transform.position.y < 34 && // ככה מתחמים לתחומים
            Player.transform.position.x > -12 && Player.transform.position.x < 11) 
        {
            functionselctor = 2; 
        }
        else { functionselctor = 3; }

        if (rotateWepones.Zombiekillcount >= 8 )
        {
          GameObject saw1 = Instantiate(saw ,playersawinstantite, Quaternion.identity);
            saw1.transform.SetParent(Player.transform);
            rotateWepones.Zombiekillcount = 0;
        }
    
    }
    private void createzomieroomRed()
    {
        if (functionselctor == 1)
        {

            instatiteinredroom(); instatiteinredroom();

            if (RoundTime > 30)
            {
                instatiteinredroom();

            }
            if (RoundTime > 60)
            {
                instatiteinredroom();
            } 
            if (RoundTime > 90)
            {
                instatiteinredroom();
                instatiteinredroom();
            }

            }
        else if (functionselctor == 2)
        {
            instatiteinblueroom(); instatiteinblueroom();
            Instantiate(Zombie, roomblue, transform.rotation);
            if (RoundTime > 30)
            {
                instatiteinblueroom();
            }
            if (RoundTime > 60)
            {
                instatiteinblueroom();
            }
            if (RoundTime > 90)
            {
                instatiteinblueroom();
                instatiteinblueroom();
            }
            // לשנות אויב
        }
        else if (functionselctor == 3)
        {
            instatiteingreenroom(); instatiteingreenroom();
            Instantiate(Zombie, roomgreen, transform.rotation);
            if (RoundTime > 30)
            {
                instatiteingreenroom();

            }
            if (RoundTime > 60)
            {
                instatiteingreenroom();
            } 
            if (RoundTime > 90)
            {
                instatiteingreenroom();
                instatiteingreenroom();
            }
            // לשנות אויב
        }

    }
    void createZombisTimeShort()
    {
        cretezombietime -= 1;
      
        if(cretezombietime == 0)
        {
            cretezombietime = 1;
        }
    }
  void instatiteinredroom()
    {
        X = Random.Range(-6, 11);
        Y = Random.Range(-7, 15);
        roomRed = new Vector2(X, Y);
        Instantiate(Zombie, roomRed, transform.rotation);
        zombiestart.transform.position = roomRed;
        zombiestart.Play();


    }
    void instatiteinblueroom()
    {
        X = Random.Range(-12, 11);
        Y = Random.Range(22, 34);
        roomblue = new Vector2(X, Y);
        Instantiate(Zombie, roomblue, transform.rotation);
        zombiestart.transform.position = roomblue;
        zombiestart.Play();
    }
    void instatiteingreenroom()
    {
        X = Random.Range(18, 41);
        Y = Random.Range(-4, 7);
        roomgreen = new Vector2(X, Y);
        Instantiate(Zombie, roomgreen, transform.rotation);
        zombiestart.transform.position = roomgreen;
        zombiestart.Play();
    }
    void unmutesound()
    {
        zombiestart.mute = false;
    }
    void roundtime1()
    {
        RoundTime += 1;
        roundtimetext.text = RoundTime.ToString();
    }
    
    
}
