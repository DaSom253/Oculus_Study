using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class OculusCon : MonoBehaviour
{
    [HideInInspector] public OVRInput.Controller controllerL; //�޼� ��Ʈ�ѷ�
    [HideInInspector] public OVRInput.Controller controllerR; //������ ��Ʈ�ѷ�

    public Text logText; //��� �޽���

    [HideInInspector] public OVRGrabber grabberL;
    [HideInInspector] public OVRGrabber grabberR;

    public GameObject grabL;
    public GameObject grabR;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabberL.m_grabbedObj)
        {
            grabL = grabberL.m_grabbedObj.gameObject;
        }
        else
        {
            grabL = null;
        }
        if(grabberR.m_grabbedObj)
        {
            grabR = grabberR.m_grabbedObj.gameObject;
        }
        else
        {
            grabR = null;
        }



        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {

           
            
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (grabR)
            {
                switch(grabR.transform.name)
                {
                    case "Gun":
                        {
                            grabR.GetComponent<BulletCreate>().CheckGun();
                            break;
                        }
                }
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
        }

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        }

        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        }

        //A��ư (������)

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
        }

        //B��ư (������)
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
        }

        //X��ư (�޼�)
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
        }

        //Y��ư (�޼�)
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
        }

        //��ŸƮ ��ư (�޼�)

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
        }
    }

}