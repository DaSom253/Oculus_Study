using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBoxOpen : MonoBehaviour
{
    public GameObject ToyBox;
    public GameObject ToyBoxKey;
    private bool ToyBoxOpenCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoxOpen();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            ToyBoxOpenCheck = true;
            Debug.Log("BoxKeyCheck");
        }
    }

    private void BoxOpen()
    {
        if (ToyBoxOpenCheck)
        {
            ToyBoxKey.GetComponent<Animator>().SetTrigger("ToyBoxKey");
            Invoke("BoxOpenAnim", 1f);
            Debug.Log("ToyBoxOpen");
        }
    }

    void BoxOpenAnim()
    {
        ToyBox.GetComponent<Animator>().SetTrigger("ToyBoxOpen");
    }
}
