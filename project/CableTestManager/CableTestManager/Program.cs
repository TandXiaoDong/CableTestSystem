using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CableTestManager.View;
using WindowsFormTelerik.CommonUI;
using CableTestManager.CUserManager;

namespace CableTestManager
{
    static class Program
    {
        private static ApplicationContext applicationContext;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.ProductVersion.ToString() + "\n";
            //System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //TestDB();
            LocalLogin localLogin = new LocalLogin();
            localLogin.ShowDialog();
            if (localLogin.DialogResult == DialogResult.OK)
            {
                var programeVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\n";
                WelcomeForm welcomeForm = new WelcomeForm(CMainForm.CableTestSystemName,programeVersion);
                welcomeForm.Show();
                applicationContext = new ApplicationContext();
                applicationContext.Tag = welcomeForm;
                Application.Idle += Application_Idle;
                Application.Run(applicationContext);
            }
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(Application_Idle);
            if (applicationContext.MainForm == null)
            {
                CMainForm cMainForm = new CMainForm();
                applicationContext.MainForm = cMainForm;
                //init
                cMainForm.Init();
                WelcomeForm welcomeForm = applicationContext.Tag as WelcomeForm;
                welcomeForm.Close();
                cMainForm.Show();
            }
        }
    }
}
