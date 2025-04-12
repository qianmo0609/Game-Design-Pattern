using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamPattern
{
    public class CommandPattern : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Invoker invoker = new Invoker();

            //将命令与执行结合
            Command theCommand = null;
            theCommand = new ConcreteCommad1(new Receiver1(), "Hello");
            invoker.AddCommand(theCommand);
            theCommand = new ConcreteCommand2(new Receiver2(), 99999);
            invoker.AddCommand(theCommand);

            //执行
            invoker.ExecuteCommand();
        }
    }

    public class Receiver1
    {
        public void Action(string Command)
        {
            Debug.Log("Receiver1.Action: Command['+Command+']");
        }
    }

    public class Receiver2
    {
        public void Action(int Param)
        {
            Debug.Log("Receiver2.Action: Param['+Param.ToString()+']");
        }
    }

    public abstract class Command
    {
        public abstract void Execute();
    }

    public class ConcreteCommad1 : Command
    {
        Receiver1 m_Receiver1 = null;
        string m_Command = "";

        public ConcreteCommad1(Receiver1 receiver1, string command)
        {
            this.m_Receiver1 = receiver1;
            this.m_Command = command;
        }

        public override void Execute()
        {
            this.m_Receiver1.Action(m_Command);
        }
    }

    public class ConcreteCommand2 : Command
    {
        Receiver2 m_Receiver2 = null;
        int m_Param = 0;

        public ConcreteCommand2(Receiver2 receiver2, int param)
        {
            this.m_Receiver2 = receiver2;
            this.m_Param = param;
        }

        public override void Execute()
        {
            this.m_Receiver2.Action(this.m_Param);
        }
    }

    public class Invoker
    {
        List<Command> m_Commands = new List<Command>();

        //加入命令
        public void AddCommand(Command theCommand)
        {
            this.m_Commands.Add(theCommand);
        }

        //执行命令
        public void ExecuteCommand()
        {
            //执行
            foreach (var commandItem in m_Commands)
            {
                commandItem.Execute();
            }
            //清空
            m_Commands.Clear();
        }
    }
}


