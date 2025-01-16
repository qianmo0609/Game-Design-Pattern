using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateMethodPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
