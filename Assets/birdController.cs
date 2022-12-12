using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public GameObject door;
    public string character = "O";
    public Transform finalPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.GetComponent<doorController>().sequence += character;
            this.GetComponent<SphereCollider>().enabled = false;
            transform.position = finalPosition.transform.position;
        }
    }
}
