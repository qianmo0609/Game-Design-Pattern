using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePattern;

public class TemplateMethodPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SubClass1 subClass1 = new SubClass1();
        subClass1.TemplateMethod();
        SubClass2 subClass2 = new SubClass2();  
        subClass2.TemplateMethod();
    }
}

namespace GamePattern
{
    public abstract class TemplateMethodClass
    {
        public void TemplateMethod()
        {
            PrimitiveMethod1();
            PrimitiveOperation1();
            PrimitiveMethod2(); 
            PrimitiveOperation2();
        }

        //由子类实现的方法
        protected abstract void PrimitiveOperation1();
        protected abstract void PrimitiveOperation2();

        //父类实现的方法
        public void PrimitiveMethod1()
        {
            Debug.Log("PrimitiveMethod1");
        }

        public void PrimitiveMethod2()
        {
            Debug.Log("PrimitiveMethod2");
        }
    }

    public class SubClass1 : TemplateMethodClass
    {
        protected override void PrimitiveOperation1()
        {
            Debug.Log("SubClass1 PrimitiveOperation1");
        }

        protected override void PrimitiveOperation2()
        {
            Debug.Log("SubClass1 PrimitiveOperation2");
        }
    }

    public class SubClass2 : TemplateMethodClass
    {
        protected override void PrimitiveOperation1()
        {
            Debug.Log("SubClass2 PrimitiveOperation1");
        }

        protected override void PrimitiveOperation2()
        {
            Debug.Log("SubClass2 PrimitiveOperation1");
        }
    }
}
