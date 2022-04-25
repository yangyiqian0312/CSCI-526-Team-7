using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO:
//Change back TutorialDone in GameData.cs
//Change back tips in GameData.cs
//CHange back day in GameData.cs
//Change back probability of invalid ID in MainMenu.cs
//Change back timeRemaining to 90 seconds in Both GameData.cs and update in DaySummary.cs, Failure.cs
public static class GameData
{
    public static int TutorialDone = 0;
    public static int BarSceneTutorialDone = 0;
    public static float tips = 0;
    public static int date = 1;
    public static Customer currCustomer;
    public static int currCustomerId;
    public static int customerIDRange = 20;
    public static int upgradeTipsNeed = 2;
    public static int tipsLevel = 0;
    public static int day = 0;
    public static int firstDate = 26;
    public static float tipsEarnedToday = 0;
    public static int pause = 0;
  
    public static bool newDay = true;
    public static int customerNumber = 0;
  
    public static double timeRemaining = 600;
    public static HashSet<int> todayOccured = new HashSet<int>();

    public static bool customerExiting = true;

    public class Customer{
        public float customTip;

        // idx0 = spicy
        // idx1 = sweet
        // idx2 = sour
        // idx3 = aromatic
        // idx4 = strength
        // 0 value = whatever; 1 = want this property; -1 = doesn't like this property
        public List<int> requirements = new List<int>();

        // idx0 = Fresh cherry; idx1 = Chili flake; idx2 = gold leaves; idx3 = Pineapples; idx4 = Lemon;
        // idx5 = Orange Syrup; idx6 = Mint
        public int flavoring;

        public string name;

        public int requirementNum;
        public int specificCocktail;
        public string dialogue;

        public string gender = "default";
        public string invalidGender  = "default";
        public string birthday  = "default";
        public string invalidBirthday  = "default";
        public string hairColor  = "default";
        public string invalidHairColor  = "default";
        public string expirationDate  = "default";
        public string invalidExpirationDate  = "default";
        public int firstInvalid = -1;
        public int secondInvalid = -1;


        public Customer(int currTip, int currSpicy, int currSweet, int currSour, int currAromatic, int currStrength,
            int currFlavoring, string currName, int currRequirementNum, int currSpecificCocktail, 
            string currDialogue){
                this.customTip = currTip;

                this.requirements.Add(currSpicy);
                this.requirements.Add(currSweet);
                this.requirements.Add(currSour);
                this.requirements.Add(currAromatic);
                this.requirements.Add(currStrength);

                this.flavoring = currFlavoring;

                this.specificCocktail = currSpecificCocktail;
                this.name = currName;

                this.requirementNum = currRequirementNum;
                this.dialogue = currDialogue;
        }


        public Customer(int currTip, int currSpicy, int currSweet, int currSour, int currAromatic, int currStrength,
            int currFlavoring, string currName, int currRequirementNum, int currSpecificCocktail, 
            string currDialogue, 

            string currGender, string currBirthday, string currHairColor, 
            string currExpirationDate, 

            string currInvalidGender, string currInvalidBirthday,string currInvalidHairColor, 
            string currInvalidExpirationDate, int firstInvalid, int secondInvalid){

                this.customTip = currTip;

                this.requirements.Add(currSpicy);
                this.requirements.Add(currSweet);
                this.requirements.Add(currSour);
                this.requirements.Add(currAromatic);
                this.requirements.Add(currStrength);

                this.flavoring = currFlavoring;

                this.specificCocktail = currSpecificCocktail;
                this.name = currName;

                this.requirementNum = currRequirementNum;
                this.dialogue = currDialogue;

                this.gender = currGender;
                this.invalidGender = currInvalidGender;

                this.birthday = currBirthday;
                this.invalidBirthday = currInvalidBirthday;

                this.hairColor = currHairColor;
                this.invalidHairColor = currInvalidHairColor;

                this.expirationDate = currExpirationDate;
                this.invalidExpirationDate = currInvalidExpirationDate;

                this.firstInvalid = firstInvalid;
                this.secondInvalid = secondInvalid;
        }
    }


