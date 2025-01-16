using UnityEngine;
using GamePattern;
/// <summary>
/// 状态模式
/// </summary>
public class StateParttern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreteStateA(context));
        context.Request(5);
        context.Request(15);
        context.Request(25);
        context.Request(35);
    }
}

namespace GamePattern
{

    /// <summary>
    /// 状态的接口类，制定状态的接口，
    /// 负责规范Context（状态拥有者）在特定状态下要表现的行为
    /// </summary>
    public abstract class State
    {
        protected Context m_Context = null;

        public State(Context _context)
        {
            m_Context = _context;
        }

        public abstract void Handler(int value);
    }

    /// <summary>
    /// 是一个具有“状态”属性的类，可以制定相关的接口，让外界能够得知状态的改变或通过操作让状态改变
    /// 有状态属性的类，例如：游戏角色有潜行、攻击、施法等状态；好友上线、脱机、忙碌等状态；GOF使用Tcp联网有已连接等待链接断线等状态
    /// 这些类中会有一个ConcreteState[X]子类的对象为其成员，用来代表当前状态
    /// </summary>
    public class Context
    {
        State m_State = null;

        public void Request(int value)
        {
            m_State.Handler(value);
        }

        public void SetState(State state)
        {
            Debug.Log("Context.SetState:" + state);
            m_State = state;
        }
    }

    /// <summary>
    /// 具体状态类，实现Context（状态拥有者）在特定状态下该有的行为，例如：实现角色在潜行状态时该有的行动
    /// 变缓、3D模型变半透明、不能被敌方角色觉察等行为
    /// </summary>
    public class ConcreteStateA : State
    {
        public ConcreteStateA(Context _context) : base(_context)
        {
        }

        public override void Handler(int value)
        {
            Debug.Log("ConcreteStateA.Handler");
            if (value > 10)
            {
                m_Context.SetState(new ConcreateStateB(m_Context));
            }
        }
    }

    public class ConcreateStateB : State
    {
        public ConcreateStateB(Context _context) : base(_context)
        {
        }

        public override void Handler(int value)
        {
            Debug.Log("ConcreteStateB.Handler");
            if (value > 20)
            {
                m_Context.SetState(new ConcreateStateC(m_Context));
            }
        }
    }

    public class ConcreateStateC : State
    {
        public ConcreateStateC(Context _context) : base(_context)
        {
        }

        public override void Handler(int value)
        {
            Debug.Log("ConcreteStateC.Handler");
            if (value > 30)
            {
                m_Context.SetState(new ConcreteStateA(m_Context));
            }
        }
    }
}

