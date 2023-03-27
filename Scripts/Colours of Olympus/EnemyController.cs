using UnityEngine;
using System.Collections;
public class EnemyController : MonoBehaviour
{
    [SerializeField] float MinClampX = -1, MaxClampX = 1,AttackTimer =0,MoveSpeed = 2f,CurtAttackTime;
    [SerializeField] int MinAttackTime = 1, MaxAttackTime = 2;

    public bool InvertMovement = false, Spwan = false, Run  = false;
    Animator anim;
    bool shooting = true;

    [SerializeField] GameObject EnemyBullet, SpwanPos, AttackPos, EndPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
        Attack();
        if (Run)
        {
            TrackPos(EndPos.transform.position);
        }
        if (Spwan)
        {
            TrackPos(SpwanPos.transform.position);
        }
    }

    void Move()
    {
        if (!InvertMovement)
        {
            transform.position += new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime;
        }
        if (transform.position.x > MaxClampX)
        {
            InvertMovement = true;
        }
        if (transform.position.x < MinClampX)
        {
            InvertMovement = false;
        }
    }

    void Attack()
    {
        if (AttackTimer < CurtAttackTime)
        {
            AttackTimer += Time.deltaTime;
        }
        else
        {
            anim.SetBool("Attack", true);
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        if (shooting)
        {
            Instantiate(EnemyBullet, AttackPos.transform.position, Quaternion.identity);
            shooting = false;
        }
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Attack", false);
        CurtAttackTime = Random.Range(MinAttackTime, MaxAttackTime + 1);
        AttackTimer = 0;
        shooting = true;
        StopAllCoroutines();
    }

    void TrackPos(Vector3 pos)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, MoveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, pos) < 0.5f)
        {
            Spwan = false;
            Run = false;
        }
    }
}
