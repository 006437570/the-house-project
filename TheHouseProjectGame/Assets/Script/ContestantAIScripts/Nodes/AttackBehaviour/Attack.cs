using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	//[SerializeField] private LayerMask mask;

	[SerializeField] private float damage;


	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//Debug.Log("Click!");
			Shoot();
		}
	}

	private void Shoot()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			ContestantAI ai = hit.collider.GetComponent<ContestantAI>();
			if (ai != null)
			{
				ai.TakeDamage(damage);
			}
		}
	}
}