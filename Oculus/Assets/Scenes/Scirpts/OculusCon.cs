using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OculusCon : MonoBehaviour
{
    public OVRInput.Controller controllerL; //�޼� ��Ʈ�ѷ�
    public OVRInput.Controller controllerR; //������ ��Ʈ�ѷ�

    public Text logText; //��� �޽���


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            logText.text = ("�޼� Ʈ����");
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            logText.text = ("������ Ʈ����");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            logText.text = ("�޼� Ʈ����");
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            logText.text = ("������ Ʈ����");
        }

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            logText.text = pos.ToString();
        }

        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            logText.text = pos.ToString();
        }

    }
}
