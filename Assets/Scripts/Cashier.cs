using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Cashier : MonoBehaviour
{
    public bool canTryAgain;
    public GameObject GameOverScreen;
    public bool startRun;
    private NavMeshAgent cashier;
    [SerializeField]
    private Transform target;

    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        
        canTryAgain = false;
        GameOverScreen.SetActive(false);
        startRun = false;
        cashier = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startRun){
        animator.SetBool("Victory",false);
        animator.SetBool("isMoving", true);
        cashier.SetDestination(target.position);
        }
        if(!startRun){
            animator.SetBool("Victory",true);
           // animator.SetBool("isMoving", false);
            
            //animator.SetBool("Winning",true);
        }
        if(canTryAgain){
            if(Input.GetKeyDown(KeyCode.R)){
                LoadScene();
            }
        }
        //endIf (if player touched = gameover)
        //if player get to place stop following
    }

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            //Destroy(col.gameObject);
            startRun = false;
            col.gameObject.SetActive(false);
            LoseGame();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Level01");
    }
    public void LoseGame(){
            GameOverScreen.SetActive(true);
            canTryAgain = true;
    }
}
