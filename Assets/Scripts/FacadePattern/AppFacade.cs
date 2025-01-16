using GamePattern;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 外观模式
/// </summary>
public class AppFacade : MonoBehaviour
{
    AppFacadePattern appFacade = null;
    void Start()
    {
        appFacade = new AppFacadePattern();
        appFacade.Initinal();
    }

    void Update()
    {
        appFacade?.Update();   
    }
}

namespace GamePattern
{
    public class AppFacadePattern
    {
        private GameEventSys m_gameEventSys = null;
        private CampSys m_campSys = null; 

        public void Initinal()
        {
            m_gameEventSys = new GameEventSys();
            m_campSys = new CampSys();
        }

        public void Update()
        {
            m_gameEventSys.Update();
            m_campSys.Update();
        }
    }

    public class BaseSys
    {
        public virtual void Update()
        {
            
        }
    }

    public class GameEventSys : BaseSys
    {
        public override void Update()
        {
            Debug.Log("GameEventSys Update");
        }
    }

    public class CampSys : BaseSys
    {
        public override void Update()
        {
            Debug.Log("CampSys Update");
        }
    }
}
