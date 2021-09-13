using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    public float ballSpeed;
    public Rigidbody2D ballRigidBody;
    private Vector2 velocityRecordKeeper;
	private ScoreKeeper scoreKeeper;
	public SpriteRenderer sprite;
	private float darknessIncrement =0.0F;
	
    void Start()
    {

		scoreKeeper = new ScoreKeeper();
        ballRigidBody.velocity = createInitialVelocity();
    }

    void Update()
    {
        checkScores();
    }
    
    void OnCollisionEnter2D(Collision2D collision){
		var newVelocity = Vector2.Reflect(velocityRecordKeeper, collision.GetContact(0).normal).normalized*velocityRecordKeeper.magnitude;
		//credit to steve7411 for help in this calculation as well as many unity tips
		setNewVelocity(newVelocity);
    }
	
	void OnTriggerEnter2D(Collider2D collision){
		if(collision.tag=="EnemyGoal"){
			setlighenerColor();
			scoreKeeper.playerScoreIncrement();
		} else if(collision.tag =="PlayerGoal"){
			setDarkenerColor();
			scoreKeeper.enemyScoreIncrement();
		}
		resetBallPosition();
	}
	
	private void setDarkenerColor(){
		darknessIncrement+=0.07f;
		sprite.color = new Color(0.3f,0.3f,0.3f,darknessIncrement);
	}
	private void setlighenerColor(){
		darknessIncrement-=0.07f;
		sprite.color = new Color(0.3f,0.3f,0.3f,darknessIncrement);
	}
	
	private void resetBallPosition(){
		ball.transform.position = new Vector2(0,0);
		ballRigidBody.velocity =createInitialVelocity();
	}
    
    private Vector2 createInitialVelocity(){
        Vector2 ballVelocity = new Vector2(Random.Range(-ballSpeed, ballSpeed),Random.Range(-ballSpeed, ballSpeed));
        if (ballVelocity.x <= 15 && ballVelocity.x >= -15){
            return createInitialVelocity();
        }
		velocityRecordKeeper = ballVelocity;
        return ballVelocity;
    }
	
	private void setNewVelocity(Vector2 newVelocity){
		
        ballRigidBody.velocity = newVelocity;
		velocityRecordKeeper= newVelocity;
	}
	
	
	private void checkScores(){
		checkPlayerScore();
		checkEnemyScore();
	}
	private void checkPlayerScore(){
		if(scoreKeeper.getPlayerScore() >= 10){
			Application.Quit();
		}
	}
		private void checkEnemyScore(){
		if(scoreKeeper.getEnemyScore() >= 10){
			Application.Quit();
		}
	}
}
