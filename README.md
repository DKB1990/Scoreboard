# Scoreboard

Technologies used: Asp.Net Core 2.0 (Web API)
Description: The purpose of this application is to show score board

1. Just clone the repository on your local
2. Run the application
3. Follow the steps mentioned under this link: https://github.com/DKB1990/Consoleboard/blob/master/README.md
4. You're done! :)

# Key Points 

1. Singleton pattern (Service Locator Pattern)
2. File Handling (using IFile and extended using JsonFile class)
3. Reusable code using file handling, if in case user wants to add a new format, then we can simply extend the IFile interface.
4. Automatically loading of old consoles (from JSON file)
5. Error handling
6. File writting in case of failure
7. cache store (used Dictionary to make the operations fast)
8. API endpoints to update scores for old consoles.
