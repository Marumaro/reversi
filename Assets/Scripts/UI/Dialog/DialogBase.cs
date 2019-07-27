using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    public abstract class DialogBase : MonoBehaviour
    {
        [SerializeField]
        protected Text _titleText = null;

        [SerializeField]
        protected Button _closeButton = null;

        public abstract void Setup(DialogArgBase argBase);
    }
}
