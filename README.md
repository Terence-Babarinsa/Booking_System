# Booking_System
An application that enables users to book seats in a stand for sporting events

# Project Overview
The goal of this project is to create a booking system. The application will allow users to select and deselect seats of their choice relative to available games within the current season

Users will have access to a personal profile that holds personal information and any relevant data about seats they have reserved

The end product will be a 3 tire application with passed tests that consolidate all functionality.

# Database ERD
erd:

# Sprint Breakdown
## Sprint 1
#### Sprint Goals
The goal for this sprint was to draw up my database erd's, create my databse, scaffold my database and create the methods for my code behind my user interface
#### Sprint Review
I was able to complete two of my sprint goals. Bottlenecks came forth when designing the methods for my code behind due to underestimating the time required. Writing up the code for my methods will be pushed onto the next sprint.
#### Sprint Retrospective
One of the blockers for this sprint was forgetting to re-scaffold my database whenever I made any changes to the tables after the first scaffold. I ran into issues when i change some data type field in some of my tables after reconsideringthe deisgn of my erd's adn this highlighted the issue. I also ran into problems when trying tio get my primary key to start from 1 and auto increment, but after some research the issue was quickly rectified. Another bloacker was my underestimating of the time required to code up the methods for my code behind. The next sprint will see me continue with writing my methods and will lead on nicely to creating tests to assert their functionality.

## Sprint 2
#### Sprint Goals
The goal for this sprint was to complete the creation of my methods and create tests to assert their functionality
#### Sprint Review
Completing the creation of my methods was a success. While this was happening I was manually testing their functionality to check they did what was intended. I was able to complete the test for the method's CRUD functionality, however all my test did not pass as intended
#### Sprint Retrospective
One of the main blockers for this sprint was creating my tests. Interacting with with the database from the n-unit proved challenging at first in terms of getting to grips with the TestCase and TearDowns, however once this slight hurdle was conquered tests were relatively simpler to write in terms of understanidng the flow of data from the test framework, to methods and into the database. The main blocker has been a particularly tricky test taht hasn't passed. This test will be moved in to sprint 3 for completion before development of the UI.

## Sprint 3
#### Sprint Goals
The goal for this sprint was to connect my basic UI to the code behind and manually tests its functionality 
#### Sprint Review
I have created all my pages for my UI. The time allowed for this sprint was adequate. The time needed to created the seating form adn code and create each individual button taook much longer than anticipted. There has been issues trying to noviage between my pages. This issue willl have to be moved into sprint 4 as I am still to find a viable work around.
#### Sprint Retrospective
The main blocker for this sprint is getting teh navigation between the pages. This navigation can be performed if i set my pages as windows, however the user experience will be negatively affected due to changing form size as they navigate around the system. For the sake of uniformity, it will serve best to have my pages appear within the same frame.

## Sprint 4
#### Sprint Goals
The goal for this sprint was to continue with connecting my basic UI to the code behind and manually tests its functionality 
#### Sprint Review
This sprint was succes as it saw me complete my project MVP. I was able to complete the the basic design of my UI, connect it to the my business layer and manually test it.
#### Sprint Retrospective
The was alot of difficulty with displaying my pages on my window. This was cause problem due to the typ eof window i designed. A navigation window is what was required to change the content of the main window. This, in conjunction with a naviagtion service saw me overcome this blocker. Another issue during this sprint was the buttons that represented the seats on my system. I tried to access their content by stepping through the controls on my page that were of type buttons, however this type of loop was unique to forms and not pages. To overcome this blcoker I had to hard code all my buttons into a list of type buttons in order to still access theu methods when i was looping through the list.
