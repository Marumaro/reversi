using UnityEngine;

namespace Reversi.Dialog
{
    public class DialogManager : SingletonMonoBehaviour<DialogManager>
    {
        [SerializeField]
        private GameObject _filter = null;

        [SerializeField]
        private RectTransform _dialogRoot = null;

        [Header("- Dialog Prefab -")]
        [SerializeField]
        private ConfirmationDialog _confirmationDialog = null;

        [SerializeField]
        private MultiPlayDialog _multiPlayDialog = null;

        public DialogBase Open<T>(DialogArgBase arg)
        {
            var type = typeof(T);
            DialogBase dialog = null;

            if (type == typeof(ConfirmationDialog))
            {
                dialog = _confirmationDialog;
            }

            if (type == typeof(MultiPlayDialog))
            {
                dialog = _multiPlayDialog;
            }

            if (dialog != null)
            {
                _filter.SetActive(true);

                return Create(dialog, arg);
            }

            return null;
        }

        public void Close(DialogBase dialog)
        {
            Destroy(dialog.gameObject);

            _filter.SetActive(false);
        }

        private DialogBase Create(DialogBase dialog, DialogArgBase arg)
        {
            var obj = Instantiate(dialog, _dialogRoot);
            obj.Initialize(arg);

            return obj;
        }
    }
}
