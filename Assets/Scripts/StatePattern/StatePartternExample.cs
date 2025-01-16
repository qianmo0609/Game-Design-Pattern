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

    //����״̬�Ļ���
    public class ISceneState
    {
        //״̬����
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

        //������
        protected GamePattern.SceneStateController m_Controller = null;
        //������
        public ISceneState(GamePattern.SceneStateController controller)
        {
            m_Controller = controller;
            m_sceneState = SceneState.None;
        }
        //��ʼ
        public virtual void StateBegin() { m_sceneState = SceneState.loading; }
        //����
        public virtual void StateEnd() { m_sceneState = SceneState.None; }
        //����
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

        //״̬��ʼ
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
        //��ǰ״̬
        private ISceneState m_State;
        private bool m_bRunBegin = false;

        private MonoBehaviour m_mono;

        public SceneStateController() 
        {
            m_mono = new GameObject().GetComponent<MonoBehaviour>();
        }

        //����״̬
        public void SetState(GamePattern.ISceneState state,string loadSceneName,bool isAsync = false)
        {
            Debug.Log("Set");
            m_bRunBegin = false;

            //���볡��
            LoadScene(loadSceneName,isAsync);

            //֪ͨǰһ��State����
            m_State?.StateEnd();

            //�����³���
            m_State = state;
        }

        //���볡��
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

        //����
        public void StateUpdate()
        {
            //�Ƿ��ڼ���
            if (m_State.SceneState != SceneState.complete)
                return;
            //֪ͨ�µ�state��ʼ
            if(m_State != null && m_bRunBegin == false)
            {
                m_State.StateBegin();
                m_bRunBegin = true;
            }
         
            m_State?.StateUpdate();
        }
    }
}