using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : RigidbodyPlatformController
{
	public override void Start()
	{
		base.Start();
	}

	private void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");

		Move(new Vector2(x, 0));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}

		if (Input.GetMouseButtonDown(1))
		{
			Shoot();
		}
	}

	public override void Move(Vector2 movementVector)
	{
		base.Move(movementVector);
		body.AddForce(movementVector * movementSpeed);
	}
}
