using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public GameObject hitVFX;
	public float lifeTime = 3;
	public float damage = 1;

	void Start()
	{
		Destroy(gameObject, lifeTime);
	}

	void OnTriggerStay(Collider hit)
	{
		if(hitVFX) Instantiate(hitVFX, transform.position, transform.rotation);

		if(hit.CompareTag("Enemy"))
		{
			hit.GetComponent<EnemyController>().EnterGetHit(damage, transform.position);
		}

		Destroy(gameObject);
	}
}