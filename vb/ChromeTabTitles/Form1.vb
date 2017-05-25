Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Automation

Public Class Form1
    Public Declare Auto Function GetClassName Lib "User32.dll" (ByVal hwnd As IntPtr,
    <Out()> ByVal lpClassName As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowThreadProcessId(ByVal hWnd As IntPtr,
    ByRef lpdwProcessId As Integer) As Integer
    End Function

    Public Delegate Function CallBack(ByVal hwnd As Integer, ByVal lParam As Integer) As Boolean
    Public Declare Function EnumWindows Lib "user32" (ByVal Adress As CallBack, ByVal y As Integer) As Integer
    Public Declare Function IsWindowVisible Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean

    Dim tabTitles As New List(Of String)()

    Private Sub btnListTabTitles_Click(sender As Object, e As EventArgs) Handles btnListTabTitles.Click
        lstTabTitles.Items.Clear()
        populateOpenFogBugzCases()
    End Sub

    Private Sub populateOpenFogBugzCases()

        '//Grab all the Chrome processes
        Dim chromeProcesses As Process() = Process.GetProcessesByName("chrome")

        '//Chrome process not found
        If chromeProcesses.Length = 0 Then
            lstTabTitles.Items.Add("Chrome isn't open?")
            btnListTabTitles.Enabled = False
            Exit Sub
        End If

        '//Clear our array of tab titles
        tabTitles = New List(Of String)()

        '//Kick off our search for chrome tab titles
        EnumWindows(AddressOf Enumerator, 0)

        '//Add to our listbox
        lstTabTitles.Items.AddRange(tabTitles.ToArray)
    End Sub

    '//Enums through all visible windows - gets each chrome handle
    Private Function Enumerator(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean

        If IsWindowVisible(hwnd) Then
            Dim sClassName As New StringBuilder("", 256)
            Dim processID As Integer = 0
            GetWindowThreadProcessId(hwnd, processID)

            Dim processFromID = Process.GetProcessById(processID)
            GetClassName(hwnd, sClassName, 256)

            '//Only want visible chrome windows (not any electron type apps that have chrome embedded!)
            If sClassName.ToString = "Chrome_WidgetWin_1" And processFromID.ProcessName = "chrome" Then
                FindChromeTabs(hwnd)
            End If
        End If

        Return True

    End Function

    '//Takes chrome window handle, searches for tabstrip then gets tab titles
    Private Sub FindChromeTabs(hwnd As IntPtr)

        '//To find the tabs we first need to locate something reliable - the 'New Tab' button
        Dim rootElement As AutomationElement = AutomationElement.FromHandle(hwnd)
        Dim condNewTab As Condition = New PropertyCondition(AutomationElement.NameProperty, "New Tab")

        '//Find the 'new tab' button
        Dim elemNewTab As AutomationElement = rootElement.FindFirst(TreeScope.Descendants, condNewTab)

        '//No tabstrip found
        If elemNewTab = Nothing Then Exit Sub

        '//Get the tabstrip by getting the parent of the 'new tab' button
        Dim tWalker As TreeWalker = TreeWalker.ControlViewWalker
        Dim elemTabStrip As AutomationElement = tWalker.GetParent(elemNewTab)

        '//Loop through all the tabs and get the names which is the page title
        Dim tabItemCondition As Condition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem)
        For Each tabItem As AutomationElement In elemTabStrip.FindAll(TreeScope.Children, tabItemCondition)
            tabTitles.Add(tabItem.Current.Name.ToString())
        Next

    End Sub
End Class
