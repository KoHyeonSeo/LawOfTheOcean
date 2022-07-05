using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private GameObject user;
    private float damage;
    //��ų� ����ϴ� User�� �������� �� �� �ִ� �����Ƽ
    public GameObject User { get { return user; } set { user = value; } }
    //������ ��, Power�� ��� ������� �� �� �ִ� �����Ƽ
    public float BulletDamage { get { return damage; } set { damage = value; } }
    
    public Transform target;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        target = player.transform;
        dir = target.position - transform.position;
        dir.Normalize();
        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        transform.rotation = rot;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ���� ��ų ����ڰ� �ƴϰ� ���ü(Entity)���
        if (other.gameObject != user && other.gameObject.layer == 7)
        {
            //Player��� ������ ���
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
            }
            //Enemy��� ������ ���
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
            //�Ѿ� ���
            Destroy(gameObject);
        }

    }
}
