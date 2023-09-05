using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int hpUp; //�⺻ ü�� ����
    public int hpTimeHeal; //�ð����� ü�� ȸ��
    public float damageUp; //���ݷ� ����
    public float moveSpeedUp; //�̵��ӵ� ����

    // Start is called before the first frame update
    void Start()
    {
        HpUp();
        DamagedUp();
    }

    // Update is called once per frame
    void Update()
    {
        HpTiemHeal();
    }

    public void HpUp()
    {
        GameManager.instance.player.hp += 200f * hpUp;
    }

    public void HpTiemHeal()
    {
        if(GameManager.instance.player.maxHp >= GameManager.instance.player.hp)
        {
            GameManager.instance.player.hp += 5f * hpTimeHeal * Time.deltaTime;
        }
    }

    public void DamagedUp()
    {
        GameManager.instance.player.damage += 2.5f * damageUp;
    }

    public void MoveSpeedUp()
    {
        //vr�����Ҷ� �߰�
    }
}
