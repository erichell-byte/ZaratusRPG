namespace Modules.UIFrame.Scripts.Base
{
    public interface IFrame
    {
        void Show(object args = null, Callback callback = null);

        void Hide();
        
        public interface Callback
        {
            void OnClose(IFrame frame);
        }
    }
    
    
}