    public static Customer customer1 = new Customer(20, 0, 1, 0, 0, 0, 0, "Frank", 2, -1,
        "I would like a <b><#FF00FD>Sweet</color></b> drink, topped off with <b>Fresh Cherry</b>.",
        "M", "01/10/2000","Brown", "01/01/2025",
        "M", "01/10/2004","Brown", "01/01/2025", 1, -1);

    public static Customer customer2 = new Customer(10, 1, -1, 0, 0, 0, -1, "Pedro", 2, -1,
         "I'm in the mood for a <b><#FF5F00>Spicy</color></b> drink, but please make it <b>NOT <#FF00FD>Sweet</color></b>. Can you do that for me?",
         "F", "02/15/1997", "Brown", "02/01/2025",
         "F", "02/15/1997", "Blue", "02/01/2025", 2, -1);

    public static Customer customer3 = new Customer(30, 0, 0, 0, 0, 1, -1, "Kelsey", 1, -1,
        "Just give me something <b><#FF0B00>Strong</color></b> !",
        "F", "04/01/1999", "Brown", "04/01/2024",
        "F", "04/01/1999", "Brown", "04/01/2020", 3, -1);

    public static Customer customer4 = new Customer(30, 1, 0, 0, 1, 0, -1, "Jaq", 2, -1,
        "Oh Hello! I would really use a <b><#002CFF>Aromatic</color></b> and <b><#FF5F00>Spicy</color></b> drink now! ",
        "F", "05/05/1995", "Blonde", "05/01/2025",
        "F", "05/05/2004", "Blonde", "05/01/2025", 1, -1);

    public static Customer customer5 = new Customer(10, 0, 1, -1, 0, 0, -1, "Zhou", 2, -1,
        "Can you make me a <b><#FF00FD>Sweet</color></b> cocktail, but <b>NOT <#1ABC77>Sour</color></b> ?",
        "F", "05/14/1996", "Purple", "05/03/2025",
        "F", "06/14/1996", "Black", "01/03/2019", 2, 3);

    public static Customer customer6 = new Customer(20, 0, 0, 0, 0, 0, -1, "Amy", 1, 2,
        "Hi! A <b><i><#B7950B>Solar Cocktail</color></i></b> please!",
        "F", "11/02/1989", "Blonde", "11/01/2026",
        "M", "11/02/2003", "Blonde", "11/01/2026", 0, 1);

    public static Customer customer7 = new Customer(10, 0, 0, 0, 0, 0, -1, "Sang", 1, 0,
        "Hi there! Could you make me an <b><i><#B7950B>LA Vacation</color></b></i>?",
        "M", "12/12/1990", "Brown", "09/10/2025",
        "M", "12/12/2004", "Blue", "09/10/2025", 1, 2);
    
    public static Customer customer8 = new Customer(10, 0, 0, 0, 0, 0, -1, "Calvin", 1, 3,
        "Hi! I would like a non-alcoholic drink, so a <b><i><#B7950B>Kindergarten</color></i></b> please!",
        "M", "01/23/2000", "Brown", "01/14/2025",
        "F", "01/23/2000", "Brown", "01/14/2019", 0, 3);
    
    public static Customer customer9 = new Customer(20, 0, 0, 0, 0, 0, -1, "Wilson", 1, 1,
        "Can you make a <b><i><#B7950B>Moutai</color></i></b> for me?",
        "M", "07/20/1990", "Blue", "08/25/2025",
        "M", "04/13/2003", "Blonde", "08/25/2025", 1, 2);

    public static Customer customer10 = new Customer(10, 0, 0, 1, 0, 0, -1, "Sammy", 1, -1,
        "Could you make a <b><i><#1ABC77>Sour</color></i></b> drink for me?",
        "M", "08/24/1990", "Light Blue", "11/11/2024",
        "F", "08/24/1990", "Brown", "11/11/2010", 0, 2);

