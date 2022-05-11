using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    #region  PUBLIC VARIABLES

    public float rotationSpeed=10f;          //Rotaion of  ship  in degrees per second
    public float movementSpeed=20f;          //The movement of ship by force applied in per second

    #endregion

    #region PRIVATE VARIABLES

   private bool isRotating=false;
    private const string TURN_COROUTINE_FUNCTION = "";
    #endregion

    #region MONOBEHAVIOUR METHODS
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()                //When gameobject is active ,then we are subscribing 
    {
        // MyMobileGameSpace.UserInputHandler.onTapAction+=TowardsTouch;
    }

    private void OnDisable()                 //When gameobject is inactive ,then we are desubscribing 
    {
        // MyMobileGameSpace.UserInputHandler.onTapAction -=TowardsTouch;
    }

    #region MY PUBLIC METHODS
    #endregion

    public void TowardsTouch(Touch touch)
    {
      Vector3 worldTouchPosition=  Camera.main.ScreenToWorldPoint(touch.position);    //It converts screen from pixels coordinates  to world coordinates
    }

    #region MY PRIVATE METHODS
    #endregion
}
