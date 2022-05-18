using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyMobileGameSpace
{
    public class UserInputHandler : MonoBehaviour
    {
        #region EVENTS

        public delegate void TapAction(Touch touch);
        public static event TapAction onTapAction;


        //when the user presses and drags on the screen. if the user removes too quickly then its considered as tap
        public delegate void PanBeganAction(Touch t);
        public static event PanBeganAction OnPanBegan;

        public delegate void PanHeldAction(Touch t);
        public static event PanHeldAction OnPanHeld;

        public delegate void PanEndedAction(Touch t);
        public static event PanEndedAction OnPanEnded;

        public delegate void AccelerometerChangedAction(Vector3 acceleration);   //To check acclerometer action
        public static event AccelerometerChangedAction OnAccelerometerChanged;

        #endregion

        #region  PUBLIC VARIABLES

        public float tapMaxMovement=50f;                    //Maximum pixel a tap can move
        private Vector2 movement;                         //Movement vector will track how far you move
        private bool tapGestureFailed=false;             //Tap gesture will become true ,if tap moves too far

        public float panMinTime = 0.4f;//tap gesture lasts more than minumum time

        private float startTime;//will keep time when our gesture begins


        private bool panGestureRecognized = false;// when we recognize gesture we gone make true
        private Vector3 defaultAcceleration;
        #endregion

        #region PRIVATE VARIABLES
        #endregion

        #region MONOBEHAVIOUR METHODS
        #endregion

        void Start()
        {
            
        }

        void Update()
        {
            startTime = Time.time;
            if (Input.touchCount>0)   //To figure it out,no.of touches greater 0 or not.If no touches ,no movement
            {
             Touch touch  = Input.touches[0]; //Need to find out no.of touches on the screen.If there are more no.of touches ,need to call array

                if (touch.phase == TouchPhase.Began)   //If  we have several touch phases ,began enters the first frame of the touch 
                {
                    movement = Vector2.zero;        //We made our movement to zero
                }

                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    movement += touch.deltaPosition;   //The position delta since last change in pixel coordinates
                    if (movement.magnitude > tapMaxMovement)
                    {
                        tapGestureFailed = true;
                    }
                }



                else    //If finger is removed,then we are calling tap gesture is  
                {
                    if (!tapGestureFailed)
                    {
                        if (onTapAction != null)
                        {
                            onTapAction(touch);
                        }

                        tapGestureFailed = false;     // ready for the next tap
                    }
                }
            }
        }

        void OnEnable()
        {
            defaultAcceleration = new Vector3(Input.acceleration.x, Input.acceleration.y, -1 * Input.acceleration.z);
        }


        #region MY PUBLIC METHODS
        #endregion
    }
}
