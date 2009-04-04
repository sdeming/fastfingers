using System;
using System.Collections.Generic;
using System.Text;

namespace FastFingers.Launching
{
    public interface ILaunchAction
    {
        bool DoAction();
        bool UndoAction();
    }

    public class Execute : ILaunchAction
    {
        private ILaunchable target;
        private string arguments;

        public Execute(ILaunchable target, string arguments)
        {
            this.target = target;
            this.arguments = arguments;
        }
        
        public bool DoAction()
        {
            try
            {
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(target.FullName, arguments);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UndoAction()
        {
            return true;
        }
    }

}
