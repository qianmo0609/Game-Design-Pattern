using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePattern;

/// <summary>
/// �Ž�ģʽ
/// </summary>
public class BridgePattern : MonoBehaviour
{
    void Start()
    {
        Sphere sphere = new Sphere();
        sphere.SetRenderEngine(new OpenGLDraw());
        sphere.Draw();
        Cube cube = new Cube();
        cube.SetRenderEngine(new DirectXDraw());
        cube.Draw();
        Cylinder cylinder = new Cylinder();
        cylinder.SetRenderEngine(new OpenGLDraw());
        cylinder.Draw();
    }
}

namespace GamePattern
{
    //��ͼ����
    public abstract class RenderEngine
    { 
        public abstract void Render(string ObjName);
    }

    //DX����
    public class DirectXDraw :RenderEngine
    {
        public void DXRender(string ObjName)
        {
            Debug.Log("DXRender :" + ObjName);
        }

        public override void Render(string ObjName)
        {
            DXRender(ObjName);
        }
    }

    //OpenGl����
    public class OpenGLDraw :RenderEngine
    {
        public void GLRender(string ObjName)
        {
            Debug.Log("OpenGl:" + ObjName);
        }

        public override void Render(string ObjName)
        {
            GLRender(ObjName);
        }
    }

    //��״
    public abstract class IShape
    {
        protected RenderEngine m_engine = null;

        public void SetRenderEngine(RenderEngine renderEngine)
        {
            m_engine = renderEngine;
        }

        public abstract void Draw();
    }

    //����
    public class Sphere : IShape
    {
        public override void Draw()
        {
            m_engine.Render("Sphere");
        }
    }

    //������
    public class Cube : IShape
    {
        public override void Draw()
        {
            m_engine.Render("Cube");
        }
    }

    //Բ����
    public class Cylinder : IShape
    {
        public override void Draw()
        {
            m_engine.Render("Cylinder");
        }
    }
}