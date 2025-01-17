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
    private float currentHp; // 새로운 변수 추가
    private bool isDead = false;
    public float pushForce;

    public Animator monsterAnim;
    public float rnd;

    private void Start()
    {
        maxHp = enemy_Hp;
        currentHp = enemy_Hp; // 초기 체력 설정
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
            return; // 스크립트가 이미 파괴된 경우 아무 작업도 하지 않음
        }


        // 뒤로 밀리는 힘을 추가
        Vector3 pushDirection = (transform.position - player.transform.position).normalized;
        rigid.AddForce(pushDirection * pushForce, ForceMode.Impulse);

        // 몬스터의 색깔을 하얗게 변하게 함
        StartCoroutine(FlashColor(0.2f));

        // 현재 체력 감소
        currentHp -= (player.damage + BulletDamage);
    }

    private IEnumerator FlashColor(float duration)
    {
        // 몬스터 색깔을 하얗게 변하게 함
        Color originalColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.white;

        // 대기 시간
        yield return new WaitForSeconds(duration);

        // 원래 색깔로 돌아감
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
        enemy_HpBar.fillAmount = currentHp / maxHp; // 현재 체력 사용
        enemy_HpBar.transform.LookAt(target);
        enemy_HpBar_Back.transform.LookAt(target);
    }

    public void MonsterRandomAnim()
    {
        rnd = Random.Range(0f, 1.0f);
        monsterAnim.SetFloat("Offset", rnd);
    }

}
