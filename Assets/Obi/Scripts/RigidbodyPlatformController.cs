using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class RigidbodyPlatformController : MonoBehaviour
{
	public float jumpForce = 5f;
	public float movementSpeed = 1f;

	public GameObject projectilePrefab;
	public Transform firePoint;
	public float projectileForce;

	public Transform lookAtTransform;

	protected Rigidbody body;

	public virtual void Start()
	{
		Debug.Log("Set Up RigidBody");
		body = GetComponent<Rigidbody>();
	}

	public virtual void Move(Vector2 movementVector)
	{
		lookAtTransform.position = transform.position + Vector3.right * movementVector.x;
		transform.LookAt(lookAtTransform);
	}
	public virtual void Jump()
	{
		Debug.Log("Jump");
		body.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
	}
	public virtual void Shoot()
	{
		GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
		Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
		if (bulletBody != null)
		{
			bulletBody.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);

			Destroy(bullet.gameObject, 4f);
		}
	}
}
