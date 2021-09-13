using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getPlayerInput();
    }
    
    private void getPlayerInput(){
        moveUp();
        moveDown();
		quitGame();
    }
    private void moveUp(){
        if(Input.GetKey(KeyCode.W) && player.transform.position.y < 4){

            player.transform.position += (Vector3)(Vector2.up*playerSpeed*Time.deltaTime);
        }
    }
    private void moveDown(){
        if(Input.GetKey(KeyCode.S) && player.transform.position.y > -4){
            player.transform.position += (Vector3)(Vector2.down*playerSpeed*Time.deltaTime);
        }
    }
	
	private void quitGame(){
		if(Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}
}
