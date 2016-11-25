﻿using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{

	public bool isNonShoot;
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;

	void Awake ()
	{
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript> ();

		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript> ();
	}

	void Start ()
	{
		hasSpawn = false;

		// Disable everything
		// -- collider
		GetComponent<Collider2D> ().enabled = false;
		// -- Moving
		moveScript.enabled = false;
		// -- Shooting
		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = false;
		}
	}

	void Update ()
	{
		// Check if the enemy has spawned
		if (hasSpawn == false) {
			if (GetComponent<Renderer> ().IsVisibleFrom (Camera.main)) {
				Spawn ();
			}
		} else {
			if (!isNonShoot) {
				// Auto-fire
				foreach (WeaponScript weapon in weapons) {
					if (weapon != null && weapon.enabled && weapon.CanAttack) {
						weapon.Attack (true);
						SoundEffectsHelper.Instance.MakeEnemyShotSound ();
					}
				}
			}

			// Out of camera?
			if (GetComponent<Renderer> ().IsVisibleFrom (Camera.main) == false) {
				Destroy (gameObject);
			}
		}
	}

	private void Spawn ()
	{
		hasSpawn = true;

		// Enable everything
		// -- Collider
		GetComponent<Collider2D> ().enabled = true;
		// -- Moving
		moveScript.enabled = true;
		// -- Shooting
		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = true;
		}
	}
}