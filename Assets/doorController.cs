using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorController : MonoBehaviour
{
    public string sequence;
    private GameObject[] birds;
    public GameObject MSTTManager;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString("sequence", sequence);
            MSTTManager.transform.parent.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            MSTTManager.GetComponent<MSTTManager>().PlaySound();
        }
    }

    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        birds = GameObject.FindGameObjectsWithTag("bird");
    }

    void Update()
    {
        if (sequence.Length == birds.Length)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled = true;
            //Debug.Log(sequence);
        }
    }

    public Vector3[] Positions()
    {
        Vector3[] positions = {new Vector3(7, 35, -12), new Vector3(2, 35, -12)};
        return positions;
    }
}
