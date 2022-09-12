# Git Cheat Sheet 

## General Order of Operations 
This will be the standard steps when downloading / uploading changes to your project via GIT.

PULL --> ADD --> COMMIT --> PUSH --> REPEAT

***
**Pull**

In this stage you are pulling (downloading) the latest changes from the GitHub server where your project is stored. *This should **ALWAYS** be done before making any changes to avoid merge issues.*

    git pull 
****

**Add**

This is how to add files from your local machine to the "staging" area where they can then by committed and pushed. This allows you to group certain files together to make commits regarding similar code. You can either add file by file (important for later in the project) or all the general changes you have made. 

    git add <filename>
    git add . (this adds all changes from current directory and any others in that directory)

****

**Commit**

This is where you will make the commit that will be pushed to your GitHub server where all the code is stored. There is a message that is associated with each commit for documentation purposes. **THIS IS IMPORTANT!!** Make sure to leave a descriptive message of exactly what your changing in case your commit needs to be tracked down in the future if it breaks something. This will package everything up to be ready to push to the code repo.   

    git commit -m '<put a descriptive message here about what you're committing>'

****
**Push**

This is the command that will actually push your committed changes to the code base. You will see some loading and then it should say it was successful and the working branch should stay on main. *If this is not the case and you accidentally make a new branch, be sure to let your team lead 1 know so they can fix it.*

    git push

****

If there is any other questions regarding this process or GIT/GitHub in general, feel free to ask your team lead 1's, we will help you out!!



> Written with [StackEdit](https://stackedit.io/).
