using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState { Idle, Chase, Attack, Hit, Death }
    private EnemyState state = EnemyState.Idle;

    public NavMeshAgent nav;
    public Animator anim;

    public float hp = 3;
    private float maxHp;

    public float chaseDistance = 20f;
    public float attackDistance = 1.5f;

    public float attackDelay = 1.0f;
    public float hitDelay = 0.5f;

    public GameObject hitVFX;

    private Player player;     // ✔ Agora correto!
    private float distance;

    private bool locked = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Nenhum objeto com a tag Player contém o script Player!");
            enabled = false;
            return;
        }

        maxHp = hp;
    }

    void Update()
    {
        if (locked || state == EnemyState.Death)
            return;

        distance = Vector3.Distance(player.transform.position, transform.position);

        switch (state)
        {
            case EnemyState.Idle: IdleUpdate(); break;
            case EnemyState.Chase: ChaseUpdate(); break;
            case EnemyState.Attack: AttackUpdate(); break;
            case EnemyState.Hit: HitUpdate(); break;
        }
    }

    // ------------------------------
    // ESTADOS
    // ------------------------------

    void IdleUpdate()
    {
        if (distance < chaseDistance)
        {
            state = EnemyState.Chase;
            anim.SetBool("IsRunning", true);
        }
    }

    void ChaseUpdate()
    {
        if (distance > chaseDistance)
        {
            nav.isStopped = true;
            state = EnemyState.Idle;
            anim.SetBool("IsRunning", false);
        }
        else if (distance < attackDistance)
        {
            EnterAttack();
        }
        else
        {
            nav.isStopped = false;
            nav.SetDestination(player.transform.position);
        }
    }

    void AttackUpdate()
    {
        if (distance < attackDistance)
        {
            EnterAttack();
        }
        else if (distance < chaseDistance)
        {
            state = EnemyState.Chase;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            state = EnemyState.Idle;
            anim.SetBool("IsRunning", false);
        }
    }

    void HitUpdate()
    {
        // Pode ser expandido caso precise de lógica especial ao levar hit
    }

    void DeathUpdate()
    {
        // Inimigo morto, nada a fazer
    }

    // ------------------------------
    // ATAQUE
    // ------------------------------

    void EnterAttack()
    {
        anim.SetTrigger("Attack");
        anim.SetBool("IsRunning", false);
        nav.isStopped = true;

        state = EnemyState.Attack;

        locked = true;
        CancelInvoke(nameof(Unlock));
        Invoke(nameof(Unlock), attackDelay);
    }

    void Unlock()
    {
        locked = false;
    }

    // ------------------------------
    // TOMAR DANO
    // ------------------------------

    public void EnterGetHit(float damageTaken, Vector3 attackerPosition)
    {
        if (hp <= 0) return;

        locked = true;
        nav.isStopped = true;

        Instantiate(hitVFX, attackerPosition, transform.rotation);

        CancelInvoke(nameof(Unlock));

        hp -= damageTaken;

        if (hp > 0)
        {
            anim.SetTrigger("Hit");
            Invoke(nameof(Unlock), hitDelay);
        }
        else
        {
            anim.SetTrigger("Death");
            state = EnemyState.Death;
            nav.isStopped = true;
        }
    }
}
