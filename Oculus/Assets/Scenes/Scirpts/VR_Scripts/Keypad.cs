using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public GameObject Password;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //�÷��̾�� �������
        {
            Password.gameObject.SetActive(true); //�н����� UI�� Ų��
        }
    }

    private void OnCollisionExit(Collision collision) // �÷��̾�� ����������
    {
        Password.gameObject.SetActive(false); // �н����� UI�� ����

    }
}
