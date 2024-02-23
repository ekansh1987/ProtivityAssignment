using System.Diagnostics;
using System.Reflection;
using Serilog;

namespace Protivity_POC_Employee.Common
{
    public class ProjectException : Exception
    {
        public ProjectException(Exception innerexception) :base(innerexception.Message,innerexception)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
            MethodBase methodBase = frame?.GetMethod();
            string callingClassName = (methodBase != null) ? methodBase.DeclaringType.FullName : string.Empty;
            int linenumber = frame?.GetFileLineNumber() ?? 0;

            //Handle Exception
            if(innerexception.GetType()!=typeof(ProjectException))
            {
                MessageId = LogException(innerexception);
            }
            if(MessageId==-1)
            {
                FriendlyMesssage = String.Format("Error Code: {0} - {1} ", MessageId, "A network related error occur. Please contact admin");
            }
            if(string.IsNullOrEmpty(FriendlyMesssage))
            {
                FriendlyMesssage = String.Format("Error Code: {0} - {1} ", MessageId, "Internal Server Error.");
            }
        }
        public string FriendlyMesssage { get; private set; }
        public long MessageId { get; private set; }
        #region Private Log Method
        private long LogException(Exception ex)
        {
            long messageId = -1;
            try
            {
                Log.Error(ex.ToString());
            }
            catch
            {
                messageId = -1;
            }
            return messageId;
        }
        #endregion
    }
}
