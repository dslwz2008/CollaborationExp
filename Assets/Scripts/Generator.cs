using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Generator.
/// version : 0.5
/// </summary>
public class Generator : MonoBehaviour {
    public bool isPause = false;
	/// <summary>
	/// The charactors. user specified prefabs.
	/// </summary>
	public List<GameObject> charactors;
	
	/// <summary>
	/// The last frame data
	/// </summary>
	Frame lastFrame = null;

    GameObject parent = null;
    
    /// <summary>
	/// The time of one frame.
	/// </summary>
	public float frameTime = 0.1f;

    public AudioSource[] audioSources;

	private bool hasFinished = false;
    private FrameBuffer frameBuffer;

    // Use this for initialization
    void Start ()
    {
        //gameObject.SendMessage("SimulationFinished");
        parent = GameObject.Find("/Instances");
        frameBuffer = GetComponent<FrameBuffer>();
        if (!frameBuffer)
        {
            Debug.Log("Frame Buffer Error£¡");
            return;
        }

        InvokeRepeating("GenerateOneFrame", 1.5f, frameTime);
        LeanTween.init(800);
	}

    void Update() {
    }
	
	void GenerateOneFrame(){
		if(isPause || hasFinished)
		{
			return;
		}

		Queue<Frame> queue = frameBuffer.queue;
		Frame thisFrame = null;
		if(queue.Count == 0){
            foreach (Transform people in parent.transform)
            {
                if (people.gameObject.GetComponent<Animation>())
                {
                    people.gameObject.GetComponent<Animation>().wrapMode = WrapMode.Loop;
                    people.gameObject.GetComponent<Animation>().CrossFade("idle");
                }
            }
            //CancelInvoke("GenerateOneFrame");
            hasFinished = true;
            gameObject.SendMessage("SimulationFinished");
            return;
		}else{
			thisFrame = queue.Dequeue();
		}
		//Debug.Log(thisFrame.id + "generating...");
		
		//this is the first frame
		if(lastFrame == null){
            foreach (int id in thisFrame.peoples.Keys)
            {
				int chrctIndex = (int)UnityEngine.Random.Range(0, charactors.Count);
                People person = thisFrame.peoples[id];
                GameObject instance = (GameObject)Instantiate(
                    charactors[chrctIndex],
                    new Vector3(person.PositionX, person.PositionZ, person.PositionY),
                    Quaternion.Euler(0.0f, 0.0f, 0.0f));

                instance.name = "people" + id.ToString();
				instance.transform.parent = parent.transform;
				instance.transform.localScale = Vector3.one;
                Animation anim = instance.gameObject.GetComponent<Animation>();
                if (anim)
                {
                    anim.wrapMode = WrapMode.Loop;
                    anim.Play("idle");
                    foreach (AnimationState state in anim)
                    {
                        state.speed = UnityEngine.Random.Range(0.8f, 1.2f);
                    }
                }
            }
            gameObject.SendMessage("InitialFinished", thisFrame.peoples.Count);
        }
        else{
            foreach (int id in thisFrame.peoples.Keys)
            {
                string name = "/Instances/people" + id.ToString();
                People person = thisFrame.peoples[id];

                GameObject goPeople = GameObject.Find(name);
                Vector3 pos = new Vector3(person.PositionX, person.PositionZ, person.PositionY);
                PeopleStatus status = (PeopleStatus)person.Status;
                //goPeople.transform.position = pos;
                LeanTween.move(goPeople, pos, frameTime).setEase(LeanTweenType.linear);
                goPeople.transform.forward = new Vector3(person.OrientationX, 0, person.OrientationY);
                Animation anim = goPeople.gameObject.GetComponent<Animation>();
                if (status == PeopleStatus.WALK)
                {//walk
                 //play animation
                    if (anim)
                    {
                        anim.wrapMode = WrapMode.Loop;
                        anim.CrossFade("walk");
                    }
                }
                else if (status == PeopleStatus.RUN)
                {//run
                 //play animation
                    if (anim)
                    {
                        anim.wrapMode = WrapMode.Loop;
                        anim.CrossFade("run");
                    }
                }
                else if (status == PeopleStatus.IDLE || status == PeopleStatus.STAND)
                {//idle, on the escalator
                 //play animation
                    if (anim)
                    {
                        anim.wrapMode = WrapMode.Loop;
                        anim.CrossFade("idle");
                    }
                }
                //else if (status == PeopleStatus.ARCH_RUN) {

                //}
            }
		}
		lastFrame = thisFrame;
	}

    //IEnumerator ReStart()
    //{
    //    yield return new WaitForSeconds(2);
    //    hasFinished = false;
    //    Debug.Log("restart!");
    //}
}
