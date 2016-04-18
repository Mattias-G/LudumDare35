using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
	public Transform objectToSpawn;

	[Range(0f, 10f)]
	public float initialSpawnInterval = 0;
	[Range(0.5f, 10f)]
	public float spawnInterval = 2;
	[Range(0, 5f)]
	public float randomIntervalLengthOffset = 0;

	float timeUntilSpawn;

	void Start ()
	{
		timeUntilSpawn = initialSpawnInterval;
	}
	
	void Update ()
	{
		timeUntilSpawn -= Time.deltaTime;
		if (timeUntilSpawn < 0)
		{
			Instantiate(objectToSpawn, gameObject.transform.position, gameObject.transform.rotation);
			SetNextSpawnTime();
		}
	}

	private void SetNextSpawnTime()
	{
		timeUntilSpawn += spawnInterval + Random.Range(-randomIntervalLengthOffset, randomIntervalLengthOffset);
	}
}
