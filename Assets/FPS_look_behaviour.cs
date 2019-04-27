using UnityEngine;
using System.Collections;

public class FPS_look_behaviour : MonoBehaviour {

    bool state_look_first = false;
    bool state_look_second = false;

    float normalize = 0.0005f;
    float normalize_look = 0.01f;

    float position_x_first;
    float position_y_first;
    float position_x_second;
    float position_y_second;

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0)   // first_finger
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

                position_x_first = Input.GetTouch(0).position.x;
                position_y_first = Input.GetTouch(0).position.y;

                if (position_x_first >= 1280) state_look_first = true;

            }


            //looking

            if (state_look_first == true)
            {

                //float look_x = Input.GetTouch(0).position.x;
                float look_y = Input.GetTouch(0).position.y;

                //look_x = look_x - position_x_first;
                look_y = look_y - position_y_first;

                transform.Rotate(-look_y * normalize_look, 0, 0);
                //transform.Rotate(0, look_x * normalize_look, 0);

                if (Input.GetTouch(0).phase == TouchPhase.Ended) state_look_first = false;

            }

        }


        if (Input.touchCount > 1)  //2nd finger
        {

            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {

                position_x_second = Input.GetTouch(1).position.x;
                position_y_second = Input.GetTouch(1).position.y;

                if (position_x_second >= 1280) if (state_look_first == false) state_look_second = true; //640

            }


            //looking

            if (state_look_second == true)
            {

                //float look_x_s = Input.GetTouch(1).position.x;
                float look_y_s = Input.GetTouch(1).position.y;

                //look_x_s = look_x_s - position_x_second;
                look_y_s = look_y_s - position_y_second;

                transform.Rotate(-look_y_s * normalize_look, 0, 0);
                //transform.Rotate(0, look_x_s * normalize_look, 0);

                if (Input.GetTouch(1).phase == TouchPhase.Ended) state_look_second = false;

            }

        }

    }

}