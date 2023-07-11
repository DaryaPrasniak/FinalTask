# FinalTask Checklist
GUI Positive:
1. Verify user can login with valid credentials
2. Verify user can add a project name (1 character, 20 characters)
3. Verify user cannot add a project with blank name field
4. Verify the pop up is displayed if hover over "Upgrade" button on the Dashboard page
5. Verify user can add a project
6. Verify user can delete a project
7. Verify the dialog window is displayed if click "Refine" button on the Dashboard page
8. Verify user can upload a file in the milestones tab

GUI Negative:
1. Verify user cannot login with invalid credentials(blank password field)
2. Verify user cannot input more than 250 characters to search field
3. Verify user can login with spaces in the password(test for screenshot)

API:
1. Verify correct milestone returned for GET request
2. Verify BadRequest returned for invalid GET request(nonexisting milestone)
3. Verify BadRequest returned for invalid GET request(sring milestone id)
