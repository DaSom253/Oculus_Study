using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyOne : EnemyBase
{
    public static EnemyOne instance;
    private Rigidbody rigid;
    NavMeshAgent nav;

    [Header("Setting")]
    public Transform target;
    public Image enemy_HpBar;
    public Image enemy_HpBar_Back;
    private float maxHp;
    private float currentHp; // ���ο� ���� �߰�
    private bool isDead = false;
    public float pushForce;

    public Animator monsterAnim;
    public float rnd;

    private void Start()
    {
        maxHp = enemy_Hp;
        currentHp = enemy_Hp; // �ʱ� ü�� ����
        target = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        EnemyOne.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);
        nav.speed = enemy_MoveSpeed;
        transform.LookAt(target);

        FreezeVelocity();
        EnmeyUIFollow();

        if (currentHp <= 0f && !isDead)
        {
            EnemyDeath();
        }
    }


    public void EnemyTakeDamage(float BulletDamage)
    {
        if (this == null)
        {
            return; // ��ũ��Ʈ�� �̹� �ı��� ��� �ƹ� �۾��� ���� ����
        }


        // �ڷ� �и��� ���� �߰�
        Vector3 pushDirection = (transform.position - player.transform.position).normalized;
        rigid.AddForce(pushDirection * pushForce, ForceMode.Impulse);

        // ������ ������ �Ͼ�� ���ϰ� ��
        StartCoroutine(FlashColor(0.2f));

        // ���� ü�� ����
        currentHp -= (player.damage + BulletDamage);
    }

    private IEnumerator FlashColor(float duration)
    {
        // ���� ������ �Ͼ�� ���ϰ� ��
        Color originalColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.white;

        // ��� �ð�
        yield return new WaitForSeconds(duration);

        // ���� ����� ���ư�
        GetComponent<Renderer>().material.color = originalColor;
    }

    void FreezeVelocity()
    {
        rigid.angularVelocity = Vector3.zero;
        rigid.velocity = Vector3.zero;
    }


    void EnemyDeath()
    {
        isDead = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        DropItem.instance.EnemyDeathEffect(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        DropItem.instance.RandomItemDrop(new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z));
        Destroy(gameObject);
    }

    void EnmeyUIFollow()
    {
        enemy_HpBar.fillAmount = currentHp / maxHp; // ���� ü�� ���
        enemy_HpBar.transform.LookAt(target);
        enemy_HpBar_Back.transform.LookAt(target);
    }

    public void MonsterRandomAnim()
    {
        rnd = Random.Range(0f, 1.0f);
        monsterAnim.SetFloat("Offset", rnd);
    }

}
