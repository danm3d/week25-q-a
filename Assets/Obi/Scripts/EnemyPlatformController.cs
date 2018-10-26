using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformController : RigidbodyPlatformController
{
	protected Transform playerTransform;

	public float fireRate;

	protected float timer;

	protected float distanceToPlayer = 0;

	public float thresholdDistanceToFollow = 12;

	public float stoppingDistance = 3;

	public float firingDistance = 5;


	public override void Start()
	{
		base.Start();
		PlayerPlatformController player = FindObjectOfType<PlayerPlatformController>();
		if (player != null)
		{
			playerTransform = player.transform;
		}
	}

	private void Update()
	{
		if (playerTransform != null)
		{
			distanceToPlayer = playerTransform.position.x - transform.position.x;
			Debug.LogFormat("Distance to Player: <color=red>{0}</color>", distanceToPlayer);
		}
		if (distanceToPlayer < thresholdDistanceToFollow && distanceToPlayer > stoppingDistance)
		{
			Move(new Vector2(distanceToPlayer > 0 ? 1 : -1, 0));
		}
		timer -= Time.deltaTime;
		if (distanceToPlayer < firingDistance && timer <= 0)
		{
			Shoot();
			timer = fireRate;
		}
	}

	public override void Move(Vector2 movementVector)
	{
		base.Move(movementVector);
		body.AddForce(movementVector * movementSpeed);
	}
}
