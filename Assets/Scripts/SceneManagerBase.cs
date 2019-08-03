using UnityEngine;

namespace Reversi.Scene
{
    public abstract class SceneManagerBase : MonoBehaviour
    {
        public abstract void Initialize(SceneArgBase argBase);

        protected T ConvertArg<T>(SceneArgBase argBase) where T : SceneArgBase
        {
            var arg = argBase as T;
            if (arg == null)
            {
                Debug.LogErrorFormat("{0} is different arg", arg);
            }

            return arg;
        }
    }

    public abstract class SceneArgBase
    {
    }
}