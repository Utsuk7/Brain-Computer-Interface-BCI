using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;

    public CoinManager cm;
    

   IEnumerator Respawn(Collider2D collision,int time)
   {
    yield return new WaitForSeconds(time);
    collision.gameObject.SetActive(true);
   }
   void OnTriggerEnter2D(Collider2D other)
   {
    
        if(other.gameObject.CompareTag("Coin"));
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            cm.coinCount++;

            
            StartCoroutine(Respawn(other,2));
        }
   }
    void Start()
    {
        //Grab references for rigidbody and animator from object
        body=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput=Input.GetAxis("Horizontal"); 
        
        // for changing sprite direction when moving left and right
        if(horizontalInput>0.1f)
        //transform.localScale=Vector3.one;
        transform.localScale=new Vector3(1.5f,1.5f,1);
        else if(horizontalInput<-0.1f)
        transform.localScale=new Vector3(-1.5f,1.5f,1);

        body.velocity=new Vector2(Input.GetAxis("Horizontal")*speed,body.velocity.y);

        //if(Input.GetKey)

        //set animator paramter to transform from idle to run state and vice versa
        animator.SetBool("run",horizontalInput!=0); 

        // to handle collision with walls
        onWall();
        isGrounded();
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit= Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider!=null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit=Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,new Vector2(transform.localScale.x,0),0.1f,wallLayer);
        return raycastHit.collider!=null;
    }

    
}