    public static Customer customer11 = new Customer(15, 0, 0, 0, 1, 0, -1, "Claire", 1, -1,
        "An <b><i><#002CFF>Aromatic</color></i></b> drink please!",
        "F", "02/27/2000", "Light Blue", "12/10/2024",
        "M", "02/27/2004", "Light Blue", "12/10/2024", 0, 1);

    public static Customer customer12 = new Customer(10, 1, 0, 0, 0, 0, -1, "Xing", 1, -1,
        "I am really feeling a <b><i><#FF5F00>Spicy</color></i></b> drink now!",
        "F", "05/10/1997", "Brown", "10/12/2024",
        "F", "05/10/1997", "Purple", "10/12/2020", 2, 3);

    public static Customer customer13 = new Customer(10, 0, 1, 0, 0, 0, -1, "James", 1, -1,
        "I would like a <b><#FF00FD>Sweet</color></b> drink!",
        "M", "12/12/1997", "Brown", "12/01/2025",
        "M", "12/12/2005", "Blue", "12/01/2025", 1, 2);
    
    public static Customer customer14 = new Customer(20, 0, 1, 1, 0, 0, -1, "Igor", 2, -1,
        "Could you make me something <b><#FF00FD>Sweet</color></b> and <b><#1ABC77>Sour</color></b>?",
        "M", "01/11/1995", "Brown", "11/07/2024",
        "F", "01/11/2004", "Brown", "11/07/2024", 0, 1);
    
    public static Customer customer15 = new Customer(20, 0, 0, 0, 0, 0, -1, "Tori", 1, 2,
        "Could I get a <b><i><#B7950B>Solar Cocktail</color></i></b> please?",
        "F", "02/28/1997", "Red", "08/07/2024",
        "F", "02/28/1997", "Red", "08/07/2015", 3, -1);
    
    public static Customer customer16 = new Customer(10, 0, 0, 0, 1, 0, -1, "Jen", 1, -1,
        "I would like something <b><#002CFF>Aromatic</color></b>!",
        "F", "01/30/1999", "Brown", "01/15/2025",
        "M", "01/30/2003", "Light Blue", "01/15/2025", 0, 2);

    public static Customer customer17 = new Customer(30, 0, 0, 0, 0, 0, -1, "Coco", 1, 1,
        "Hey! Could you make me a <b><i><#B7950B>Moutai</color></i></b>?",
        "F", "06/15/1996", "Blonde", "12/31/2023",
        "F", "06/15/2004", "Green", "12/31/2023", 1, 2);

    public static Customer customer18 = new Customer(20, 1, 1, 0, 0, 0, -1, "Blake", 2, -1,
        "I want a <b><#FF00FD>Sweet</color></b> and <b><i><#FF5F00>Spicy</color></i></b> drink!",
        "M", "04/23/1997", "Brown", "08/23/2025",
        "F", "04/23/2003", "Brown", "08/23/2025",0 ,1);

    public static Customer customer19 = new Customer(20, 1, 0, 0, 0, 0, -1, "Chad", 1, -1,
        "Could you make me a <b><i><#FF5F00>Spicy</color></i></b> drink?",
        "M", "07/10/1997", "Brown", "04/18/2025",
        "M", "07/10/2005", "Brown", "04/18/2025", 1, -1);

    public static Customer customer20 = new Customer(10, 0, 0, 0, 0, 0, -1, "Paris", 1,0,
        "I would like an <b><i><#B7950B>LA Vacation</color></b></i> please! ",
        "F", "06/02/1985", "Brown", "09/10/2027",
        "F", "06/02/2003", "Brown", "09/10/2007", 1, 3);


    public static List<Customer> customers = new List<Customer>() {customer1, customer2, customer3, 
        customer4, customer5, customer6, customer7, customer8, customer9, customer10, customer11, customer12,
        customer13, customer14, customer15, customer16, customer17, customer18, customer19, customer20};

    public static List<float> goals = new List<float>(){0f,40f,90f,150f,220f};

}
