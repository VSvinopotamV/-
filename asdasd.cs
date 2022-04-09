using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
public class asdasd:MonoBehaviour
{
    Transform pl;
    CharacterController cont;
    public float speed=12f;
    float gravity=-9.81f;
    bool isGrounded=false;
    int time=60;
    public GameObject cyl;
    public GameObject win;
    public GameObject lose;
    
    [SerializeField] TextMeshProUGUI sec;

    void timeM(){
        time=time-1;
        sec.text="Осталось: "+time+" сек" ;
        if (time==0){
            CancelInvoke();
            lose.SetActive(true);
            Destroy(cont);
        }


    }
    void Start(){
        InvokeRepeating("timeM",1f,1f);
        pl=GetComponent<Transform>();
        cont=GetComponent<CharacterController>();

    }
    void Update(){
        float mouse=Input.GetAxis("Mouse X");
        float vertical=Input.GetAxis("Vertical");
        cont.Move(pl.up*gravity*Time.deltaTime);
        cont.Move(pl.forward*vertical*speed*Time.deltaTime);
        pl.Rotate(0,mouse,0);
        if(Input.GetKeyDown("space")&& isGrounded==true){
            cont.Move(pl.up*5f);

        }else{
            isGrounded=false;
        }

    }

    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag=="ground"){
            isGrounded=true;
        }
        if(col.gameObject.tag=="win"){
            Destroy(col.gameObject);
            CancelInvoke();
            cyl.SetActive(true);
            win.SetActive(true);
            
        }
    }


}