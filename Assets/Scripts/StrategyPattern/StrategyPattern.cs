using UnityEngine;
using GamePattern;

/// <summary>
/// 策略模式
/// </summary>
public class StrategyPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StrategyContext context = new StrategyContext();

        //设置算法
        context.SetStrategy(new ConcreteStrategyA());
        context.ContextInterface();

        context.SetStrategy(new ConcreteStrategyB());
        context.ContextInterface();

        context.SetStrategy(new ConcreteStrategyC());
        context.ContextInterface();
    }
}

namespace GamePattern
{
    public abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    public class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("ConcreateStrategyA.AlgorithmInterface");
        }
    }

    public class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("ConcreateStrategyB.AlgorithmInterface");
        }
    }

    public class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Debug.Log("ConcreateStrategyC.AlgorithmInterface");
        }
    }

    public class StrategyContext
    {
        Strategy m_strategy = null;

        //设置算法
        public void SetStrategy(Strategy strategy)
        {
            m_strategy = strategy;
        }

        //执行当前算法
        public void ContextInterface()
        {
            m_strategy.AlgorithmInterface();
        }
    }
}
