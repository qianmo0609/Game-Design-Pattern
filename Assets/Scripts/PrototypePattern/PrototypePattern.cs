using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypePattern : MonoBehaviour
{
    public SoliderA soliderAPrototype;
    public SoliderB soliderBPrototype;

    private EnemySpawner mEnemySpawner;

    void Start()
    {
        mEnemySpawner = new EnemySpawner();
        mEnemySpawner.SpawnEnemy(soliderAPrototype);
        mEnemySpawner.SpawnEnemy(soliderBPrototype);
    }
}

public interface ICopyable
{
    ICopyable Copy();
}

public class Enemy : MonoBehaviour, ICopyable
{
    public ICopyable Copy()
    {
        return Instantiate(this);
    }
}

public class EnemySpawner
{
    public ICopyable mCopy;

    public Enemy SpawnEnemy(Enemy prototype)
    {
        mCopy = prototype.Copy();
        return (Enemy)mCopy;
    }
}
