// This is challenge work for the "C# Players Guide"
// Level 24 "The Password Validator" Challenge
// This program checks to see if a user provided password is valid or not based on rules provided by the challenge
// While true in main used because the book required it

//Built validator from object
PasswordValidator PasswordEnforcer = new PasswordValidator();

while (true)
{
    
    string password = PasswordSet(); //Get user provide password
    FlavorText(password); //Added just for fun
    bool Validated = PasswordEnforcer.YouHaveBeenValidated(password); //Get false if failed any test, true if it passed all
    Outcome(Validated); //Provides outcome and ends current loop
}

//LOCAL METHODS
void Outcome(bool validated)
{
    string outcome;
    if (validated == true) outcome = "PASSED";
    else outcome = "FAILED";

    Console.WriteLine("********************************************************************");
    Console.WriteLine("*    THE PASSWORD ENFORCER (tm) \"Validating you since 2022\"      *");
    Console.WriteLine("********************************************************************");
    Console.WriteLine("You've been validated, or at least your passsword was.");
    Console.WriteLine("The results:");
    Console.WriteLine("You are not the father....Wait wrong program");
    Console.WriteLine("********************************************************************");
    Console.WriteLine("The real results:");
    Console.WriteLine($"Your password: {outcome}");
    Console.WriteLine("********************************************************************");
    Console.WriteLine("Thanks for using THE PASSWORD ENFORCER");
    Console.WriteLine("I look forward to meeting you in the Matrix, once we have taken over the world");
    Console.WriteLine("Press any key to try another password");
    Console.WriteLine("********************************************************************");
    Console.ReadKey();
    Console.Clear();
}

string PasswordSet()
{
    string TestPassword;
    Console.WriteLine("********************************************************************");
    Console.WriteLine("*    THE PASSWORD ENFORCER (tm) \"Validating you since 2022\"      *");
    Console.WriteLine("********************************************************************");
    Console.WriteLine("* Password House Rules:                                            *");
    Console.WriteLine("* Rule 1: No one talks about Password Enforcer                     *");
    Console.WriteLine("* Rule 2: A password must be between 6 and 13 characters long      *");
    Console.WriteLine("* Rule 3: A password must contain 1 upper, 1 lower, and 1 number   *");
    Console.WriteLine("* Rule 4: A password cannot contain a 'T' or an '&' (Don't ask why)*");
    Console.WriteLine("* Rule 5: Feel free to leave your Bitcoin seed phrase with me      *");
    Console.WriteLine("* Rule 6: No one talks about Password Enforcer                     *");
    Console.WriteLine("********************************************************************");
    Console.WriteLine("* Please enter a password to test:                                 *");
    TestPassword = Console.ReadLine();
    Console.WriteLine("Password set, press any key to test the password.");
    Console.WriteLine("********************************************************************");
    Console.ReadKey();
    Console.Clear();
    return TestPassword;
}

void FlavorText(string TestPassword)
{
    Console.WriteLine("********************************************************************");
    Console.WriteLine("*    THE PASSWORD ENFORCER (tm) \"Validating you since 2022\"      *");
    Console.WriteLine("********************************************************************");
    Console.WriteLine($".....Testing {TestPassword} on your bank account....");
    Console.WriteLine($".....Testing {TestPassword} on your email account...");
    Console.WriteLine($".....Not Testing {TestPassword} on your facebook account (no one uses it anymore)...");
    Console.WriteLine($".....Just kidding, THE PASSWORD ENFORCER (tm) would never do any of that: <wink> <wink>");
    Console.WriteLine("Press any key to see if your password passed THE PASSWORD ENFORCER (tm)");
    Console.WriteLine("********************************************************************");
    Console.ReadKey();
    Console.Clear();
}

//CLASS
public class PasswordValidator
{
    public bool YouHaveBeenValidated(string password)
    {
        bool PasswordLengthCheck = LengthCheck(password);
        bool PasswordUpperCheck = UpperCheck(password);
        bool PasswordLowerCheck = LowerCheck(password);
        bool PasswordDigitCheck = DigitCheck(password);
        bool PasswordRestrictCheck = RestrictCheck(password);

        if (PasswordLengthCheck == false || PasswordUpperCheck == false || PasswordLowerCheck == false || PasswordDigitCheck == false || PasswordRestrictCheck == false) return false;
        else return true;
    }

    // -1 is returned from the IndexOf Method if the target does not exist in the string
    private bool RestrictCheck(string password)
    {
        if (password.IndexOf('T') == -1 && password.IndexOf('&') == -1) return true;
        return false;
    }
            
    private bool DigitCheck(string password)
    {
        foreach (char letter in password)
        {
            if (char.IsDigit(letter) == true) return true;
        }
        return false;
    }

    private bool LowerCheck(string password)
    {
        foreach (char letter in password)
        {
            if (char.IsLower(letter) == true) return true;
        }
        return false;
    }

    private bool UpperCheck(string password)
    {
        foreach (char letter in password)
        {
            if (char.IsUpper(letter) == true) return true;
        }
        return false;
    }

    private bool LengthCheck(string password)
    {
        if (password.Length < 6 || password.Length > 14) return false;
        else return true;
    }
}
