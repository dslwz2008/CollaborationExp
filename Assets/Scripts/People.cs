using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public enum PeopleStatus{
	IDLE=0,
	RUN,
	WALK,
    ARCH_RUN,
    BOW,//wanyao
	FALL,//daodi
	DEAD,
	STAND//stand
}

/// <summary>
/// People.
///  Store the variant in one moment.
/// </summary>
public class People {
    [PrimaryKey]
    public int Id { get; set; }
	public int PeopleId { get; set; }
	public int Status { get; set; }
	public float PositionX { get; set; }
    public float PositionY { get; set; }
    public float PositionZ { get; set; }
    public float OrientationX { get; set; }
    public float OrientationY { get; set; }

	//public People(){
	//	Initialize();
	//}
	
	//public People(int id, int role, int status, Vector3 targetPosition, 
	//              Vector3 targetOrnt, float animSpeed, Vector3 figureScale){
	//	m_id = id;
	//	m_role = role;
	//	m_status = (PeopleStatus)status;
	//	m_position = targetPosition;
	//	m_orientation = targetOrnt;
	//	m_animSpeed = animSpeed;
	//	m_figureScale = figureScale;
	//}

	//public void Initialize(){
	//	m_id = 0;
	//	m_role = -1;
	//	m_status = (PeopleStatus)0;
	//	m_position = Vector3.zero;
	//	m_orientation = Vector3.zero;
	//}

	public override string ToString ()
	{
		return string.Format("[People{0}]:{1} {2}", Id, PeopleId, Status);
	}
}
