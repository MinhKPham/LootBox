using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour {

	public float hp = 100;
	public bool isInOpeningSequence = false;
	public int subSpawnCount = 5;
	public int timeCounter = 0;
	public int timeTilSpawnStart = 100;
	public int timeTilNextSpawn = 50;
	public float force = 100;
	public bool readyForDestruction = false;

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate()
	{
		if(hp <= 0 && !isInOpeningSequence)
		{
			isInOpeningSequence = true;
		}
		if(isInOpeningSequence)
		{
			OpenLootBox();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OpenLootBox()
	{
		if(timeCounter >= timeTilSpawnStart + timeTilNextSpawn * (subSpawnCount + 1))
		{
			Destroy(this.gameObject);
		}
		else
		{
			if(timeCounter > timeTilSpawnStart && (timeCounter - timeTilSpawnStart) % timeTilNextSpawn == 0)
			{
				GameObject subLootbox = Instantiate(Resources.Load("LootBoxPrefab"), this.transform.position, this.transform.rotation) as GameObject;
				Physics.IgnoreCollision(subLootbox.GetComponent<Collider>(), GetComponent<Collider>());
				subLootbox.GetComponent<Rigidbody>().AddForce(force * Vector3.up + (force * Random.insideUnitSphere.normalized));
			}
			timeCounter ++;
		}


	}

	void DamageMe()
	{

	}

}
