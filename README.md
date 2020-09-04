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
### Sprint Goals
The goal for this sprint was to draw up my database erd's, create my databse, scaffold my database and create the methods for my code behind my user interface
### Sprint Review
I was able to complete two of my sprint goals. Bottlenecks came forth when designing the methods for my code behind due to underestimating the time required. Writing up the code for my methods will be pushed onto the next sprint.
### Sprint Retrospective
One of the blockers for this sprint was forgetting to re-scaffold my database whenever I made any changes to the tables after the first scaffold. I ran into issues when i change some data type field in some of my tables after reconsideringthe deisgn of my erd's adn this highlighted the issue. I also ran into problems when trying tio get my primary key to start from 1 and auto increment, but after some research the issue was quickly rectified. Another bloacker was my underestimating of the time required to code up the methods for my code behind. The next sprint will see me continue with writing my methods and will lead on nicely to creating tests to assert their functionality.

## Sprint 2
### Sprint Goals
The goal for this sprint was to complete the creation of my methods and create tests to assert their functionality
### Sprint Review
Completing the creation of my methods was a success. While this was happening I was manually testing their functionality to check they did what was intended. I was able to complete the test for the method's CRUD functionality, however all my test did not pass as intended
### Sprint Retrospective
One of the main blockers for this sprint was creating my tests. Interacting with with the database from the n-unit proved challenging at first in terms of getting to grips with the TestCase and TearDowns, however once this slight hurdle was conquered tests were relatively simpler to write in terms of understanidng the flow of data from the test framework, to methods and into the database. The main blocker has been a particularly tricky test taht hasn't passed. This test will be moved in to sprint 3 for completion before development of the UI.
