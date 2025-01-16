using GamePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �н���ģʽ
/// </summary>
public class MediatorPattern : MonoBehaviour
{
    void Start()
    {
        //�����н���
        ConcreateMediator pMediator = new ConcreateMediator();

        //��������Colleague
        ConcreateColleague1 pColleague1 = new ConcreateColleague1 (pMediator);
        ConcreateColleague2 pColleague2 = new ConcreateColleague2 (pMediator);

        //���ø��н���
        pMediator.SetColleague1(pColleague1);
        pMediator.SetColleague2(pColleague2);


        //ִ��
        pColleague1.Action();
        pColleague2.Action();
    }
}

namespace GamePattern
{
    public abstract class Colleague
    {
        //ͨ��Mediator���⹵ͨ
        protected Mediator m_Mediator = null;

        public Colleague(Mediator mediator)
        {
            m_Mediator = mediator;
        }

        //Mediator ֪ͨ����
        public abstract void Request(string message);

        //ִ�к���Ҫ֪ͨ����Colleague
        public abstract void Action();
    }

    public class ConcreateColleague1 : Colleague
    {
        public ConcreateColleague1(Mediator mediator) : base(mediator)
        {
        }

        public override void Action()
        {
            m_Mediator.SendMessage(this, "Colleage1 ����֪ͨ");
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
            m_Mediator.SendMessage(this, "Colleage2 ����֪ͨ");
        }

        public override void Request(string message)
        {
            Debug.Log("ConcreateColleague2.Request : " + message);
        }
    }

    //�н��߽ӿ�
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

        //�յ�����Colleague��֪ͨ����
        public override void SendMessage(Colleague colleague, string message)
        {
            //�յ�Colleague1֪ͨColleague2
            if(m_Colleague1 == colleague)
            {
                m_Colleague2.Request(message);
            }

            //�յ�Colleague2֪ͨColleague1
            if(m_Colleague2 == colleague)
            {
                m_Colleague1.Request(message);
            }
        }
    }
}
