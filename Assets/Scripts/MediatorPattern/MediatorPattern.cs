using GamePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 中介者模式
/// </summary>
public class MediatorPattern : MonoBehaviour
{
    void Start()
    {
        //制造中介者
        ConcreateMediator pMediator = new ConcreateMediator();

        //制造两个Colleague
        ConcreateColleague1 pColleague1 = new ConcreateColleague1 (pMediator);
        ConcreateColleague2 pColleague2 = new ConcreateColleague2 (pMediator);

        //设置给中介者
        pMediator.SetColleague1(pColleague1);
        pMediator.SetColleague2(pColleague2);


        //执行
        pColleague1.Action();
        pColleague2.Action();
    }
}

namespace GamePattern
{
    public abstract class Colleague
    {
        //通过Mediator对外沟通
        protected Mediator m_Mediator = null;

        public Colleague(Mediator mediator)
        {
            m_Mediator = mediator;
        }

        //Mediator 通知请求
        public abstract void Request(string message);

        //执行后需要通知其他Colleague
        public abstract void Action();
    }

    public class ConcreateColleague1 : Colleague
    {
        public ConcreateColleague1(Mediator mediator) : base(mediator)
        {
        }

        public override void Action()
        {
            m_Mediator.SendMessage(this, "Colleage1 发出通知");
        }

        public override void Request(string message)
        {
            Debug.Log("ConcreateColleague1.Request :" + message);
        }
    }

    public class ConcreateColleague2 : Colleague
    {
        public ConcreateColleague2(Mediator mediator) : base(mediator)
        {
        }

        public override void Action()
        {
            m_Mediator.SendMessage(this, "Colleage2 发出通知");
        }

        public override void Request(string message)
        {
            Debug.Log("ConcreateColleague2.Request : " + message);
        }
    }

    //中介者接口
    public abstract class Mediator 
    { 
        public abstract void SendMessage(Colleague colleague,string Message);
    }

    public class ConcreateMediator : Mediator
    {
        ConcreateColleague1 m_Colleague1 = null;
        ConcreateColleague2 m_Colleague2 = null;

        public void SetColleague1(ConcreateColleague1 colleague1)
        {
            m_Colleague1 = colleague1;
        }

        public void SetColleague2(ConcreateColleague2 colleague2)
        {
            m_Colleague2 = colleague2;
        }

        //收到来自Colleague的通知请求
        public override void SendMessage(Colleague colleague, string message)
        {
            //收到Colleague1通知Colleague2
            if(m_Colleague1 == colleague)
            {
                m_Colleague2.Request(message);
            }

            //收到Colleague2通知Colleague1
            if(m_Colleague2 == colleague)
            {
                m_Colleague1.Request(message);
            }
        }
    }
}
