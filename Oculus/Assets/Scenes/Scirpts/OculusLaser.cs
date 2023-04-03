using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusLaser : MonoBehaviour
{
    public enum HandType
    {
        LeftHand, RightHand
    }
    public HandType type;

    public OculusCon player;

    private LineRenderer line; // ���η�����
    private float maxDistance = 30.0f; //������ �ִ�Ÿ�
    public GameObject hitObject; // �������� ������ ��ü


    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        line = GetComponent<LineRenderer>();
        //�� ��ũ��Ʈ�� ������ ������Ʈ���� LineRenderer��� ������Ʈ�� ã�Ƽ� line�� �����Ѵ�.

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.forward * maxDistance);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            hitObject = hit.transform.gameObject;
        }
        else
        {
            hitObject = null;
        }

        switch(type)
        {
            case HandType.LeftHand:
                {
                    player.hitL = hitObject;
                    break;
                }
            case HandType.RightHand:
                {
                    player.hitR = hitObject;
                    break;
                }
        }
    }
}
