using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    const string menuHint = "You may type menu";
    string[] level1Passwords = { "teacher", "playground", "lessons", "books", "lunch" };
    string[] level2Passwords = { "sergeant", "commissioner", "lockup", "arrest", "criminals" };
    string[] level3Passwords = { "astrophysicist", "spaceflight", "armstrong", "satellite", "orbiter" };

    //Game States
    int level;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }


    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into today?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local primary school");
        Terminal.WriteLine("Press 2 for the police headquarters");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Close tab if on internet");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "007")
        {
            Terminal.WriteLine("Please Choose a option Mr Bond");
        }

        else
        {
            Terminal.WriteLine("Please enter a valid selection");
        }
    }

        void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
   _________
  /       //
 /       //
/_______//
(_______(/                ");
                break;

            case 2:
                Terminal.WriteLine("I'm suprised you didn't end up here...");
                Terminal.WriteLine(@"
______________
|   |   |    |
|   |   |    |
|   |   |    |
|   |   |    |
|   |   |    |
|___|___|____|
                ");
                break;

            case 3:
                Terminal.WriteLine("Your hacking skills have really taken  off...");
                Terminal.WriteLine(@"
_____________________      00000
 |                |       0000000
   |___       ___|        0000000
      |_       _|          00000
       |_______|
           
");
                break;

              default:
                Debug.LogError("Invalid level reached");
                break;


        }
    }
}  
