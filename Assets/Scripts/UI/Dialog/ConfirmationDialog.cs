using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    public class ConfirmationDialog : DialogBase
    {
        [SerializeField]
        private Text _bodyText = null;

        [SerializeField]
        private Button _confirmationButton = null;

        [SerializeField]
        private Text _confirmationButtonText = null;
        
        public override void Setup(DialogArgBase argBase)
        {
            var arg = argBase as ConfirmationDialogArg;
            if (arg == null)
            {
                Debug.LogErrorFormat("{0} is different arg", arg);
            }

            _titleText.text = arg.TitleText;
            _bodyText.text = arg.BodyText;
            _confirmationButtonText.text = arg.ConfirmationButtonText;

            _confirmationButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    arg.ConfirmationSubject?.OnNext(Unit.Default);
                    DialogManager.Instance.Close(this);
                })
                .AddTo(this);

            _closeButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    arg.CloseSubject?.OnNext(Unit.Default);
                    DialogManager.Instance.Close(this);
                })
                .AddTo(this);
        }
    }

    public class ConfirmationDialogArg : DialogArgBase
    {
        public readonly string BodyText;
        public readonly string ConfirmationButtonText;
        public readonly Subject<Unit> ConfirmationSubject;

        public ConfirmationDialogArg(
            string titleText,
            string bodyText,
            string confirmationButtonText,
            Subject<Unit> confirmationSubject,
            Subject<Unit> closeSubject)
            : base(titleText, closeSubject)
        {
            BodyText = bodyText;
            ConfirmationButtonText = confirmationButtonText;
            ConfirmationSubject = confirmationSubject;
        }
    }
}
