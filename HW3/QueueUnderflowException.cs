using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _460HW3 
{
    class QueueUnderflowException : Exception
    {
        /// <summary>
        /// This overrides the extended SystemException class's constructor using the :base()
        /// </summary>
        public QueueUnderflowException():base()
        {

        }

        /// <summary>
        /// This overrides the extended SystemException class's constructor using the :base() and takes a msg
        /// <paramref name="msg"/> takes in a message and overrides it through the SystemsExceptions constructor
        /// </summary>
        public QueueUnderflowException(string msg) : base(msg)
        {

        }




    }
}
