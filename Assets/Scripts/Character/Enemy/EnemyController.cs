using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour/*,IDamageable*/
{
    //Transform player;
    //NavMeshAgent nav;
    //public float minDistancePlayer;
    //[SerializeField] Animator _animator;
    //public bool isHit = false;
    //public float health = 1000f;
    //[SerializeField] Image _valueHealthImg;
    //[SerializeField] ParticleSystem _explosionBodyBloody;
    //public enum StateEnemy
    //{
    //    run,
    //    shoot,
    //    idle,
    //    die,
    //}
    //public StateEnemy stateEnemy;
    //void Awake()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //    nav = GetComponent<NavMeshAgent>();
    //    StateRun();
    //}

    //void Update()
    //{
    //    nav.SetDestination(player.position);
    //    if (Vector3.Distance(player.position, transform.position) <= minDistancePlayer/*&& !isHit*/)
    //    {
    //      //  StateHit();
    //     //   isHit = true;
    //        nav.speed = 1f;
    //      //  StateRun();
    //    }
    //    else
    //    {
    //        nav.speed = 5f;
    //    }
    //    //else
    //    //{
    //    //    StateIdle();
    //    //}
    //}
    //public void StateIdle()
    //{
    //    _animator.SetBool("Run", false);
    //}
    //public void StateRun()
    //{
    //    _animator.SetBool("Run", true);
    //}
    //public void StateHit()
    //{
    //    _animator.SetTrigger("Hit");
    //}
    //public void Damage()
    //{
    //    health=health - 200f;
    //    _valueHealthImg.fillAmount = health / 1000f;
    //    if (health==0)
    //    {
    //        Die();
    //    }
    //}
    //void Die()
    //{
    //    stateEnemy = StateEnemy.die;
    //    gameObject.SetActive(false);
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag.Equals("Bullet"))
    //    {
    //        _explosionBodyBloody.transform.position = collision.gameObject.transform.position;
    //        _explosionBodyBloody.gameObject.SetActive(true);
    //        _explosionBodyBloody.Play();

    //        if (stateEnemy != StateEnemy.die)
    //        {
    //            StartCoroutine(WaitTimeStopParticle());
    //        }
    //        //IDamageable Damage = collision.gameObject.GetComponent<IDamageable>();
    //        //if (Damage != null)
    //        //{
    //        //    Damage.Damage();
    //        //}
    //        //ObjectPooler._instance.AddElement("Bullet", transform.gameObject);
    //        //transform.gameObject.SetActive(false);
    //    }

    //}
    //IEnumerator WaitTimeStopParticle()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    _explosionBodyBloody.Stop();
    //    //_explosionBodyBloody.gameObject.SetActive(false);
    //}


    public NavMeshAgent agent;

    public Transform player;
    public GameObject gun;

    //Stats
    public int health;

    //Check for Ground/Obstacles
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public bool isDead;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Special
  //  public Material green, red, yellow;
    public GameObject projectile;
    public Animator _animator;

    // Gun 
    public Transform FireSpawn;

    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!isDead)
        {
            //Check if Player in sightrange
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

            //Check if Player in attackrange
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (isDead) return;

        if (!walkPointSet) SearchWalkPoint();

        //Calculate direction and walk to Point
        if (walkPointSet)
        {
            StateRun();
            agent.SetDestination(walkPoint);

            //Vector3 direction = walkPoint - transform.position;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
        }

        //Calculates DistanceToWalkPoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
           // StateIdle();
            walkPointSet = false;

        }    
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        if (isDead) return;
        StateRun();
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        if (isDead) return;

        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            StateHit();
            Debug.Log("Attack player");

            ////Attack
            StartCoroutine(WaitTimeBullet());
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }
    //public void Shoot()
    //{
    //    StartCoroutine(WaitTimeBullet());
    //}
    IEnumerator WaitTimeBullet()
    {
        GameObject Bullet = ObjectPooler._instance.SpawnFromPool("Bullet", FireSpawn.position, FireSpawn.rotation);

        //Rigidbody bulletRg = Bullet.GetComponent<Rigidbody>();
        //bulletRg.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //bulletRg.AddForce(transform.up * 8, ForceMode.Impulse);

        Vector3 targetFirePoint = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z);
        Bullet.GetComponent<Bullet>()._firePoint = targetFirePoint;
        Bullet.GetComponent<Bullet>().Fly();

        alreadyAttacked = true;

        yield return new WaitForSeconds(timeBetweenAttacks);
        ObjectPooler._instance.AddElement("Bullet", Bullet);
        Bullet.SetActive(false);
    }
    private void ResetAttack()
    {
        if (isDead) return;

        alreadyAttacked = false;
        _animator.ResetTrigger("Hit");
    }
    public void StateIdle()
    {
        _animator.ResetTrigger("Hit");
        _animator.SetBool("Run", false);
    }
    public void StateRun()
    {
        _animator.ResetTrigger("Hit");
        _animator.SetBool("Run", true);
    }
    public void StateHit()
    {
        _animator.SetBool("Run", false);
        _animator.SetTrigger("Hit");
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            isDead = true;
            Invoke("Destroyy", 2.8f);
        }
    }
    private void Destroyy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
