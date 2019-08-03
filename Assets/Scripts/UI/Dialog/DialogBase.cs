using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Reversi.Dialog
{
    public abstract class DialogBase : MonoBehaviour
    {
        [SerializeField]
        protected Text _titleText = null;

        [SerializeField]
        protected Button _closeButton = null;

        public abstract void Initialize(DialogArgBase argBase);

        protected T ConvertArg<T>(DialogArgBase argBase) where T : DialogArgBase
        {
            var arg = argBase as T;
            if (arg == null)
            {
                Debug.LogErrorFormat("{0} is different arg", arg);
            }

            return arg;
        }
    }

    public abstract class DialogArgBase
    {
        public readonly string TitleText;
        public readonly Subject<Unit> CloseSubject;

        protected DialogArgBase(string titleText, Subject<Unit> closeSubject)
        {
            TitleText = titleText;
            CloseSubject = closeSubject;
        }
    }
}
