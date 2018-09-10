using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
	public float enemySpeed, maxDistance, minDistance, currentDistance, minHeight, currentHeight;
	private Transform player, enemy;

	void Start ()
	{
		
	}
	void Update ()
	{
		//Setting transforms for ease
		enemy = this.gameObject.transform;
		player = GameObject.Find("RigidBodyFPSController").transform;
		//Raycast a line to player
		Physics.Linecast(enemy.position, player.position);
		//Draw the line for debug
		Debug.DrawLine(enemy.position, player.position);
		//Setting current height
		currentHeight = enemy.position.y;
		Debug.Log(currentHeight);
		//Calculating current distance
		currentDistance = Vector3.Distance(enemy.position, player.position);
		//Too far away? Start to move then!
		if(currentDistance < maxDistance && currentDistance > minDistance && currentHeight > minHeight)
		{
			Debug.Log(currentDistance);
			//Moving towards player
			enemy.position = Vector3.MoveTowards(enemy.position, player.position, enemySpeed * Time.deltaTime);
		}
		else if(currentHeight <= minHeight)
		{
			enemy.position = Vector3.Lerp(enemy.position, enemy.position + new Vector3(0, minHeight - currentHeight + 1, 0), Time.deltaTime * enemySpeed);
		}
	}
}