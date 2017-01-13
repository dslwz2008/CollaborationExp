using UnityEngine;
using System.Collections;
using System.IO;

public class ReadAndParseDataFromDB : MonoBehaviour
{
    public string dbName = "evacuation.db";

    public float interval = 0.1f;
    public int linesPerRead = 10000;
    private int linesPerFrame = 0;
    private int startLine = 0;
    private int frameID = 0;
    private FrameBuffer frameBuffer;
    
    private string debugInfo = "";

    void Awake()
    {
        frameBuffer = GetComponent<FrameBuffer>();
        if(!frameBuffer)
        {
            Debug.Log("Frame Buffer Error！");
            return;
        }

        DataService ds = new DataService(dbName);
        Frame frame = null;
        var people = ds.GetPeople();
        foreach(People person in people) {
            if (person.Id == 1)
            {
                linesPerFrame = person.PeopleId;
            }
            else
            {
                if (person.PeopleId == 1)//start one frame
                {
                    frame = new Frame();
                    frame.peoples.Add(person.PeopleId, person);
                }
                else if (person.PeopleId % linesPerFrame == 0)//finish one frame
                {
                    frame.peoples.Add(person.PeopleId, person);
                    frameBuffer.queue.Enqueue(frame);
                }
                else
                {
                    frame.peoples.Add(person.PeopleId, person);
                }
            }
        }
        ////单独读取第一行
        //ArrayList firstLine = dt[0] as ArrayList;
        //linesPerFrame = int.Parse(firstLine[1].ToString());

        //int frameCount = (dt.Count - 1) / linesPerFrame;
        ////每一帧
        //for (int i = 0; i < frameCount; i++)
        //{
        //    Frame frame = FramePool.GetInstance().GetFrame();
        //    frame.id = i;
        //    //每一行
        //    for (int j = 0; j < linesPerFrame; j++)
        //    {
        //        int idx = i * linesPerFrame + 1 + j;
        //        ArrayList line = dt[idx] as ArrayList;

        //        //"id:{0}, people_id:{1}, people_status:{2}, posx:{3}, posy:{4}"
        //        //"posz:{5}, velx:{6}, vely:{7}",
        //        int peopleID = int.Parse(line[1].ToString());
        //        int peopleRole = -1;//int.Parse(data[2].ToString());
        //        int peopleStatus = int.Parse(line[2].ToString());
        //        float posx = float.Parse(line[3].ToString());
        //        float posy = float.Parse(line[5].ToString());//posz
        //        float posz = float.Parse(line[4].ToString());//posy
        //        float orntx = float.Parse(line[6].ToString());
        //        float ornty = float.Parse(line[7].ToString());

        //        People p = PeoplePool.GetInstance().GetPeople();
        //        p.m_id = peopleID;
        //        p.m_role = peopleID == 1 ? 0 : peopleRole;
        //        p.m_status = (PeopleStatus)peopleStatus;
        //        p.m_position = new Vector3(posx, posy, posz);
        //        p.m_orientation = new Vector3(orntx, 0, ornty);
        //        p.m_animSpeed = p.m_animBaseSpeed + (Random.value - 0.5f) * 0.4f;
        //        p.m_figureScale = Vector3.one;
        //        frame.peoples.Add(peopleID, p);

        //    }
        //    FrameBuffer.GetInstance().GetQueue().Enqueue(frame);
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
            return;
        }
    }

    void OnDestroy()
    {
    }


}
