using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject activeFrame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activeFrame.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activeFrame.SetActive(false);
        }
    }
}
