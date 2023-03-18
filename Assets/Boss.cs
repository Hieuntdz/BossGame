using UnityEngine;

public class Boss : MonoBehaviour
{

	public Transform player;

	public void Update(){
		LookAtPlayer();
	}

	public void LookAtPlayer()
	{
	
		if (transform.position.x > player.position.x)
		{
			transform.localScale = new Vector3(-0.2f , 0.2f , 1f);
		}
		else if (transform.position.x < player.position.x )
		{
			transform.localScale = new Vector3(0.2f , 0.2f , 1f);
		}
	}
}