using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public delegate void OnKeyPressed(ConsoleKeyInfo val);

    public delegate void OnUpKeyPressed();
    public delegate void OnDownKeyPressed();
    public delegate void OnLeftKeyPressed();
    public delegate void OnRightKeyPressed();

    public class InputHandler
    {
        public static InputHandler s_instance = null;

        public static InputHandler GetInstance()
        {
            if(InputHandler.s_instance == null)
            {
                InputHandler.s_instance = new InputHandler();
            }

            return InputHandler.s_instance;
        }

        public OnKeyPressed onKeyPressedCallbacks;

        public OnUpKeyPressed onUpKeyPressedCallbacks;
        public OnDownKeyPressed onDownKeyPressedCallbacks;
        public OnLeftKeyPressed onLeftKeyPressedCallbacks;
        public OnRightKeyPressed onRightKeyPressedCallbacks;
        ConsoleKeyInfo m_input;
        bool m_isQuit = false;
        protected InputHandler()
        {
        }

        public void Update()
        {
            if(Console.KeyAvailable)
            {
                m_input = Console.ReadKey();

                if(m_input.Key  == ConsoleKey.Escape)
                {
                    m_isQuit = true;
                    return;
                }

                if(m_input.Key == ConsoleKey.W || m_input.Key == ConsoleKey.UpArrow)
                {
                    if (onUpKeyPressedCallbacks != null)
                    {
                        onUpKeyPressedCallbacks.Invoke();
                    }
                }

                if (m_input.Key == ConsoleKey.A || m_input.Key == ConsoleKey.LeftArrow)
                {
                    if (onLeftKeyPressedCallbacks != null)
                    {
                        onLeftKeyPressedCallbacks.Invoke();
                    }
                }

                if (m_input.Key == ConsoleKey.S || m_input.Key == ConsoleKey.DownArrow)
                {
                    if (onDownKeyPressedCallbacks != null)
                    {
                        onDownKeyPressedCallbacks.Invoke();
                    }
                }

                if (m_input.Key == ConsoleKey.D || m_input.Key == ConsoleKey.RightArrow)
                {
                    if (onRightKeyPressedCallbacks != null)
                    {
                        onRightKeyPressedCallbacks.Invoke();
                    }
                }

                if (onKeyPressedCallbacks != null)
                {
                    onKeyPressedCallbacks.Invoke(m_input);
                }
            }
            
        }

        public bool IsQuit
        {
            get
            {
                return m_isQuit;
            }
        }
    }
}
