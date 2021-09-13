using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//code via stack overflow user Dias
	//https://stackoverflow.com/a/37002354
	//https://stackoverflow.com/users/3592811/dias
public float screenHeight = 1920f;
public float screenWidth = 1080f;
public float targetAspect = 9f / 16f;
public float orthographicSize;
public Camera mainCamera;

// Use this for initialization
void Start () {

    // Initialize variables

    orthographicSize = mainCamera.orthographicSize;

    // Calculating ortographic width
    float orthoWidth = orthographicSize / screenHeight * screenWidth;
    // Setting aspect ration
    orthoWidth = orthoWidth / (targetAspect / mainCamera.aspect);
    // Setting Size
    Camera.main.orthographicSize = (orthoWidth / Screen.width * Screen.height);
	}
}
