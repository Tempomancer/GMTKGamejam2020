using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public float speed;
    public int health = 10;

    public TMPro.TextMeshProUGUI healthDisplay;
    public TMPro.TextMeshProUGUI levelDisplay;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Scene currentScene;
    

    //Dash Variables
    private float dashTime;
    [SerializeField] private float startDashTime;
    private float timeBtwDash;
    [SerializeField] private float startTimeBtwDash;

    [SerializeField] private float dashSpeed;
    private bool dashing;



    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health :" + health;

        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashTime <= 0f && timeBtwDash <= 0f){
            if(moveInput.x== 0f && moveInput.y==0f){
                return;
            }else{
                print("Le Input: " + moveInput.x + moveInput.y);
                timeBtwDash = startTimeBtwDash;
                dashTime = startDashTime;
                dashing = true;
            }
            
            
        }
        
        if(timeBtwDash > 0){
            timeBtwDash -= Time.deltaTime;
        }

        if(dashTime > 0){
            dashTime -= Time.deltaTime;
        }else if(dashTime <= 0){
            dashing = false;
        }

        if(dashing == true){
            if(moveInput.x > 0 && moveInput.y == 0){            //1,0      
                rb.velocity = new Vector2(dashSpeed, 0);
            } else if (moveInput.x < 0 && moveInput.y == 0){    //-1,0
                rb.velocity = new Vector2(-dashSpeed, 0);
            } else if(moveInput.y > 0 && moveInput.x == 0){     //0,1
                rb.velocity = new Vector2(0, dashSpeed);
            } else if(moveInput.y < 0 && moveInput.x == 0){     //0,-1
                rb.velocity = new Vector2(0, -dashSpeed);
            } else if(moveInput.x > 0 && moveInput.y > 0){      //1,1
                rb.velocity = new Vector2(dashSpeed, dashSpeed);
            } else if(moveInput.x < 0 && moveInput.y > 0){      //-1,1
                rb.velocity = new Vector2(-dashSpeed, dashSpeed);
            } else if(moveInput.x > 0 && moveInput.y < 0){      //1,-1
                rb.velocity = new Vector2(dashSpeed, -dashSpeed);
            }else if(moveInput.x < 0 && moveInput.y < 0){      //-1,-1
                rb.velocity = new Vector2(dashSpeed, -dashSpeed);
            }
        }
        //     if(Input.GetAxis("Horizontal")>0){
        //         direction = 1;//Right
        //     }else if(Input.GetAxis("Horizontal")<0){
        //         direction = 2;//Left
        //     }
        //     if(Input.GetKey(KeyCode.W)){
        //         direction = 3;//Up
        //     }else if(Input.GetKey(KeyCode.S)){
        //         direction = 4;//Down
        //     }
        // if(Input.GetKeyDown(KeyCode.LeftShift)){
        //     if(dashTime <= 0){
        //         dashTime = startDashTime;
        //         rb.velocity = Vector2.zero;
        //     }else{
        //         dashTime -= Time.deltaTime;

        //         if(direction == 1){
        //             rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
        //         }else if(direction == 2){
        //             rb.velocity = new Vector2(-dashSpeed, rb.velocity.y);
        //         }
        //         if(direction == 3){
        //             rb.velocity = new Vector2(rb.velocity.x, dashSpeed);
        //         }else if(direction == 4){
        //             rb.velocity = new Vector2(rb.velocity.x, -dashSpeed);
        //         }
        //     }
                
        // }
            
            
    }
        

        
    

    

    void FixedUpdate()
    {
        if(!dashing){
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime); 
        }
    }
}
