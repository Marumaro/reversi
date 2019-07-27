using UniRx;

namespace Dialog
{
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
