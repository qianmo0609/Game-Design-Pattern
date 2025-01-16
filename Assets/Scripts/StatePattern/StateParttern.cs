using UnityEngine;
using GamePattern;
/// <summary>
/// ״̬ģʽ
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
    /// ״̬�Ľӿ��࣬�ƶ�״̬�Ľӿڣ�
    /// ����淶Context��״̬ӵ���ߣ����ض�״̬��Ҫ���ֵ���Ϊ
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
    /// ��һ�����С�״̬�����Ե��࣬�����ƶ���صĽӿڣ�������ܹ���֪״̬�ĸı��ͨ��������״̬�ı�
    /// ��״̬���Ե��࣬���磺��Ϸ��ɫ��Ǳ�С�������ʩ����״̬���������ߡ��ѻ���æµ��״̬��GOFʹ��Tcp�����������ӵȴ����Ӷ��ߵ�״̬
    /// ��Щ���л���һ��ConcreteState[X]����Ķ���Ϊ���Ա����������ǰ״̬
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
    /// ����״̬�࣬ʵ��Context��״̬ӵ���ߣ����ض�״̬�¸��е���Ϊ�����磺ʵ�ֽ�ɫ��Ǳ��״̬ʱ���е��ж�
    /// �仺��3Dģ�ͱ��͸�������ܱ��з���ɫ�������Ϊ
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

