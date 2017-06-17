# chrome-tab-titles
List Chrome tab titles in .NET

Before Google Chrome version 32, obtaining a list of open tab titles was somewhat trivial. Each tab was it’s own “Window” and had it’s own handle. So you could use that handle and obtain the title via the window caption. When Google Chrome updated to version 32, a lot happened behind the scenes with regards to UI rendering. (see [here](http://news.softpedia.com/news/Google-Chrome-32-to-Switch-to-Aura-the-All-New-GPU-Powered-Graphical-Stack-391650.shtml) for more details).

With the v32 update, using the method mentioned above you can only obtain the current open tabs title. No good. If we want a list of all open tabs, we have to do something different. In this case, it’s using the somewhat recent [UI Automation accessibility framework](http://msdn.microsoft.com/en-us/library/ms747327(v=vs.110).aspx). This framework allows you to treewalk through an applications UI, find and interact with majority of it’s interface elements.

For more information visit http://www.bluelightdev.com/get-list-open-chrome-tabs

## Known Issues
* Does not work if Chrome is in full screen. [#1](../../issues/1)
