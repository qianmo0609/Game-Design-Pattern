using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GamePattern;

public class StatePartternExample : MonoBehaviour
{
    GamePattern.SceneStateController m_SceneStateController;

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    void Start()
    {
        m_SceneStateController = new GamePattern.SceneStateController();
        m_SceneStateController.SetState(new GamePattern.StartState(m_SceneStateController),"");
    }
}

namespace GamePattern
{
    public enum SceneState
    {
        None,
        loading,
        complete,
    }

    //场景状态的基类
    public class ISceneState
    {
        //状态名称
        private string m_StateName = "ISceneState";
        public string StateName
        {
            get { return m_StateName; }
            set { m_StateName = value; }
        }

        private SceneState m_sceneState;

        public SceneState SceneState
        {
            get { return m_sceneState;  }
            set { m_sceneState = value; }
        }

        //控制者
        protected GamePattern.SceneStateController m_Controller = null;
        //建造者
        public ISceneState(GamePattern.SceneStateController controller)
        {
            m_Controller = controller;
            m_sceneState = SceneState.None;
        }
        //开始
        public virtual void StateBegin() { m_sceneState = SceneState.loading; }
        //结束
        public virtual void StateEnd() { m_sceneState = SceneState.None; }
        //更新
        public virtual void StateUpdate() { }

        public override string ToString()
        {
            return string.Format("[I_SceneState: StateName = {0}]", StateName);
        }
    }

    public class StartState : ISceneState
    {
        public StartState(SceneStateController controller) : base(controller)
        {
            this.StateName = "StartState";
        }

        //状态开始
        public override void StateBegin()
        {
            base.StateBegin();
        }

        public override void StateEnd()
        {
            base.StateEnd();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }
    }

    public class MainMenuState : ISceneState
    {
        public MainMenuState(SceneStateController controller) : base(controller)
        {
            this.StateName = "MainMenuState";
        }

        public override void StateBegin()
        {
            base.StateBegin();
        }

        public override void StateEnd()
        {
            base.StateEnd();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }
    }

    public class BattleState : ISceneState
    {
        public BattleState(SceneStateController controller) : base(controller)
        {
            this.StateName = "BattleState";
        }

        public override void StateBegin()
        {
            base.StateBegin();
        }

        public override void StateEnd()
        {
            base.StateEnd();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }
    }

    public class SceneStateController
    {
        //当前状态
        private ISceneState m_State;
        private bool m_bRunBegin = false;

        private MonoBehaviour m_mono;

        public SceneStateController() 
        {
            m_mono = new GameObject().GetComponent<MonoBehaviour>();
        }

        //设置状态
        public void SetState(GamePattern.ISceneState state,string loadSceneName,bool isAsync = false)
        {
            Debug.Log("Set");
            m_bRunBegin = false;

            //载入场景
            LoadScene(loadSceneName,isAsync);

            //通知前一个State结束
            m_State?.StateEnd();

            //设置新场景
            m_State = state;
        }

        //载入场景
        private void LoadScene(string loadSceneName,bool isAsync)
        {
            if (loadSceneName == null || loadSceneName.Length == 0) return;
            if (!isAsync)
                SceneManager.LoadScene(loadSceneName);
            else
                m_mono.StartCoroutine(LoadSceneAsync(loadSceneName));
            SceneManager.sceneLoaded += SceneLoadedCb;
        }

        IEnumerator LoadSceneAsync(string loadSceneName)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(loadSceneName);
            async.allowSceneActivation = false;
            while (!async.isDone)
            {
                yield return new WaitForSeconds(0.01f);
            }
            async.allowSceneActivation = true;
            m_mono.StopCoroutine(LoadSceneAsync(loadSceneName));
        }

        private void SceneLoadedCb(Scene scene, LoadSceneMode loadSceneMode)
        {
            m_State.SceneState = SceneState.complete;
        }

        //更新
        public void StateUpdate()
        {
            //是否还在加载
            if (m_State.SceneState != SceneState.complete)
                return;
            //通知新的state开始
            if(m_State != null && m_bRunBegin == false)
            {
                m_State.StateBegin();
                m_bRunBegin = true;
            }
         
            m_State?.StateUpdate();
        }
    }
}