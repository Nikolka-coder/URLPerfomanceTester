##Task:
###Story

As user I want a tool for evaluating website performance. 

###Acceptance criteria

- It should be a web site, ASP.NET MVC(suggestion: you can use bootstrap framework)
- It should be a page with text box where user can enter URL
- Application has to determine sitemap of requested URL,sendsrequests to sitemap’s URLsand measure response time.
- Test result should display pages speed graphically (top of the page)
- Test result should display page speed as a table (bottom of the page). Table should contain min and max values for each page
- Slowest requests should be on top
- It should be possible to evaluate tests result history for tested web sites
- Source code for the task should be uploaded to GitHub or Bitbucket

###Notes
Approach, tools, database engine can be selected by candidate.It would be super cool in case response time is showed in real time
However it is not required. 

##Used:
- ASP.NET MVC 4 as platform
- MS SQL Server as database
- Entity Framework as ORM to database
- Hangfire for background tasks
- XUnit and Moq for unit testing
