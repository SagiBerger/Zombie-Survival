using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayerforsaw : MonoBehaviour
{ public GameObject player;
    // Start is called before the first frame update
  
  

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
