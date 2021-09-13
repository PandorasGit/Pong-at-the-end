using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper
{
	private int playerScore=0;
	private int enemyScore=0;
	public void playerScoreIncrement(){
		playerScore+=1;
	}
	
	public void enemyScoreIncrement(){
		enemyScore+=1;
	}
	public int getPlayerScore(){
		return playerScore;
	}
	public int getEnemyScore(){
		return enemyScore;
	}
}
