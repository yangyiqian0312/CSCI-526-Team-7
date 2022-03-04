using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    
    public static int TutorialDone = 0;

    public static float tips;
    public static int date = 1;
    public static Customer currCustomer;
    public static int customerIDRange = 9;
    public static int upgradeTipsNeed = 2;
    public static int tipsLevel = 0;


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

        public Customer(int currTip, int currSpicy, int currSweet, int currSour, int currAromatic, int currStrength,
            int currFlavoring, string currName, int currRequirementNum, int currSpecificCocktail, string currDialogue){
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
    }

    public static Customer customer1 = new Customer(10, 0, 0, 0, 0, 0, -1, "Sang", 1, 0,
        "Hi there! Could you make me an <b><i><#B7950B>LA Vacation</color></b></i>?");

    public static Customer customer2 = new Customer(10, 1, -1, 0, 0, 0, -1, "Pedro", 2, -1,
         "I'm in the mood for a <b><#FF5F00>Spicy</color></b> drink, but please make it <b>NOT <#FF00FD>Sweet</color></b>. Can you do that for me?");

    public static Customer customer3 = new Customer(50, 0, 0, 0, 0, 1, -1, "Wilson", 1, -1,
        "Just give me something <b><#FF0B00>Strong</color></b> !");

    public static Customer customer4 = new Customer(40, 1, 0, 0, 1, 0, -1, "Jaq", 2, -1,
        "Oh Hello! I would really use a <b><#002CFF>Aromatic</color></b> and <b><#FF5F00>Spicy</color></b> drink now! ");

    public static Customer customer5 = new Customer(10, 0, 1, -1, 0, 0, -1, "Kelsey", 2, -1,
        "Can you make me a <b><#FF00FD>Sweet</color></b> cocktail, but <b>NOT <#1ABC77>Sour</color></b> ?");

    public static Customer customer6 = new Customer(15, 0, 0, 0, 0, 0, -1, "Joe", 1, 2,
        "Hi! A <b><i><#B7950B>Solar Cocktail</color></i></b> please!");

    public static Customer customer7 = new Customer(20, 0, 1, 0, 0, 0, 0, "Frank", 2, -1,
        "I would like a <b><#FF00FD>Sweet</color></b> drink, topped off with <b>Fresh Cherry</b>.");
    
    public static Customer customer8 = new Customer(10, 0, 0, 0, 0, 0, 0, "Calvin", 1, 3,
        "Hi! I would like a non-alcoholic drink, so a <b><i><#B7950B>Kindergarten</color></i></b> please!");
    
    public static Customer customer9 = new Customer(20, 0, 0, 0, 0, 0, 0, "Zhou", 1, 1,
        "Can you make a <b><i><#B7950B>Moutai</color></i></b> for me?");

    public static List<Customer> customers = new List<Customer>() {customer1, customer2, customer3, 
        customer4, customer5, customer6, customer7, customer8, customer9};



}
