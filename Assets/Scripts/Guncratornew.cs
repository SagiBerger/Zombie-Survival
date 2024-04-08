using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guncratornew : MonoBehaviour
{
    public GameObject Guns1;
    public GameObject Guns2;
    public GameObject Guns3;
    public GameObject Guns4;
    public GameObject Guns5;
    Vector2 gunLoctions;
    // Start is called before the first frame update
    void Start()
    {
      

        GameObject clone =  Instantiate(Guns1, ZombieCreator.roomRed, transform.rotation);
     //   gunLoctions = new Vector2(Random.Range(1, 50), Random.Range(1, 50));
        GameObject clone1 = Instantiate(Guns2, ZombieCreator.roomblue, transform.rotation);
       // gunLoctions = new Vector2(Random.Range(1, 50), Random.Range(1, 50));
        GameObject clone2 = Instantiate(Guns3, ZombieCreator.roomblue, transform.rotation);
       // gunLoctions = new Vector2(Random.Range(1, 50), Random.Range(1, 50));
        GameObject clone3 = Instantiate(Guns4, ZombieCreator.roomgreen, transform.rotation);
       // gunLoctions = new Vector2(Random.Range(1, 50), Random.Range(1, 50));
        GameObject clone4 = Instantiate(Guns5, ZombieCreator.roomgreen, transform.rotation);
       // gunLoctions = new Vector2(Random.Range(1, 50), Random.Range(1, 50));


    }
}
