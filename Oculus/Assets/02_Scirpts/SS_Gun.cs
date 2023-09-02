using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Gun : MonoBehaviour
{
    public GameObject bulletPrefab;  //�Ѿ� ������
    public Transform bulletSpawn;  //�Ѿ��� �����Ǵ� ��ġ
    public float bulletSpeed = 20f;  //�Ѿ� �ӵ�
    public float fireRate = 0.5f;  //�Ѿ� ��Ÿ��
    private float nextFire;

    void Update()
    {
        // 0.5�� �������� �Ѿ��� �߻� �� �� ����
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        // �Ѿ� ������ ����
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // �Ѿ� �߻�
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // 2�� �ڿ� �ı�
        Destroy(bullet, 2.0f);
    }
}
