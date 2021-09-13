using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public GameObject enemy;
	public GameObject ball;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovementDirection();

    }
	
	private void calculateMovementDirection(){
		if(ball.transform.position.y > enemy.transform.position.y && enemy.transform.position.y < 4){
			movePaddle(1);
		}
		if(ball.transform.position.y < enemy.transform.position.y && enemy.transform.position.y > -4){
			movePaddle(-1);
		}
	}
	
	private void movePaddle(int direction){
		enemy.transform.position += (Vector3)((direction*Vector2.up)*enemySpeed*Time.deltaTime);
	}
}
