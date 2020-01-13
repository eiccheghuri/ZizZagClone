using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject ball_player;

    private Vector3 camera_offset;
    [SerializeField]
    private float camera_smooth_value;
    private Vector3 ball_player_positon;
   
   
    public bool is_gameOver=false;

    public void Start()
    {
        camera_offset = ball_player.transform.position - transform.position;
    }

    public void FixedUpdate()
    {


       

        if (!is_gameOver)
        {
            
            cameraMovement();
        }
        
    }

    public void cameraMovement()
    {
        Vector3 target_position = ball_player.transform.position - camera_offset;
        transform.position=Vector3.Lerp(transform.position,target_position,camera_smooth_value*Time.deltaTime);
        transform.LookAt(ball_player.transform);
       

    }



}//camera follow