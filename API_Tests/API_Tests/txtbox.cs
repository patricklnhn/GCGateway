using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Tests
{
    public partial class txtbox :TextBox
    {
        public event EventHandler TypingCompleted;
        public void Method()
        {
            TypingCompleted?.Invoke(this, EventArgs.Empty); 

        }
        
        
    }
}
