using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace PMDS.Global
{

    //Klasse, um den Zugriff auf den Zertifikatsspeicher LocalMachine für den Nicht-Admin-User zu erlauben
    public static class Impersonation
    {
        /// <summary>
        /// Runs the action under given credentials
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="type"></param>
        /// <param name="provider"></param>
        /// <param name="action"></param>
        /// <param name="forceAction"></param>
        public static void RunAction(string userName, string password, string domain, LogonType type, LogonProvider provider, Action action, bool forceAction = false)
        {
            SafeTokenHandle safeTokenHandle;

            bool returnValue = Win32NativeMethods.LogonUser(userName, domain, password, (int)type, (int)provider, out safeTokenHandle);

            if (!returnValue)
            {
                if (!forceAction)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new Win32Exception(ret);
                }
                else
                {
                    action();
                }
            }
            else
            {
                using (safeTokenHandle)
                {
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {
                            action();
                        }
                    }
                }
            }
        }
    }

    public enum LogonType
    {
        /// <summary>
        /// LOGON32_LOGON_INTERACTIVE
        /// </summary>
        LOGON32_LOGON_INTERACTIVE = 2,

        /// <summary>
        /// LOGON32_LOGON_NETWORK
        /// </summary>
        LOGON32_LOGON_NETWORK = 3,

        /// <summary>
        /// LOGON32_LOGON_BATCH
        /// </summary>
        LOGON32_LOGON_BATCH = 4,

        /// <summary>
        /// LOGON32_LOGON_SERVICE
        /// </summary>
        LOGON32_LOGON_SERVICE = 5,

        /// <summary>
        /// LOGON32_LOGON_UNLOCK
        /// </summary>
        LOGON32_LOGON_UNLOCK = 7,

        /// <summary>
        /// LOGON32_LOGON_NETWORK_CLEARTEXT
        /// Win2K or higher
        /// </summary>
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

        /// <summary>
        /// LOGON32_LOGON_NEW_CREDENTIALS
        /// Win2K or higher
        /// </summary>
        LOGON32_LOGON_NEW_CREDENTIALS = 9,
    }

    public enum LogonProvider
    {
        /// <summary>
        /// LOGON32_PROVIDER_DEFAULT
        /// </summary>
        LOGON32_PROVIDER_DEFAULT = 0,

        /// <summary>
        /// LOGON32_PROVIDER_WINNT35
        /// </summary>
        LOGON32_PROVIDER_WINNT35 = 1,

        /// <summary>
        /// LOGON32_PROVIDER_WINNT40
        /// </summary>
        LOGON32_PROVIDER_WINNT40 = 2,

        /// <summary>
        /// LOGON32_PROVIDER_WINNT50
        /// </summary>
        LOGON32_PROVIDER_WINNT50 = 3,
    }

    class Win32NativeMethods
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
        int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
    }

    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// ReleaseHandle
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }

}
