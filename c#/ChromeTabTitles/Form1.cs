using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using System.Diagnostics;

namespace ChromeTabTitles {
    public partial class Form1 : Form {

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public delegate bool EnumWindowsCallback(IntPtr hwnd, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowsCallback Adress, int y);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        List<string> tabTitles = new List<string>();

        public Form1() {
            InitializeComponent();
        }

        private void btnShowTabTitles_Click(object sender, EventArgs e) {
            lstTabTitles.Items.Clear();
            showTabTitles();
        }

        private void showTabTitles() {
            //Grab all the Chrome processes
            Process[] chromeProcesses = Process.GetProcessesByName("chrome");

            //Chrome process not found
            if ((chromeProcesses.Length == 0)) {
                lstTabTitles.Items.Add("Chrome isn\'t open?");
                btnShowTabTitles.Enabled = false;
                return;
            }

            //Clear our array of tab titles
            tabTitles = new List<string>();

            //Kick off our search for chrome tab titles
            EnumWindowsCallback callBackFn = new EnumWindowsCallback(Enumerator);
            EnumWindows(callBackFn, 0);

            //Add to our listbox
            lstTabTitles.Items.AddRange(tabTitles.ToArray());
        }

        //Enums through all visible windows - gets each chrome handle
        private bool Enumerator(IntPtr hwnd, int lParam) {
            if (IsWindowVisible(hwnd)) {
                StringBuilder sClassName = new StringBuilder(256);
                uint processID = 0;
                GetWindowThreadProcessId(hwnd, out processID);
                Process processFromID = Process.GetProcessById((int)processID);
                GetClassName(hwnd, sClassName, sClassName.Capacity);

                //Only want visible chrome windows (not any electron type apps that have chrome embedded!)
                if (((sClassName.ToString() == "Chrome_WidgetWin_1") && (processFromID.ProcessName == "chrome"))) {
                    FindChromeTabs(hwnd);
                }

            }

            return true;
        }

        //Takes chrome window handle, searches for tabstrip then gets tab titles
        private void FindChromeTabs(IntPtr hwnd) {
            //To find the tabs we first need to locate something reliable - the 'New Tab' button
            AutomationElement rootElement = AutomationElement.FromHandle(hwnd);
            Condition condNewTab = new PropertyCondition(AutomationElement.NameProperty, "New Tab");

            //Find the 'new tab' button
            AutomationElement elemNewTab = rootElement.FindFirst(TreeScope.Descendants, condNewTab);

            //No tabstrip found
            if ((elemNewTab == null)) {
                return;
            }

            //Get the tabstrip by getting the parent of the 'new tab' button
            TreeWalker tWalker = TreeWalker.ControlViewWalker;
            AutomationElement elemTabStrip = tWalker.GetParent(elemNewTab);

            //Loop through all the tabs and get the names which is the page title
            Condition tabItemCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
            foreach (AutomationElement tabItem in elemTabStrip.FindAll(TreeScope.Children, tabItemCondition)) {
                tabTitles.Add(tabItem.Current.Name.ToString());
            }

        }
    }
}
