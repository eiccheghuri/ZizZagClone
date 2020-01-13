using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float ball_speed;

    private bool is_gameStarted=false;

    [HideInInspector]
    public bool is_gameOver = false;

    private Rigidbody ball_rigidbody;
    [SerializeField]
    private CameraFollow camera_follow;

    [SerializeField]
    private TextMeshProUGUI score_text;
    private int scoreCount;

    [SerializeField]
    private GameObject particles;

    private void Awake()
    {
        ball_rigidbody = GetComponent<Rigidbody>();
    }//awake

    private void Start()
    {
        
    }//start

    public void Update()
    {

        if(!is_gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ball_rigidbody.velocity = new Vector3(0, 0, ball_speed);
                is_gameStarted = true;
            }
            
            
        }


        GroundChecking();


        if (Input.GetMouseButtonDown(0) && !is_gameOver)
        {
            SwitchDirection();
        }



    }//fixed update

    public void SwitchDirection()
    {
        if (ball_rigidbody.velocity.z > 0)
        {
            ball_rigidbody.velocity = new Vector3(ball_speed, 0, 0);
        }
        else if (ball_rigidbody.velocity.x > 0)
        {
            ball_rigidbody.velocity = new Vector3(0, 0, ball_speed);
        }
    }//switch direction


    public void GroundChecking()
    {
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            is_gameOver = true;
            ball_rigidbody.velocity = new Vector3(0,-25f,0);
            camera_follow.is_gameOver = true;
            UiManager.Instance.score = scoreCount;//reference to ui manager
            UiManager.Instance.GameOver();
        }
        
    }



    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("diamond"))
        {
            Destroy(other.gameObject);
            getneratePaticles(other.transform.position);
            ScoreCounter();
            
            
        }
    }

    public void ScoreCounter()
    {
        scoreCount++;
        score_text.text = "Score:"+scoreCount;

    }

    public void getneratePaticles(Vector3 particles_postion)
    {

        GameObject temp = Instantiate(particles,particles_postion,Quaternion.identity) as GameObject;
        Destroy(temp,1f);
    }





}//class